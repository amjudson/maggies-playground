using MaggiesPlaygroundApi.Models;
using MaggiesPlaygroundApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MaggiesPlaygroundApi.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class PersonTypesController(IPersonTypeService personTypeService) : ControllerBase
{
    [HttpGet("[action]")]
    public async Task<ActionResult<IEnumerable<PersonTypeDto>>> GetPersonTypes([FromQuery] PersonTypeQueryParameters queryParams)
    {
        var (personTypes, totalCount) = await personTypeService.GetPersonTypesAsync(queryParams);
        Response.Headers.Append("X-Total-Count", totalCount.ToString());
        return Ok(personTypes);
    }

    [HttpGet("[action]/{id}")]
    public async Task<ActionResult<PersonTypeDto>> GetPersonType(int id)
    {
        var personType = await personTypeService.GetPersonTypeByIdAsync(id);
        if (personType == null)
        {
            return NotFound();
        }
        return Ok(personType);
    }

    [HttpPost("[action]")]
    public async Task<ActionResult<PersonTypeDto>> CreatePersonType(CreatePersonTypeDto personTypeDto)
    {
        var currentUser = User.Identity?.Name ?? "System";
        var personType = await personTypeService.CreatePersonTypeAsync(personTypeDto, currentUser);
        return CreatedAtAction(nameof(GetPersonType), new { id = personType.PersonTypeId }, personType);
    }

    [HttpPut("[action]/{id}")]
    public async Task<ActionResult<PersonTypeDto>> UpdatePersonType(int id, UpdatePersonTypeDto personTypeDto)
    {
        var currentUser = User.Identity?.Name ?? "System";
        var personType = await personTypeService.UpdatePersonTypeAsync(id, personTypeDto, currentUser);
        if (personType == null)
        {
            return NotFound();
        }
        return Ok(personType);
    }

    [HttpDelete("[action]/{id}")]
    public async Task<ActionResult> DeletePersonType(int id)
    {
        var currentUser = User.Identity?.Name ?? "System";
        var result = await personTypeService.DeletePersonTypeAsync(id, currentUser);
        if (!result)
        {
            return NotFound();
        }
        return NoContent();
    }
} 