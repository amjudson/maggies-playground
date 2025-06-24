using Microsoft.AspNetCore.Mvc;
using MaggiesPlaygroundApi.Models;
using MaggiesPlaygroundApi.Services;

namespace MaggiesPlaygroundApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PersonEmailController : ControllerBase
{
    private readonly IPersonEmailService _service;

    public PersonEmailController(IPersonEmailService service)
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

    [HttpGet("ByEmail/{emailId}")]
    public async Task<IActionResult> GetByEmailId(Guid emailId)
    {
        var result = await _service.GetByEmailIdAsync(emailId);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] PersonEmailDto dto)
    {
        var enteredBy = User?.Identity?.Name ?? "System";
        var created = await _service.CreateAsync(dto, enteredBy);
        return CreatedAtAction(nameof(GetById), new { id = created.PersonEmailId }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] PersonEmailDto dto)
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