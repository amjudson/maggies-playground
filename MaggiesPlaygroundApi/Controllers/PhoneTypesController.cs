using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MaggiesPlaygroundApi.Models;
using MaggiesPlaygroundApi.Services;

namespace MaggiesPlaygroundApi.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class PhoneTypesController : ControllerBase
{
    private readonly IPhoneTypeService phoneTypeService;
    private readonly ILogger<PhoneTypesController> logger;

    public PhoneTypesController(IPhoneTypeService phoneTypeService, ILogger<PhoneTypesController> logger)
    {
        this.phoneTypeService = phoneTypeService;
        this.logger = logger;
    }

    [HttpGet("[action]")]
    public async Task<ActionResult<PaginatedResponseDto<PhoneTypeDto>>> GetPhoneTypes([FromQuery] PhoneTypeQueryParameters queryParams)
    {
        try
        {
            var (phoneTypes, totalCount) = await phoneTypeService.GetPhoneTypesAsync(queryParams);
            
            var response = new PaginatedResponseDto<PhoneTypeDto>
            {
                TotalCount = totalCount,
                PageSize = queryParams.PageSize,
                CurrentPage = queryParams.PageNumber,
                Items = phoneTypes
            };
            
            return Ok(response);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error retrieving phone types");
            return StatusCode(500, "An error occurred while retrieving phone types");
        }
    }

    [HttpGet("[action]/{id}")]
    public async Task<ActionResult<PhoneTypeDto>> GetPhoneType(int id)
    {
        try
        {
            var phoneType = await phoneTypeService.GetPhoneTypeByIdAsync(id);
            
            if (phoneType == null)
            {
                return NotFound();
            }

            return Ok(phoneType);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error retrieving phone type {PhoneTypeId}", id);
            return StatusCode(500, "An error occurred while retrieving the phone type");
        }
    }

    [Authorize]
    [HttpPost("[action]")]
    public async Task<ActionResult<PhoneTypeDto>> CreatePhoneType(CreatePhoneTypeDto phoneTypeDto)
    {
        try
        {
            var currentUser = User.Identity?.Name ?? "System";
            var createdPhoneType = await phoneTypeService.CreatePhoneTypeAsync(phoneTypeDto, currentUser);
            return CreatedAtAction(nameof(GetPhoneType), new { id = createdPhoneType.PhoneTypeId }, createdPhoneType);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error creating phone type");
            return StatusCode(500, "An error occurred while creating the phone type");
        }
    }

    [Authorize]
    [HttpPut("[action]/{id}")]
    public async Task<IActionResult> UpdatePhoneType(int id, UpdatePhoneTypeDto phoneTypeDto)
    {
        try
        {
            var currentUser = User.Identity?.Name ?? "System";
            var updatedPhoneType = await phoneTypeService.UpdatePhoneTypeAsync(id, phoneTypeDto, currentUser);
            
            if (updatedPhoneType == null)
            {
                return NotFound();
            }

            return Ok(updatedPhoneType);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error updating phone type {PhoneTypeId}", id);
            return StatusCode(500, "An error occurred while updating the phone type");
        }
    }

    [Authorize]
    [HttpDelete("[action]/{id}")]
    public async Task<IActionResult> DeletePhoneType(int id)
    {
        try
        {
            var currentUser = User.Identity?.Name ?? "System";
            var result = await phoneTypeService.DeletePhoneTypeAsync(id, currentUser);
            
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error deleting phone type {PhoneTypeId}", id);
            return StatusCode(500, "An error occurred while deleting the phone type");
        }
    }
} 