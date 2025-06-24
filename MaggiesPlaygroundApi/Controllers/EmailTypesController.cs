using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MaggiesPlaygroundApi.Models;
using MaggiesPlaygroundApi.Services;

namespace MaggiesPlaygroundApi.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class EmailTypesController : ControllerBase
{
    private readonly IEmailTypeService emailTypeService;
    private readonly ILogger<EmailTypesController> logger;

    public EmailTypesController(IEmailTypeService emailTypeService, ILogger<EmailTypesController> logger)
    {
        this.emailTypeService = emailTypeService;
        this.logger = logger;
    }

    [HttpGet("[action]")]
    public async Task<ActionResult<PaginatedResponseDto<EmailTypeDto>>> GetEmailTypes([FromQuery] EmailTypeQueryParameters queryParams)
    {
        try
        {
            var (emailTypes, totalCount) = await emailTypeService.GetEmailTypesAsync(queryParams);
            
            var response = new PaginatedResponseDto<EmailTypeDto>
            {
                TotalCount = totalCount,
                PageSize = queryParams.PageSize,
                CurrentPage = queryParams.PageNumber,
                Items = emailTypes
            };
            
            return Ok(response);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error retrieving email types");
            return StatusCode(500, "An error occurred while retrieving email types");
        }
    }

    [HttpGet("[action]/{id}")]
    public async Task<ActionResult<EmailTypeDto>> GetEmailType(int id)
    {
        try
        {
            var emailType = await emailTypeService.GetEmailTypeByIdAsync(id);
            
            if (emailType == null)
            {
                return NotFound();
            }

            return Ok(emailType);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error retrieving email type {EmailTypeId}", id);
            return StatusCode(500, "An error occurred while retrieving the email type");
        }
    }

    [Authorize]
    [HttpPost("[action]")]
    public async Task<ActionResult<EmailTypeDto>> CreateEmailType(CreateEmailTypeDto emailTypeDto)
    {
        try
        {
            var currentUser = User.Identity?.Name ?? "System";
            var createdEmailType = await emailTypeService.CreateEmailTypeAsync(emailTypeDto, currentUser);
            return CreatedAtAction(nameof(GetEmailType), new { id = createdEmailType.EmailTypeId }, createdEmailType);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error creating email type");
            return StatusCode(500, "An error occurred while creating the email type");
        }
    }

    [Authorize]
    [HttpPut("[action]/{id}")]
    public async Task<IActionResult> UpdateEmailType(int id, UpdateEmailTypeDto emailTypeDto)
    {
        try
        {
            var currentUser = User.Identity?.Name ?? "System";
            var updatedEmailType = await emailTypeService.UpdateEmailTypeAsync(id, emailTypeDto, currentUser);
            
            if (updatedEmailType == null)
            {
                return NotFound();
            }

            return Ok(updatedEmailType);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error updating email type {EmailTypeId}", id);
            return StatusCode(500, "An error occurred while updating the email type");
        }
    }

    [Authorize]
    [HttpDelete("[action]/{id}")]
    public async Task<IActionResult> DeleteEmailType(int id)
    {
        try
        {
            var currentUser = User.Identity?.Name ?? "System";
            var result = await emailTypeService.DeleteEmailTypeAsync(id, currentUser);
            
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error deleting email type {EmailTypeId}", id);
            return StatusCode(500, "An error occurred while deleting the email type");
        }
    }
} 