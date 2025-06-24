using Microsoft.AspNetCore.Mvc;
using MaggiesPlaygroundApi.Models;
using MaggiesPlaygroundApi.Services;

namespace MaggiesPlaygroundApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PersonAddressController : ControllerBase
{
    private readonly IPersonAddressService _service;

    public PersonAddressController(IPersonAddressService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _service.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _service.GetByIdAsync(id);
        if (result == null) return NotFound();
        return Ok(result);
    }

    [HttpGet("ByPerson/{personId}")]
    public async Task<IActionResult> GetByPersonId(Guid personId)
    {
        var result = await _service.GetByPersonIdAsync(personId);
        return Ok(result);
    }

    [HttpGet("ByAddress/{addressId}")]
    public async Task<IActionResult> GetByAddressId(Guid addressId)
    {
        var result = await _service.GetByAddressIdAsync(addressId);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] PersonAddressDto dto)
    {
        var enteredBy = User?.Identity?.Name ?? "System";
        var created = await _service.CreateAsync(dto, enteredBy);
        return CreatedAtAction(nameof(GetById), new { id = created.PersonAddressId }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] PersonAddressDto dto)
    {
        var enteredBy = User?.Identity?.Name ?? "System";
        var updated = await _service.UpdateAsync(id, dto, enteredBy);
        return Ok(updated);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deleted = await _service.DeleteAsync(id);
        if (!deleted) return NotFound();
        return NoContent();
    }
} 