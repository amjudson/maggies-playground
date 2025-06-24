using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MaggiesPlaygroundApi.Models;
using MaggiesPlaygroundApi.Services;

namespace MaggiesPlaygroundApi.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class AddressTypesController : ControllerBase
{
    private readonly IAddressTypeService addressTypeService;
    private readonly ILogger<AddressTypesController> logger;

    public AddressTypesController(IAddressTypeService addressTypeService, ILogger<AddressTypesController> logger)
    {
        this.addressTypeService = addressTypeService;
        this.logger = logger;
    }

    [HttpGet("[action]")]
    public async Task<ActionResult<PaginatedResponseDto<AddressTypeDto>>> GetAddressTypes([FromQuery] AddressTypeQueryParameters queryParams)
    {
        try
        {
            var (addressTypes, totalCount) = await addressTypeService.GetAddressTypesAsync(queryParams);
            
            var response = new PaginatedResponseDto<AddressTypeDto>
            {
                TotalCount = totalCount,
                PageSize = queryParams.PageSize,
                CurrentPage = queryParams.PageNumber,
                Items = addressTypes
            };
            
            return Ok(response);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error retrieving address types");
            return StatusCode(500, "An error occurred while retrieving address types");
        }
    }

    [HttpGet("[action]/{id}")]
    public async Task<ActionResult<AddressTypeDto>> GetAddressType(int id)
    {
        try
        {
            var addressType = await addressTypeService.GetAddressTypeByIdAsync(id);
            
            if (addressType == null)
            {
                return NotFound();
            }

            return Ok(addressType);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error retrieving address type {AddressTypeId}", id);
            return StatusCode(500, "An error occurred while retrieving the address type");
        }
    }

    [Authorize]
    [HttpPost("[action]")]
    public async Task<ActionResult<AddressTypeDto>> CreateAddressType(CreateAddressTypeDto addressTypeDto)
    {
        try
        {
            var currentUser = User.Identity?.Name ?? "System";
            var createdAddressType = await addressTypeService.CreateAddressTypeAsync(addressTypeDto, currentUser);
            return CreatedAtAction(nameof(GetAddressType), new { id = createdAddressType.AddressTypeId }, createdAddressType);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error creating address type");
            return StatusCode(500, "An error occurred while creating the address type");
        }
    }

    [Authorize]
    [HttpPut("[action]/{id}")]
    public async Task<IActionResult> UpdateAddressType(int id, UpdateAddressTypeDto addressTypeDto)
    {
        try
        {
            var currentUser = User.Identity?.Name ?? "System";
            var updatedAddressType = await addressTypeService.UpdateAddressTypeAsync(id, addressTypeDto, currentUser);
            
            if (updatedAddressType == null)
            {
                return NotFound();
            }

            return Ok(updatedAddressType);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error updating address type {AddressTypeId}", id);
            return StatusCode(500, "An error occurred while updating the address type");
        }
    }

    [Authorize]
    [HttpDelete("[action]/{id}")]
    public async Task<IActionResult> DeleteAddressType(int id)
    {
        try
        {
            var currentUser = User.Identity?.Name ?? "System";
            var result = await addressTypeService.DeleteAddressTypeAsync(id, currentUser);
            
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error deleting address type {AddressTypeId}", id);
            return StatusCode(500, "An error occurred while deleting the address type");
        }
    }
} 