using Microsoft.AspNetCore.Mvc;
using MaggiesPlaygroundApi.Models;
using MaggiesPlaygroundApi.Services;

namespace MaggiesPlaygroundApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientAddressController : ControllerBase
{
    private readonly IClientAddressService _service;

    public ClientAddressController(IClientAddressService service)
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

    [HttpGet("ByAddress/{addressId}")]
    public async Task<IActionResult> GetByAddressId(Guid addressId)
    {
        var result = await _service.GetByAddressIdAsync(addressId);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ClientAddressDto dto)
    {
        var enteredBy = User?.Identity?.Name ?? "System";
        var created = await _service.CreateAsync(dto, enteredBy);
        return CreatedAtAction(nameof(GetById), new { id = created.ClientAddressId }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] ClientAddressDto dto)
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