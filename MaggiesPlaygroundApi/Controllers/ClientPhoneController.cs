using Microsoft.AspNetCore.Mvc;
using MaggiesPlaygroundApi.Models;
using MaggiesPlaygroundApi.Services;

namespace MaggiesPlaygroundApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientPhoneController : ControllerBase
{
    private readonly IClientPhoneService service;

    public ClientPhoneController(IClientPhoneService service)
    {
        this.service = service;
    }

    [HttpGet("[action]")]
    public async Task<ActionResult<IEnumerable<ClientPhoneDto>>> GetAll()
    {
        var clientPhones = await service.GetAllAsync();
        return Ok(clientPhones);
    }

    [HttpGet("[action]/{id:guid}")]
    public async Task<ActionResult<ClientPhoneDto>> GetById(Guid id)
    {
        var clientPhone = await service.GetByIdAsync(id);
        
        if (clientPhone == null)
            return NotFound();

        return Ok(clientPhone);
    }

    [HttpGet("[action]/client/{clientId:guid}")]
    public async Task<ActionResult<IEnumerable<ClientPhoneDto>>> GetByClientId(Guid clientId)
    {
        var clientPhones = await service.GetByClientIdAsync(clientId);
        return Ok(clientPhones);
    }

    [HttpGet("[action]/phone/{phoneId:guid}")]
    public async Task<ActionResult<IEnumerable<ClientPhoneDto>>> GetByPhoneId(Guid phoneId)
    {
        var clientPhones = await service.GetByPhoneIdAsync(phoneId);
        return Ok(clientPhones);
    }

    [HttpPost("[action]")]
    public async Task<ActionResult<ClientPhoneDto>> Create(ClientPhoneDto clientPhoneDto)
    {
        try
        {
            var createdClientPhone = await service.CreateAsync(clientPhoneDto);
            return CreatedAtAction(nameof(GetById), new { id = createdClientPhone.ClientPhoneId }, createdClientPhone);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("[action]/{id:guid}")]
    public async Task<ActionResult<ClientPhoneDto>> Update(Guid id, ClientPhoneDto clientPhoneDto)
    {
        try
        {
            var updatedClientPhone = await service.UpdateAsync(id, clientPhoneDto);
            return Ok(updatedClientPhone);
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