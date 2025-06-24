using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MaggiesPlaygroundApi.Models;
using MaggiesPlaygroundApi.Services;

namespace MaggiesPlaygroundApi.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class EmailsController : ControllerBase
{
    private readonly IEmailService emailService;
    private readonly ILogger<EmailsController> logger;

    public EmailsController(IEmailService emailService, ILogger<EmailsController> logger)
    {
        this.emailService = emailService;
        this.logger = logger;
    }

    [HttpGet("[action]")]
    public async Task<ActionResult<PaginatedResponseDto<EmailDto>>> GetEmails([FromQuery] EmailQueryParameters queryParams)
    {
        try
        {
            var (emails, totalCount) = await emailService.GetEmailsAsync(queryParams);
            
            var response = new PaginatedResponseDto<EmailDto>
            {
                TotalCount = totalCount,
                PageSize = queryParams.PageSize,
                CurrentPage = queryParams.PageNumber,
                Items = emails
            };
            
            return Ok(response);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error retrieving emails");
            return StatusCode(500, "An error occurred while retrieving emails");
        }
    }

    [HttpGet("[action]/{id}")]
    public async Task<ActionResult<EmailDto>> GetEmail(Guid id)
    {
        try
        {
            var email = await emailService.GetEmailByIdAsync(id);
            
            if (email == null)
            {
                return NotFound();
            }

            return Ok(email);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error retrieving email {EmailId}", id);
            return StatusCode(500, "An error occurred while retrieving the email");
        }
    }

    [Authorize]
    [HttpPost("[action]")]
    public async Task<ActionResult<EmailDto>> CreateEmail(CreateEmailDto emailDto)
    {
        try
        {
            var currentUser = User.Identity?.Name ?? "System";
            var createdEmail = await emailService.CreateEmailAsync(emailDto, currentUser);
            return CreatedAtAction(nameof(GetEmail), new { id = createdEmail.EmailId }, createdEmail);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error creating email");
            return StatusCode(500, "An error occurred while creating the email");
        }
    }

    [Authorize]
    [HttpPut("[action]/{id}")]
    public async Task<IActionResult> UpdateEmail(Guid id, UpdateEmailDto emailDto)
    {
        try
        {
            var currentUser = User.Identity?.Name ?? "System";
            var updatedEmail = await emailService.UpdateEmailAsync(id, emailDto, currentUser);
            
            if (updatedEmail == null)
            {
                return NotFound();
            }

            return Ok(updatedEmail);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error updating email {EmailId}", id);
            return StatusCode(500, "An error occurred while updating the email");
        }
    }

    [Authorize]
    [HttpDelete("[action]/{id}")]
    public async Task<IActionResult> DeleteEmail(Guid id)
    {
        try
        {
            var currentUser = User.Identity?.Name ?? "System";
            var result = await emailService.DeleteEmailAsync(id, currentUser);
            
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error deleting email {EmailId}", id);
            return StatusCode(500, "An error occurred while deleting the email");
        }
    }
} 