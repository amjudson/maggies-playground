using Microsoft.AspNetCore.Mvc;
using MaggiesPlaygroundApi.Models;
using MaggiesPlaygroundApi.Services;

namespace MaggiesPlaygroundApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientAddressController : ControllerBase
{
    private readonly IClientAddressService service;

    public ClientAddressController(IClientAddressService service)
    {
        this.service = service;
    }

    [HttpGet("[action]")]
    public async Task<ActionResult<IEnumerable<ClientAddressDto>>> GetAll()
    {
        var clientAddresses = await service.GetAllAsync();
        return Ok(clientAddresses);
    }

    [HttpGet("[action]/{id:guid}")]
    public async Task<ActionResult<ClientAddressDto>> GetById(Guid id)
    {
        var clientAddress = await service.GetByIdAsync(id);
        
        if (clientAddress == null)
            return NotFound();

        return Ok(clientAddress);
    }

    [HttpGet("[action]/client/{clientId:guid}")]
    public async Task<ActionResult<IEnumerable<ClientAddressDto>>> GetByClientId(Guid clientId)
    {
        var clientAddresses = await service.GetByClientIdAsync(clientId);
        return Ok(clientAddresses);
    }

    [HttpGet("[action]/address/{addressId:guid}")]
    public async Task<ActionResult<IEnumerable<ClientAddressDto>>> GetByAddressId(Guid addressId)
    {
        var clientAddresses = await service.GetByAddressIdAsync(addressId);
        return Ok(clientAddresses);
    }

    [HttpPost("[action]")]
    public async Task<ActionResult<ClientAddressDto>> Create(ClientAddressDto clientAddressDto)
    {
        try
        {
            var createdClientAddress = await service.CreateAsync(clientAddressDto);
            return CreatedAtAction(nameof(GetById), new { id = createdClientAddress.ClientAddressId }, createdClientAddress);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("[action]/{id:guid}")]
    public async Task<ActionResult<ClientAddressDto>> Update(Guid id, ClientAddressDto clientAddressDto)
    {
        try
        {
            var updatedClientAddress = await service.UpdateAsync(id, clientAddressDto);
            return Ok(updatedClientAddress);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("[action]/{id:guid}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        var deleted = await service.DeleteAsync(id);
        
        if (!deleted)
            return NotFound();

        return NoContent();
    }
} 