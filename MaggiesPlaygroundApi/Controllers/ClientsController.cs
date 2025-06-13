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
    public async Task<ActionResult<PaginatedResponseDto<ClientDto>>> GetClients([FromQuery] ClientQueryParameters queryParams)
    {
        try
        {
            var (clients, totalCount) = await clientService.GetClientsAsync(queryParams);
            
            var response = new PaginatedResponseDto<ClientDto>
            {
                TotalCount = totalCount,
                PageSize = queryParams.PageSize,
                CurrentPage = queryParams.PageNumber,
                Items = clients
            };
            
            return Ok(response);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error retrieving clients");
            return StatusCode(500, "An error occurred while retrieving clients");
        }
    }

    [HttpGet("[action]/{id}")]
    public async Task<ActionResult<ClientDto>> GetClient(Guid id)
    {
        try
        {
            var client = await clientService.GetClientByIdAsync(id);
            
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

    [Authorize]
    [HttpPost("[action]")]
    public async Task<ActionResult<ClientDto>> CreateClient(CreateClientDto clientDto)
    {
        try
        {
            var currentUser = User.Identity?.Name ?? "System";
            var createdClient = await clientService.CreateClientAsync(clientDto, currentUser);
            return CreatedAtAction(nameof(GetClient), new { id = createdClient.ClientId }, createdClient);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error creating client");
            return StatusCode(500, "An error occurred while creating the client");
        }
    }

    [Authorize]
    [HttpPut("[action]/{id}")]
    public async Task<IActionResult> UpdateClient(Guid id, UpdateClientDto clientDto)
    {
        try
        {
            var currentUser = User.Identity?.Name ?? "System";
            var updatedClient = await clientService.UpdateClientAsync(id, clientDto, currentUser);
            
            if (updatedClient == null)
            {
                return NotFound();
            }

            return Ok(updatedClient);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error updating client {ClientId}", id);
            return StatusCode(500, "An error occurred while updating the client");
        }
    }

    [Authorize]
    [HttpDelete("[action]/{id}")]
    public async Task<IActionResult> DeleteClient(Guid id)
    {
        try
        {
            var currentUser = User.Identity?.Name ?? "System";
            var result = await clientService.DeleteClientAsync(id, currentUser);
            
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