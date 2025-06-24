using Microsoft.AspNetCore.Mvc;
using MaggiesPlaygroundApi.Models;
using MaggiesPlaygroundApi.Services;

namespace MaggiesPlaygroundApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PersonPhoneController : ControllerBase
{
    private readonly IPersonPhoneService _service;

    public PersonPhoneController(IPersonPhoneService service)
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

    [HttpGet("ByPhone/{phoneId}")]
    public async Task<IActionResult> GetByPhoneId(Guid phoneId)
    {
        var result = await _service.GetByPhoneIdAsync(phoneId);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] PersonPhoneDto dto)
    {
        var enteredBy = User?.Identity?.Name ?? "System";
        var created = await _service.CreateAsync(dto, enteredBy);
        return CreatedAtAction(nameof(GetById), new { id = created.PersonPhoneId }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] PersonPhoneDto dto)
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