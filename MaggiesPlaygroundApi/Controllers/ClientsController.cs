using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MaggiesPlaygroundApi.Models;
using MaggiesPlaygroundApi.Services;

namespace MaggiesPlaygroundApi.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class ClientsController : ControllerBase
{
    private readonly IClientService clientService;
    private readonly ILogger<ClientsController> logger;

    public ClientsController(IClientService clientService, ILogger<ClientsController> logger)
    {
        this.clientService = clientService;
        this.logger = logger;
    }

    [HttpGet("[action]")]
    public async Task<ActionResult<IEnumerable<ClientDto>>> GetAll([FromQuery] int page = 1, [FromQuery] int pageSize = 10, [FromQuery] string? searchTerm = null)
    {
        try
        {
            var clients = await clientService.GetAllAsync(page, pageSize, searchTerm);
            return Ok(clients);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error retrieving clients");
            return StatusCode(500, "An error occurred while retrieving clients");
        }
    }

    [HttpGet("[action]/{id:guid}")]
    public async Task<ActionResult<ClientDto>> GetById(Guid id)
    {
        try
        {
            var client = await clientService.GetByIdAsync(id);
            
            if (client == null)
            {
                return NotFound();
            }

            return Ok(client);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error retrieving client {ClientId}", id);
            return StatusCode(500, "An error occurred while retrieving the client");
        }
    }

    [HttpPost("[action]")]
    public async Task<ActionResult<ClientDto>> Create(ClientDto clientDto)
    {
        try
        {
            var createdClient = await clientService.CreateAsync(clientDto);
            return CreatedAtAction(nameof(GetById), new { id = createdClient.ClientId }, createdClient);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error creating client");
            return StatusCode(500, "An error occurred while creating the client");
        }
    }

    [HttpPut("[action]/{id:guid}")]
    public async Task<ActionResult<ClientDto>> Update(Guid id, ClientDto clientDto)
    {
        try
        {
            var updatedClient = await clientService.UpdateAsync(id, clientDto);
            return Ok(updatedClient);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error updating client {ClientId}", id);
            return StatusCode(500, "An error occurred while updating the client");
        }
    }

    [HttpDelete("[action]/{id:guid}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        try
        {
            var result = await clientService.DeleteAsync(id);
            
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error deleting client {ClientId}", id);
            return StatusCode(500, "An error occurred while deleting the client");
        }
    }
} 