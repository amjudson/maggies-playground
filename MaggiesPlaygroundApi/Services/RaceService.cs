using MaggiesPlaygroundApi.Data;
using MaggiesPlaygroundApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MaggiesPlaygroundApi.Services;

public class RaceService : IRaceService
{
    private readonly ApplicationDbContext context;

    public RaceService(ApplicationDbContext context)
    {
        this.context = context;
    }

    public async Task<(IEnumerable<RaceDto> Races, int TotalCount)> GetRacesAsync(RaceQueryParameters queryParams)
    {
        var query = context.Races.AsQueryable();

        // Apply filters
        if (!string.IsNullOrWhiteSpace(queryParams.SearchTerm))
        {
            query = query.Where(r => r.Name.Contains(queryParams.SearchTerm) || r.Description.Contains(queryParams.SearchTerm));
        }

        // Apply sorting
        if (!string.IsNullOrWhiteSpace(queryParams.SortBy))
        {
            query = queryParams.SortBy.ToLower() switch
            {
                "name" => queryParams.SortDescending 
                    ? query.OrderByDescending(r => r.Name)
                    : query.OrderBy(r => r.Name),
                "description" => queryParams.SortDescending
                    ? query.OrderByDescending(r => r.Description)
                    : query.OrderBy(r => r.Description),
                "createddate" => queryParams.SortDescending
                    ? query.OrderByDescending(r => r.CreatedDate)
                    : query.OrderBy(r => r.CreatedDate),
                _ => query.OrderBy(r => r.Name)
            };
        }
        else
        {
            query = query.OrderBy(r => r.Name);
        }

        // Get total count before pagination
        var totalCount = await query.CountAsync();

        // Apply pagination
        var races = await query
            .Skip((queryParams.PageNumber - 1) * queryParams.PageSize)
            .Take(queryParams.PageSize)
            .Select(r => new RaceDto
            {
                RaceId = r.RaceId,
                Name = r.Name,
                Description = r.Description,
                CreatedDate = r.CreatedDate,
                EnteredBy = r.EnteredBy
            })
            .ToListAsync();

        return (races, totalCount);
    }

    public async Task<RaceDto?> GetRaceByIdAsync(int id)
    {
        var race = await context.Races.FindAsync(id);
        
        if (race == null)
        {
            return null;
        }

        return new RaceDto
        {
            RaceId = race.RaceId,
            Name = race.Name,
            Description = race.Description,
            CreatedDate = race.CreatedDate,
            EnteredBy = race.EnteredBy
        };
    }

    public async Task<RaceDto> CreateRaceAsync(CreateRaceDto raceDto, string currentUser)
    {
        var race = new Race
        {
            Name = raceDto.Name,
            Description = raceDto.Description,
            CreatedDate = DateTime.UtcNow,
            EnteredBy = currentUser
        };

        context.Races.Add(race);
        await context.SaveChangesAsync();

        return new RaceDto
        {
            RaceId = race.RaceId,
            Name = race.Name,
            Description = race.Description,
            CreatedDate = race.CreatedDate,
            EnteredBy = race.EnteredBy
        };
    }

    public async Task<RaceDto?> UpdateRaceAsync(int id, UpdateRaceDto raceDto, string currentUser)
    {
        var existingRace = await context.Races.FindAsync(id);
        
        if (existingRace == null)
        {
            return null;
        }

        existingRace.Name = raceDto.Name;
        existingRace.Description = raceDto.Description;
        existingRace.EnteredBy = currentUser;

        await context.SaveChangesAsync();

        return new RaceDto
        {
            RaceId = existingRace.RaceId,
            Name = existingRace.Name,
            Description = existingRace.Description,
            CreatedDate = existingRace.CreatedDate,
            EnteredBy = existingRace.EnteredBy
        };
    }

    public async Task<bool> DeleteRaceAsync(int id, string currentUser)
    {
        var race = await context.Races.FindAsync(id);
        
        if (race == null)
        {
            return false;
        }

        context.Races.Remove(race);
        await context.SaveChangesAsync();
        
        return true;
    }
} 