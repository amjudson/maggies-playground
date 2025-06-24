using MaggiesPlaygroundApi.Models;
using MaggiesPlaygroundApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MaggiesPlaygroundApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ClientTypesController : ControllerBase
{
    private readonly IClientTypeService clientTypeService;
    private readonly ILogger<ClientTypesController> logger;

    public ClientTypesController(IClientTypeService clientTypeService, ILogger<ClientTypesController> logger)
    {
        this.clientTypeService = clientTypeService;
        this.logger = logger;
    }

    [HttpGet("[action]")]
    public async Task<ActionResult<IEnumerable<ClientTypeDto>>> GetAll([FromQuery] int page = 1, [FromQuery] int pageSize = 10, [FromQuery] string? searchTerm = null)
    {
        try
        {
            var clientTypes = await clientTypeService.GetAllAsync(page, pageSize, searchTerm);
            return Ok(clientTypes);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error retrieving client types");
            return StatusCode(500, "An error occurred while retrieving client types");
        }
    }

    [HttpGet("[action]/{id:int}")]
    public async Task<ActionResult<ClientTypeDto>> GetById(int id)
    {
        try
        {
            var clientType = await clientTypeService.GetByIdAsync(id);

            if (clientType == null)
            {
                return NotFound();
            }

            return Ok(clientType);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error retrieving client type {ClientTypeId}", id);
            return StatusCode(500, "An error occurred while retrieving the client type");
        }
    }

    [HttpPost("[action]")]
    public async Task<ActionResult<ClientTypeDto>> Create(ClientTypeDto clientTypeDto)
    {
        try
        {
            var createdClientType = await clientTypeService.CreateAsync(clientTypeDto);

            return CreatedAtAction(
                nameof(GetById),
                new { id = createdClientType.ClientTypeId },
                createdClientType);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error creating client type");
            return StatusCode(500, "An error occurred while creating the client type");
        }
    }

    [HttpPut("[action]/{id:int}")]
    public async Task<ActionResult<ClientTypeDto>> Update(int id, ClientTypeDto clientTypeDto)
    {
        try
        {
            var updatedClientType = await clientTypeService.UpdateAsync(id, clientTypeDto);
            return Ok(updatedClientType);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error updating client type {ClientTypeId}", id);
            return StatusCode(500, "An error occurred while updating the client type");
        }
    }

    [HttpDelete("[action]/{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
        try
        {
            var result = await clientTypeService.DeleteAsync(id);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error deleting client type {ClientTypeId}", id);
            return StatusCode(500, "An error occurred while deleting the client type");
        }
    }
} 