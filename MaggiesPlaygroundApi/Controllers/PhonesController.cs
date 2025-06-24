using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MaggiesPlaygroundApi.Models;
using MaggiesPlaygroundApi.Services;

namespace MaggiesPlaygroundApi.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class PhonesController : ControllerBase
{
    private readonly IPhoneService phoneService;
    private readonly ILogger<PhonesController> logger;

    public PhonesController(IPhoneService phoneService, ILogger<PhonesController> logger)
    {
        this.phoneService = phoneService;
        this.logger = logger;
    }

    [HttpGet("[action]")]
    public async Task<ActionResult<PaginatedResponseDto<PhoneDto>>> GetPhones([FromQuery] PhoneQueryParameters queryParams)
    {
        try
        {
            var (phones, totalCount) = await phoneService.GetPhonesAsync(queryParams);
            
            var response = new PaginatedResponseDto<PhoneDto>
            {
                TotalCount = totalCount,
                PageSize = queryParams.PageSize,
                CurrentPage = queryParams.PageNumber,
                Items = phones
            };
            
            return Ok(response);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error retrieving phones");
            return StatusCode(500, "An error occurred while retrieving phones");
        }
    }

    [HttpGet("[action]/{id}")]
    public async Task<ActionResult<PhoneDto>> GetPhone(Guid id)
    {
        try
        {
            var phone = await phoneService.GetPhoneByIdAsync(id);
            
            if (phone == null)
            {
                return NotFound();
            }

            return Ok(phone);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error retrieving phone {PhoneId}", id);
            return StatusCode(500, "An error occurred while retrieving the phone");
        }
    }

    [Authorize]
    [HttpPost("[action]")]
    public async Task<ActionResult<PhoneDto>> CreatePhone(CreatePhoneDto phoneDto)
    {
        try
        {
            var currentUser = User.Identity?.Name ?? "System";
            var createdPhone = await phoneService.CreatePhoneAsync(phoneDto, currentUser);
            return CreatedAtAction(nameof(GetPhone), new { id = createdPhone.PhoneId }, createdPhone);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error creating phone");
            return StatusCode(500, "An error occurred while creating the phone");
        }
    }

    [Authorize]
    [HttpPut("[action]/{id}")]
    public async Task<IActionResult> UpdatePhone(Guid id, UpdatePhoneDto phoneDto)
    {
        try
        {
            var currentUser = User.Identity?.Name ?? "System";
            var updatedPhone = await phoneService.UpdatePhoneAsync(id, phoneDto, currentUser);
            
            if (updatedPhone == null)
            {
                return NotFound();
            }

            return Ok(updatedPhone);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error updating phone {PhoneId}", id);
            return StatusCode(500, "An error occurred while updating the phone");
        }
    }

    [Authorize]
    [HttpDelete("[action]/{id}")]
    public async Task<IActionResult> DeletePhone(Guid id)
    {
        try
        {
            var currentUser = User.Identity?.Name ?? "System";
            var result = await phoneService.DeletePhoneAsync(id, currentUser);
            
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error deleting phone {PhoneId}", id);
            return StatusCode(500, "An error occurred while deleting the phone");
        }
    }
} 