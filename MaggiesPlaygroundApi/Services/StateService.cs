using MaggiesPlaygroundApi.Data;
using MaggiesPlaygroundApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MaggiesPlaygroundApi.Services;

public class StateService : IStateService
{
    private readonly ApplicationDbContext context;

    public StateService(ApplicationDbContext context)
    {
        this.context = context;
    }

    public async Task<(IEnumerable<StateDto> States, int TotalCount)> GetStatesAsync(StateQueryParameters queryParams)
    {
        var query = context.States.AsQueryable();

        // Apply filters
        if (!string.IsNullOrWhiteSpace(queryParams.SearchTerm))
        {
            query = query.Where(s => s.Name.Contains(queryParams.SearchTerm) || s.Abbreviation.Contains(queryParams.SearchTerm));
        }

        // Apply sorting
        if (!string.IsNullOrWhiteSpace(queryParams.SortBy))
        {
            query = queryParams.SortBy.ToLower() switch
            {
                "name" => queryParams.SortDescending 
                    ? query.OrderByDescending(s => s.Name)
                    : query.OrderBy(s => s.Name),
                "abbreviation" => queryParams.SortDescending
                    ? query.OrderByDescending(s => s.Abbreviation)
                    : query.OrderBy(s => s.Abbreviation),
                "stateid" => queryParams.SortDescending
                    ? query.OrderByDescending(s => s.StateId)
                    : query.OrderBy(s => s.StateId),
                _ => query.OrderBy(s => s.Name)
            };
        }
        else
        {
            query = query.OrderBy(s => s.Name);
        }

        // Get total count before pagination
        var totalCount = await query.CountAsync();

        // Apply pagination
        var states = await query
            .Skip((queryParams.PageNumber - 1) * queryParams.PageSize)
            .Take(queryParams.PageSize)
            .Select(s => new StateDto
            {
                StateId = s.StateId,
                Abbreviation = s.Abbreviation,
                Name = s.Name
            })
            .ToListAsync();

        return (states, totalCount);
    }

    public async Task<StateDto?> GetStateByIdAsync(int id)
    {
        var state = await context.States.FindAsync(id);
        
        if (state == null)
        {
            return null;
        }

        return new StateDto
        {
            StateId = state.StateId,
            Abbreviation = state.Abbreviation,
            Name = state.Name
        };
    }

    public async Task<StateDto> CreateStateAsync(CreateStateDto stateDto, string currentUser)
    {
        var state = new State
        {
            Abbreviation = stateDto.Abbreviation,
            Name = stateDto.Name
        };

        context.States.Add(state);
        await context.SaveChangesAsync();

        return new StateDto
        {
            StateId = state.StateId,
            Abbreviation = state.Abbreviation,
            Name = state.Name
        };
    }

    public async Task<StateDto?> UpdateStateAsync(int id, UpdateStateDto stateDto, string currentUser)
    {
        var existingState = await context.States.FindAsync(id);
        
        if (existingState == null)
        {
            return null;
        }

        existingState.Abbreviation = stateDto.Abbreviation;
        existingState.Name = stateDto.Name;

        await context.SaveChangesAsync();

        return new StateDto
        {
            StateId = existingState.StateId,
            Abbreviation = existingState.Abbreviation,
            Name = existingState.Name
        };
    }

    public async Task<bool> DeleteStateAsync(int id, string currentUser)
    {
        var state = await context.States.FindAsync(id);
        
        if (state == null)
        {
            return false;
        }

        // Check if state is being used in addresses
        var inUse = await context.Addresses.AnyAsync(a => a.StateId == id);
        if (inUse)
        {
            return false; // Cannot delete state that is being used
        }

        context.States.Remove(state);
        await context.SaveChangesAsync();
        
        return true;
    }
} 