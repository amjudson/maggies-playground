using Microsoft.AspNetCore.Mvc;
using MaggiesPlaygroundApi.Models;
using MaggiesPlaygroundApi.Services;

namespace MaggiesPlaygroundApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PersonAddressController : ControllerBase
{
    private readonly IPersonAddressService service;

    public PersonAddressController(IPersonAddressService service)
    {
        this.service = service;
    }

    [HttpGet("[action]")]
    public async Task<ActionResult<IEnumerable<PersonAddressDto>>> GetAll()
    {
        var personAddresses = await service.GetAllAsync();
        return Ok(personAddresses);
    }

    [HttpGet("[action]/{id:guid}")]
    public async Task<ActionResult<PersonAddressDto>> GetById(Guid id)
    {
        var personAddress = await service.GetByIdAsync(id);
        
        if (personAddress == null)
            return NotFound();

        return Ok(personAddress);
    }

    [HttpGet("[action]/person/{personId:guid}")]
    public async Task<ActionResult<IEnumerable<PersonAddressDto>>> GetByPersonId(Guid personId)
    {
        var personAddresses = await service.GetByPersonIdAsync(personId);
        return Ok(personAddresses);
    }

    [HttpGet("[action]/address/{addressId:guid}")]
    public async Task<ActionResult<IEnumerable<PersonAddressDto>>> GetByAddressId(Guid addressId)
    {
        var personAddresses = await service.GetByAddressIdAsync(addressId);
        return Ok(personAddresses);
    }

    [HttpPost("[action]")]
    public async Task<ActionResult<PersonAddressDto>> Create(PersonAddressDto personAddressDto)
    {
        try
        {
            var createdPersonAddress = await service.CreateAsync(personAddressDto);
            return CreatedAtAction(nameof(GetById), new { id = createdPersonAddress.PersonAddressId }, createdPersonAddress);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("[action]/{id:guid}")]
    public async Task<ActionResult<PersonAddressDto>> Update(Guid id, PersonAddressDto personAddressDto)
    {
        try
        {
            var updatedPersonAddress = await service.UpdateAsync(id, personAddressDto);
            return Ok(updatedPersonAddress);
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