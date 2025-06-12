using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using MaggiesPlaygroundApi.Models;
using MaggiesPlaygroundApi.Enums;
using System.ComponentModel.DataAnnotations;

namespace MaggiesPlaygroundApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(
    UserManager<ApplicationUser> userManager,
    RoleManager<IdentityRole> roleManager,
    IConfiguration configuration)
    : ControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterModel model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var user = new ApplicationUser
        {
            UserName = model.Email,
            Email = model.Email,
            FirstName = model.FirstName,
            LastName = model.LastName
        };


        try
        {
            var result = await userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                if (!await roleManager.RoleExistsAsync(nameof(UserRole.SuperAdmin)))
                {
                    await roleManager.CreateAsync(new IdentityRole(nameof(UserRole.SuperAdmin)));
                }

                if (!await roleManager.RoleExistsAsync(nameof(UserRole.Admin)))
                {
                    await roleManager.CreateAsync(new IdentityRole(nameof(UserRole.Admin)));
                }

                if (!await roleManager.RoleExistsAsync(nameof(UserRole.User)))
                {
                    await roleManager.CreateAsync(new IdentityRole(nameof(UserRole.User)));
                }

                if (!await roleManager.RoleExistsAsync(nameof(UserRole.Viewer)))
                {
                    await roleManager.CreateAsync(new IdentityRole(nameof(UserRole.Viewer)));
                }

                switch (model.Role)
                {
                    case nameof(UserRole.SuperAdmin):
                        await userManager.AddToRoleAsync(user, nameof(UserRole.SuperAdmin));
                        break;
                    case nameof(UserRole.Admin):
                        await userManager.AddToRoleAsync(user, nameof(UserRole.Admin));
                        break;
                    case nameof(UserRole.User):
                        await userManager.AddToRoleAsync(user, nameof(UserRole.User));
                        break;
                    default:
                        await userManager.AddToRoleAsync(user, nameof(UserRole.Viewer));
                        break;
                }

                return Ok(new {UserId = user.Id});
            }

            return BadRequest($"User Role creation failed for {model.Email}. Please check the provided information.");
        }
        catch (Exception e)
        {
            return BadRequest($"User creation failed for {model.Email}\n{e.Message}");
        }
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginModel model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var user = await userManager.FindByEmailAsync(model.Email);
        if (user == null)
        {
            return Unauthorized(new { message = "Invalid email or password" });
        }

        var result = await userManager.CheckPasswordAsync(user, model.Password);
        if (!result)
        {
            return Unauthorized(new { message = "Invalid email or password" });
        }

        var token = GenerateJwtToken(user);

        user.LastLoginAt = DateTime.UtcNow;
        await userManager.UpdateAsync(user);

        return Ok(new
        {
            token,
            user = new
            {
                user.Id,
                user.Email,
                user.FirstName,
                user.LastName
            }
        });
    }

    [HttpPost("roles")]
    [Authorize(Roles = Roles.Admin)]
    public async Task<IActionResult> CreateRole([FromBody] RoleModel model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var roleExists = await roleManager.RoleExistsAsync(model.Name);
        if (roleExists)
        {
            return BadRequest(new { message = "Role already exists" });
        }

        var role = new IdentityRole(model.Name);
        var result = await roleManager.CreateAsync(role);

        if (result.Succeeded)
        {
            return Ok(new { message = "Role created successfully" });
        }

        return BadRequest(result.Errors);
    }

    [HttpPost("users/{userId}/roles")]
    [Authorize(Roles = Roles.Admin)]
    public async Task<IActionResult> AssignRoleToUser(string userId, [FromBody] RoleModel model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var user = await userManager.FindByIdAsync(userId);
        if (user == null)
        {
            return NotFound(new { message = "User not found" });
        }

        var roleExists = await roleManager.RoleExistsAsync(model.Name);
        if (!roleExists)
        {
            return BadRequest(new { message = "Role does not exist" });
        }

        var result = await userManager.AddToRoleAsync(user, model.Name);
        if (result.Succeeded)
        {
            return Ok(new { message = "Role assigned successfully" });
        }

        return BadRequest(result.Errors);
    }

    [HttpPost("users/{userId}/claims")]
    [Authorize(Roles = Roles.Admin)]
    public async Task<IActionResult> AddClaimToUser(string userId, [FromBody] ClaimModel model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var user = await userManager.FindByIdAsync(userId);
        if (user == null)
        {
            return NotFound(new { message = "User not found" });
        }

        var claim = new Claim(model.Type, model.Value);
        var result = await userManager.AddClaimAsync(user, claim);

        if (result.Succeeded)
        {
            return Ok(new { message = "Claim added successfully" });
        }

        return BadRequest(result.Errors);
    }

    [HttpGet("users/{userId}/roles")]
    [Authorize(Roles = Roles.Admin)]
    public async Task<IActionResult> GetUserRoles(string userId)
    {
        var user = await userManager.FindByIdAsync(userId);
        if (user == null)
        {
            return NotFound(new { message = "User not found" });
        }

        var roles = await userManager.GetRolesAsync(user);
        return Ok(roles);
    }

    [HttpGet("users/{userId}/claims")]
    [Authorize(Roles = Roles.Admin)]
    public async Task<IActionResult> GetUserClaims(string userId)
    {
        var user = await userManager.FindByIdAsync(userId);
        if (user == null)
        {
            return NotFound(new { message = "User not found" });
        }

        var claims = await userManager.GetClaimsAsync(user);
        return Ok(claims);
    }

    private string GenerateJwtToken(ApplicationUser user)
    {
        var userRoles = userManager.GetRolesAsync(user).Result;
        var userClaims = userManager.GetClaimsAsync(user).Result;

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.GivenName, user.FirstName),
            new Claim(ClaimTypes.Surname, user.LastName)
        };

        // Add roles to claims
        foreach (var role in userRoles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }

        // Add custom claims
        claims.AddRange(userClaims);

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var expires = DateTime.Now.AddDays(Convert.ToDouble(7));

        var token = new JwtSecurityToken(
            configuration["JWT:ValidIssuer"],
            configuration["JWT:ValidAudience"],
            claims,
            expires: expires,
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
} 