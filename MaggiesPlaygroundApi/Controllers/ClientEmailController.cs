using Microsoft.AspNetCore.Mvc;
using MaggiesPlaygroundApi.Models;
using MaggiesPlaygroundApi.Services;

namespace MaggiesPlaygroundApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientEmailController : ControllerBase
{
    private readonly IClientEmailService service;

    public ClientEmailController(IClientEmailService service)
    {
        this.service = service;
    }

    [HttpGet("[action]")]
    public async Task<ActionResult<IEnumerable<ClientEmailDto>>> GetAll()
    {
        var clientEmails = await service.GetAllAsync();
        return Ok(clientEmails);
    }

    [HttpGet("[action]/{id:guid}")]
    public async Task<ActionResult<ClientEmailDto>> GetById(Guid id)
    {
        var clientEmail = await service.GetByIdAsync(id);
        
        if (clientEmail == null)
            return NotFound();

        return Ok(clientEmail);
    }

    [HttpGet("[action]/client/{clientId:guid}")]
    public async Task<ActionResult<IEnumerable<ClientEmailDto>>> GetByClientId(Guid clientId)
    {
        var clientEmails = await service.GetByClientIdAsync(clientId);
        return Ok(clientEmails);
    }

    [HttpGet("[action]/email/{emailId:guid}")]
    public async Task<ActionResult<IEnumerable<ClientEmailDto>>> GetByEmailId(Guid emailId)
    {
        var clientEmails = await service.GetByEmailIdAsync(emailId);
        return Ok(clientEmails);
    }

    [HttpPost("[action]")]
    public async Task<ActionResult<ClientEmailDto>> Create(ClientEmailDto clientEmailDto)
    {
        try
        {
            var createdClientEmail = await service.CreateAsync(clientEmailDto);
            return CreatedAtAction(nameof(GetById), new { id = createdClientEmail.ClientEmailId }, createdClientEmail);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("[action]/{id:guid}")]
    public async Task<ActionResult<ClientEmailDto>> Update(Guid id, ClientEmailDto clientEmailDto)
    {
        try
        {
            var updatedClientEmail = await service.UpdateAsync(id, clientEmailDto);
            return Ok(updatedClientEmail);
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