using Microsoft.AspNetCore.Mvc;
using MaggiesPlaygroundApi.Models;
using MaggiesPlaygroundApi.Services;

namespace MaggiesPlaygroundApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PersonPhoneController : ControllerBase
{
    private readonly IPersonPhoneService service;

    public PersonPhoneController(IPersonPhoneService service)
    {
        this.service = service;
    }

    [HttpGet("[action]")]
    public async Task<ActionResult<IEnumerable<PersonPhoneDto>>> GetAll()
    {
        var personPhones = await service.GetAllAsync();
        return Ok(personPhones);
    }

    [HttpGet("[action]/{id:guid}")]
    public async Task<ActionResult<PersonPhoneDto>> GetById(Guid id)
    {
        var personPhone = await service.GetByIdAsync(id);
        
        if (personPhone == null)
            return NotFound();

        return Ok(personPhone);
    }

    [HttpGet("[action]/person/{personId:guid}")]
    public async Task<ActionResult<IEnumerable<PersonPhoneDto>>> GetByPersonId(Guid personId)
    {
        var personPhones = await service.GetByPersonIdAsync(personId);
        return Ok(personPhones);
    }

    [HttpGet("[action]/phone/{phoneId:guid}")]
    public async Task<ActionResult<IEnumerable<PersonPhoneDto>>> GetByPhoneId(Guid phoneId)
    {
        var personPhones = await service.GetByPhoneIdAsync(phoneId);
        return Ok(personPhones);
    }

    [HttpPost("[action]")]
    public async Task<ActionResult<PersonPhoneDto>> Create(PersonPhoneDto personPhoneDto)
    {
        try
        {
            var createdPersonPhone = await service.CreateAsync(personPhoneDto);
            return CreatedAtAction(nameof(GetById), new { id = createdPersonPhone.PersonPhoneId }, createdPersonPhone);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("[action]/{id:guid}")]
    public async Task<ActionResult<PersonPhoneDto>> Update(Guid id, PersonPhoneDto personPhoneDto)
    {
        try
        {
            var updatedPersonPhone = await service.UpdateAsync(id, personPhoneDto);
            return Ok(updatedPersonPhone);
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