using MaggiesPlaygroundApi.Models;
using MaggiesPlaygroundApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MaggiesPlaygroundApi.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class RacesController(IRaceService raceService) : ControllerBase
{
    [HttpGet("[action]")]
    public async Task<ActionResult<IEnumerable<RaceDto>>> GetRaces([FromQuery] RaceQueryParameters queryParams)
    {
        var (races, totalCount) = await raceService.GetRacesAsync(queryParams);
        Response.Headers.Append("X-Total-Count", totalCount.ToString());
        return Ok(races);
    }

    [HttpGet("[action]/{id}")]
    public async Task<ActionResult<RaceDto>> GetRace(int id)
    {
        var race = await raceService.GetRaceByIdAsync(id);
        if (race == null)
        {
            return NotFound();
        }
        return Ok(race);
    }

    [HttpPost("[action]")]
    public async Task<ActionResult<RaceDto>> CreateRace(CreateRaceDto raceDto)
    {
        var currentUser = User.Identity?.Name ?? "System";
        var race = await raceService.CreateRaceAsync(raceDto, currentUser);
        return CreatedAtAction(nameof(GetRace), new { id = race.RaceId }, race);
    }

    [HttpPut("[action]/{id}")]
    public async Task<ActionResult<RaceDto>> UpdateRace(int id, UpdateRaceDto raceDto)
    {
        var currentUser = User.Identity?.Name ?? "System";
        var race = await raceService.UpdateRaceAsync(id, raceDto, currentUser);
        if (race == null)
        {
            return NotFound();
        }
        return Ok(race);
    }

    [HttpDelete("[action]/{id}")]
    public async Task<ActionResult> DeleteRace(int id)
    {
        var currentUser = User.Identity?.Name ?? "System";
        var result = await raceService.DeleteRaceAsync(id, currentUser);
        if (!result)
        {
            return NotFound();
        }
        return NoContent();
    }
} 