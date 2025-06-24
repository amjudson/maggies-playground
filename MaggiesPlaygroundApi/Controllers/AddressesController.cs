using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MaggiesPlaygroundApi.Models;
using MaggiesPlaygroundApi.Services;

namespace MaggiesPlaygroundApi.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class AddressesController : ControllerBase
{
    private readonly IAddressService addressService;
    private readonly ILogger<AddressesController> logger;

    public AddressesController(IAddressService addressService, ILogger<AddressesController> logger)
    {
        this.addressService = addressService;
        this.logger = logger;
    }

    [HttpGet("[action]")]
    public async Task<ActionResult<PaginatedResponseDto<AddressDto>>> GetAddresses([FromQuery] AddressQueryParameters queryParams)
    {
        try
        {
            var (addresses, totalCount) = await addressService.GetAddressesAsync(queryParams);
            
            var response = new PaginatedResponseDto<AddressDto>
            {
                TotalCount = totalCount,
                PageSize = queryParams.PageSize,
                CurrentPage = queryParams.PageNumber,
                Items = addresses
            };
            
            return Ok(response);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error retrieving addresses");
            return StatusCode(500, "An error occurred while retrieving addresses");
        }
    }

    [HttpGet("[action]/{id}")]
    public async Task<ActionResult<AddressDto>> GetAddress(Guid id)
    {
        try
        {
            var address = await addressService.GetAddressByIdAsync(id);
            
            if (address == null)
            {
                return NotFound();
            }

            return Ok(address);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error retrieving address {AddressId}", id);
            return StatusCode(500, "An error occurred while retrieving the address");
        }
    }

    [Authorize]
    [HttpPost("[action]")]
    public async Task<ActionResult<AddressDto>> CreateAddress(CreateAddressDto addressDto)
    {
        try
        {
            var currentUser = User.Identity?.Name ?? "System";
            var createdAddress = await addressService.CreateAddressAsync(addressDto, currentUser);
            return CreatedAtAction(nameof(GetAddress), new { id = createdAddress.AddressId }, createdAddress);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error creating address");
            return StatusCode(500, "An error occurred while creating the address");
        }
    }

    [Authorize]
    [HttpPut("[action]/{id}")]
    public async Task<IActionResult> UpdateAddress(Guid id, UpdateAddressDto addressDto)
    {
        try
        {
            var currentUser = User.Identity?.Name ?? "System";
            var updatedAddress = await addressService.UpdateAddressAsync(id, addressDto, currentUser);
            
            if (updatedAddress == null)
            {
                return NotFound();
            }

            return Ok(updatedAddress);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error updating address {AddressId}", id);
            return StatusCode(500, "An error occurred while updating the address");
        }
    }

    [Authorize]
    [HttpDelete("[action]/{id}")]
    public async Task<IActionResult> DeleteAddress(Guid id)
    {
        try
        {
            var currentUser = User.Identity?.Name ?? "System";
            var result = await addressService.DeleteAddressAsync(id, currentUser);
            
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error deleting address {AddressId}", id);
            return StatusCode(500, "An error occurred while deleting the address");
        }
    }
} 