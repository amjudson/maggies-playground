using Microsoft.AspNetCore.Mvc;
using MaggiesPlaygroundApi.Models;
using MaggiesPlaygroundApi.Services;

namespace MaggiesPlaygroundApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PersonEmailController : ControllerBase
{
    private readonly IPersonEmailService service;

    public PersonEmailController(IPersonEmailService service)
    {
        this.service = service;
    }

    [HttpGet("[action]")]
    public async Task<ActionResult<IEnumerable<PersonEmailDto>>> GetAll()
    {
        var personEmails = await service.GetAllAsync();
        return Ok(personEmails);
    }

    [HttpGet("[action]/{id:guid}")]
    public async Task<ActionResult<PersonEmailDto>> GetById(Guid id)
    {
        var personEmail = await service.GetByIdAsync(id);
        
        if (personEmail == null)
            return NotFound();

        return Ok(personEmail);
    }

    [HttpGet("[action]/person/{personId:guid}")]
    public async Task<ActionResult<IEnumerable<PersonEmailDto>>> GetByPersonId(Guid personId)
    {
        var personEmails = await service.GetByPersonIdAsync(personId);
        return Ok(personEmails);
    }

    [HttpGet("[action]/email/{emailId:guid}")]
    public async Task<ActionResult<IEnumerable<PersonEmailDto>>> GetByEmailId(Guid emailId)
    {
        var personEmails = await service.GetByEmailIdAsync(emailId);
        return Ok(personEmails);
    }

    [HttpPost("[action]")]
    public async Task<ActionResult<PersonEmailDto>> Create(PersonEmailDto personEmailDto)
    {
        try
        {
            var createdPersonEmail = await service.CreateAsync(personEmailDto);
            return CreatedAtAction(nameof(GetById), new { id = createdPersonEmail.PersonEmailId }, createdPersonEmail);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("[action]/{id:guid}")]
    public async Task<ActionResult<PersonEmailDto>> Update(Guid id, PersonEmailDto personEmailDto)
    {
        try
        {
            var updatedPersonEmail = await service.UpdateAsync(id, personEmailDto);
            return Ok(updatedPersonEmail);
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