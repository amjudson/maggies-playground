using MaggiesPlaygroundApi.Models;
using MaggiesPlaygroundApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MaggiesPlaygroundApi.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class PeopleController(IPersonService personService) : ControllerBase
{
    [HttpGet("[action]")]
    public async Task<ActionResult<IEnumerable<PersonDto>>> GetPeople([FromQuery] PersonQueryParameters queryParams)
    {
        var (people, totalCount) = await personService.GetPeopleAsync(queryParams);
        Response.Headers.Append("X-Total-Count", totalCount.ToString());
        return Ok(people);
    }

    [HttpGet("[action]/{id}")]
    public async Task<ActionResult<PersonDto>> GetPerson(Guid id)
    {
        var person = await personService.GetPersonByIdAsync(id);
        if (person == null)
        {
            return NotFound();
        }
        return Ok(person);
    }

    [HttpPost("[action]")]
    public async Task<ActionResult<PersonDto>> CreatePerson(CreatePersonDto personDto)
    {
        var currentUser = User.Identity?.Name ?? "System";
        var person = await personService.CreatePersonAsync(personDto, currentUser);
        return CreatedAtAction(nameof(GetPerson), new { id = person.PersonId }, person);
    }

    [HttpPut("[action]/{id}")]
    public async Task<ActionResult<PersonDto>> UpdatePerson(Guid id, UpdatePersonDto personDto)
    {
        var currentUser = User.Identity?.Name ?? "System";
        var person = await personService.UpdatePersonAsync(id, personDto, currentUser);
        if (person == null)
        {
            return NotFound();
        }
        return Ok(person);
    }

    [HttpDelete("[action]/{id}")]
    public async Task<ActionResult> DeletePerson(Guid id)
    {
        var currentUser = User.Identity?.Name ?? "System";
        var result = await personService.DeletePersonAsync(id, currentUser);
        if (!result)
        {
            return NotFound();
        }
        return NoContent();
    }
} 