using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MaggiesPlaygroundApi.Models;
using MaggiesPlaygroundApi.Services;

namespace MaggiesPlaygroundApi.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class StatesController : ControllerBase
{
    private readonly IStateService stateService;
    private readonly ILogger<StatesController> logger;

    public StatesController(IStateService stateService, ILogger<StatesController> logger)
    {
        this.stateService = stateService;
        this.logger = logger;
    }

    [HttpGet("[action]")]
    public async Task<ActionResult<PaginatedResponseDto<StateDto>>> GetStates([FromQuery] StateQueryParameters queryParams)
    {
        try
        {
            var (states, totalCount) = await stateService.GetStatesAsync(queryParams);
            
            var response = new PaginatedResponseDto<StateDto>
            {
                TotalCount = totalCount,
                PageSize = queryParams.PageSize,
                CurrentPage = queryParams.PageNumber,
                Items = states
            };
            
            return Ok(response);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error retrieving states");
            return StatusCode(500, "An error occurred while retrieving states");
        }
    }

    [HttpGet("[action]/{id}")]
    public async Task<ActionResult<StateDto>> GetState(int id)
    {
        try
        {
            var state = await stateService.GetStateByIdAsync(id);
            
            if (state == null)
            {
                return NotFound();
            }

            return Ok(state);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error retrieving state {StateId}", id);
            return StatusCode(500, "An error occurred while retrieving the state");
        }
    }

    [Authorize]
    [HttpPost("[action]")]
    public async Task<ActionResult<StateDto>> CreateState(CreateStateDto stateDto)
    {
        try
        {
            var currentUser = User.Identity?.Name ?? "System";
            var createdState = await stateService.CreateStateAsync(stateDto, currentUser);
            return CreatedAtAction(nameof(GetState), new { id = createdState.StateId }, createdState);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error creating state");
            return StatusCode(500, "An error occurred while creating the state");
        }
    }

    [Authorize]
    [HttpPut("[action]/{id}")]
    public async Task<IActionResult> UpdateState(int id, UpdateStateDto stateDto)
    {
        try
        {
            var currentUser = User.Identity?.Name ?? "System";
            var updatedState = await stateService.UpdateStateAsync(id, stateDto, currentUser);
            
            if (updatedState == null)
            {
                return NotFound();
            }

            return Ok(updatedState);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error updating state {StateId}", id);
            return StatusCode(500, "An error occurred while updating the state");
        }
    }

    [Authorize]
    [HttpDelete("[action]/{id}")]
    public async Task<IActionResult> DeleteState(int id)
    {
        try
        {
            var currentUser = User.Identity?.Name ?? "System";
            var result = await stateService.DeleteStateAsync(id, currentUser);
            
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error deleting state {StateId}", id);
            return StatusCode(500, "An error occurred while deleting the state");
        }
    }
} 