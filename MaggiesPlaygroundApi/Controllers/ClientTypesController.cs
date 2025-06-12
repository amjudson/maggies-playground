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
    public async Task<ActionResult<IEnumerable<ClientTypeDto>>> GetClientTypes([FromQuery] ClientTypeQueryParameters queryParams)
    {
        try
        {
            var (clientTypes, totalCount) = await clientTypeService.GetClientTypesAsync(queryParams);

            Response.Headers.Append("X-Total-Count", totalCount.ToString());
            Response.Headers.Append("X-Pagination", 
                System.Text.Json.JsonSerializer.Serialize(new
                {
                    currentPage = queryParams.PageNumber,
                    pageSize = queryParams.PageSize,
                    totalPages = (int)Math.Ceiling(totalCount / (double)queryParams.PageSize),
                    totalCount
                }));

            return Ok(clientTypes);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error retrieving client types");
            return StatusCode(500, "An error occurred while retrieving client types");
        }
    }

    [HttpGet("[action]/{id}")]
    public async Task<ActionResult<ClientTypeDto>> GetClientType(int id)
    {
        try
        {
            var clientType = await clientTypeService.GetClientTypeByIdAsync(id);

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
    public async Task<ActionResult<ClientTypeDto>> CreateClientType(CreateClientTypeDto clientTypeDto)
    {
        try
        {
            var currentUser = User.FindFirstValue(ClaimTypes.Name) ?? "system";
            
            var createdClientType = await clientTypeService.CreateClientTypeAsync(clientTypeDto, currentUser);

            return CreatedAtAction(
                nameof(GetClientType),
                new { id = createdClientType.ClientTypeId },
                createdClientType);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error creating client type");
            return StatusCode(500, "An error occurred while creating the client type");
        }
    }

    [HttpPut("[action]/{id}")]
    public async Task<ActionResult<ClientTypeDto>> UpdateClientType(int id, UpdateClientTypeDto clientTypeDto)
    {
        try
        {
            var currentUser = User.FindFirstValue(ClaimTypes.Name) ?? "system";
            
            var updatedClientType = await clientTypeService.UpdateClientTypeAsync(id, clientTypeDto, currentUser);

            if (updatedClientType == null)
            {
                return NotFound();
            }

            return Ok(updatedClientType);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error updating client type {ClientTypeId}", id);
            return StatusCode(500, "An error occurred while updating the client type");
        }
    }

    [HttpDelete("[action]/{id}")]
    public async Task<IActionResult> DeleteClientType(int id)
    {
        try
        {
            var currentUser = User.FindFirstValue(ClaimTypes.Name) ?? "system";
            
            var result = await clientTypeService.DeleteClientTypeAsync(id, currentUser);

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