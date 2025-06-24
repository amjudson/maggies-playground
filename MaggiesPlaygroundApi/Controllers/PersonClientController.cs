using Microsoft.AspNetCore.Mvc;
using MaggiesPlaygroundApi.Services;
using MaggiesPlaygroundApi.Models;

namespace MaggiesPlaygroundApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PersonClientController : ControllerBase
{
    private readonly IPersonClientService personClientService;

    public PersonClientController(IPersonClientService personClientService)
    {
        this.personClientService = personClientService;
    }

    [HttpGet("[action]")]
    public async Task<ActionResult<IEnumerable<PersonClientDto>>> GetAll()
    {
        var personClients = await personClientService.GetAllAsync();
        return Ok(personClients);
    }

    [HttpGet("[action]/{personClientId:guid}")]
    public async Task<ActionResult<PersonClientDto>> GetById(Guid personClientId)
    {
        var personClient = await personClientService.GetByIdAsync(personClientId);
        
        if (personClient == null)
            return NotFound();

        return Ok(personClient);
    }

    [HttpGet("[action]/person/{personId:guid}")]
    public async Task<ActionResult<IEnumerable<PersonClientDto>>> GetByPersonId(Guid personId)
    {
        var personClients = await personClientService.GetByPersonIdAsync(personId);
        return Ok(personClients);
    }

    [HttpGet("[action]/client/{clientId:guid}")]
    public async Task<ActionResult<IEnumerable<PersonClientDto>>> GetByClientId(Guid clientId)
    {
        var personClients = await personClientService.GetByClientIdAsync(clientId);
        return Ok(personClients);
    }

    [HttpPost("[action]")]
    public async Task<ActionResult<PersonClientDto>> Create(PersonClientDto personClientDto)
    {
        try
        {
            var createdPersonClient = await personClientService.CreateAsync(personClientDto);
            return CreatedAtAction(nameof(GetById), new { personClientId = createdPersonClient.PersonClientId }, createdPersonClient);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("[action]/{personClientId:guid}")]
    public async Task<ActionResult<PersonClientDto>> Update(Guid personClientId, PersonClientDto personClientDto)
    {
        try
        {
            var updatedPersonClient = await personClientService.UpdateAsync(personClientId, personClientDto);
            return Ok(updatedPersonClient);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("[action]/{personClientId:guid}")]
    public async Task<ActionResult> Delete(Guid personClientId)
    {
        var deleted = await personClientService.DeleteAsync(personClientId);
        
        if (!deleted)
            return NotFound();

        return NoContent();
    }
} 