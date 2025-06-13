using MaggiesPlaygroundApi.Models;
using MaggiesPlaygroundApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MaggiesPlaygroundApi.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class GendersController(IGenderService genderService) : ControllerBase
{
    [HttpGet("[action]")]
    public async Task<ActionResult<IEnumerable<GenderDto>>> GetGenders([FromQuery] GenderQueryParameters queryParams)
    {
        var (genders, totalCount) = await genderService.GetGendersAsync(queryParams);
        Response.Headers.Append("X-Total-Count", totalCount.ToString());
        return Ok(genders);
    }

    [HttpGet("[action]/{id}")]
    public async Task<ActionResult<GenderDto>> GetGender(int id)
    {
        var gender = await genderService.GetGenderByIdAsync(id);
        if (gender == null)
        {
            return NotFound();
        }
        return Ok(gender);
    }

    [HttpPost("[action]")]
    public async Task<ActionResult<GenderDto>> CreateGender(CreateGenderDto genderDto)
    {
        var currentUser = User.Identity?.Name ?? "System";
        var gender = await genderService.CreateGenderAsync(genderDto, currentUser);
        return CreatedAtAction(nameof(GetGender), new { id = gender.GenderId }, gender);
    }

    [HttpPut("[action]/{id}")]
    public async Task<ActionResult<GenderDto>> UpdateGender(int id, UpdateGenderDto genderDto)
    {
        var currentUser = User.Identity?.Name ?? "System";
        var gender = await genderService.UpdateGenderAsync(id, genderDto, currentUser);
        if (gender == null)
        {
            return NotFound();
        }
        return Ok(gender);
    }

    [HttpDelete("[action]/{id}")]
    public async Task<ActionResult> DeleteGender(int id)
    {
        var currentUser = User.Identity?.Name ?? "System";
        var result = await genderService.DeleteGenderAsync(id, currentUser);
        if (!result)
        {
            return NotFound();
        }
        return NoContent();
    }
} 