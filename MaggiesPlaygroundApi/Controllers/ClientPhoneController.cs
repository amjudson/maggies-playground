using Microsoft.AspNetCore.Mvc;
using MaggiesPlaygroundApi.Models;
using MaggiesPlaygroundApi.Services;

namespace MaggiesPlaygroundApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientPhoneController : ControllerBase
{
    private readonly IClientPhoneService _service;

    public ClientPhoneController(IClientPhoneService service)
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

    [HttpGet("ByClient/{clientId}")]
    public async Task<IActionResult> GetByClientId(Guid clientId)
    {
        var result = await _service.GetByClientIdAsync(clientId);
        return Ok(result);
    }

    [HttpGet("ByPhone/{phoneId}")]
    public async Task<IActionResult> GetByPhoneId(Guid phoneId)
    {
        var result = await _service.GetByPhoneIdAsync(phoneId);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ClientPhoneDto dto)
    {
        var enteredBy = User?.Identity?.Name ?? "System";
        var created = await _service.CreateAsync(dto, enteredBy);
        return CreatedAtAction(nameof(GetById), new { id = created.ClientPhoneId }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] ClientPhoneDto dto)
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