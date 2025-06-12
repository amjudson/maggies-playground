using MaggiesPlaygroundApi.Data;
using MaggiesPlaygroundApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MaggiesPlaygroundApi.Services;

public class ClientTypeService : IClientTypeService
{
    private readonly ApplicationDbContext _context;

    public ClientTypeService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<(IEnumerable<ClientTypeDto> ClientTypes, int TotalCount)> GetClientTypesAsync(ClientTypeQueryParameters queryParams)
    {
        var query = _context.ClientTypes.AsQueryable();

        // Apply filters
        if (!string.IsNullOrWhiteSpace(queryParams.SearchTerm))
        {
            query = query.Where(ct => ct.Name.Contains(queryParams.SearchTerm));
        }

        if (queryParams.Active.HasValue)
        {
            query = query.Where(ct => ct.Active == queryParams.Active.Value);
        }

        // Apply sorting
        if (!string.IsNullOrWhiteSpace(queryParams.SortBy))
        {
            query = queryParams.SortBy.ToLower() switch
            {
                "name" => queryParams.SortDescending 
                    ? query.OrderByDescending(ct => ct.Name)
                    : query.OrderBy(ct => ct.Name),
                "createddate" => queryParams.SortDescending
                    ? query.OrderByDescending(ct => ct.CreatedDate)
                    : query.OrderBy(ct => ct.CreatedDate),
                _ => query.OrderBy(ct => ct.Name)
            };
        }
        else
        {
            query = query.OrderBy(ct => ct.Name);
        }

        // Get total count before pagination
        var totalCount = await query.CountAsync();

        // Apply pagination
        var clientTypes = await query
            .Skip((queryParams.PageNumber - 1) * queryParams.PageSize)
            .Take(queryParams.PageSize)
            .Select(ct => new ClientTypeDto
            {
                ClientTypeId = ct.ClientTypeId,
                Name = ct.Name,
                Active = ct.Active,
                CreatedDate = ct.CreatedDate,
                EnteredBy = ct.EnteredBy
            })
            .ToListAsync();

        return (clientTypes, totalCount);
    }

    public async Task<ClientTypeDto?> GetClientTypeByIdAsync(int id)
    {
        var clientType = await _context.ClientTypes.FindAsync(id);
        
        if (clientType == null)
        {
            return null;
        }

        return new ClientTypeDto
        {
            ClientTypeId = clientType.ClientTypeId,
            Name = clientType.Name,
            Active = clientType.Active,
            CreatedDate = clientType.CreatedDate,
            EnteredBy = clientType.EnteredBy
        };
    }

    public async Task<ClientTypeDto> CreateClientTypeAsync(CreateClientTypeDto clientTypeDto, string currentUser)
    {
        var clientType = new ClientType
        {
            Name = clientTypeDto.Name,
            Active = clientTypeDto.Active,
            CreatedDate = DateTime.UtcNow,
            EnteredBy = currentUser
        };

        _context.ClientTypes.Add(clientType);
        await _context.SaveChangesAsync();

        return new ClientTypeDto
        {
            ClientTypeId = clientType.ClientTypeId,
            Name = clientType.Name,
            Active = clientType.Active,
            CreatedDate = clientType.CreatedDate,
            EnteredBy = clientType.EnteredBy
        };
    }

    public async Task<ClientTypeDto?> UpdateClientTypeAsync(int id, UpdateClientTypeDto clientTypeDto, string currentUser)
    {
        var existingClientType = await _context.ClientTypes.FindAsync(id);
        
        if (existingClientType == null)
        {
            return null;
        }

        existingClientType.Name = clientTypeDto.Name;
        existingClientType.Active = clientTypeDto.Active;
        existingClientType.EnteredBy = currentUser;

        await _context.SaveChangesAsync();

        return new ClientTypeDto
        {
            ClientTypeId = existingClientType.ClientTypeId,
            Name = existingClientType.Name,
            Active = existingClientType.Active,
            CreatedDate = existingClientType.CreatedDate,
            EnteredBy = existingClientType.EnteredBy
        };
    }

    public async Task<bool> DeleteClientTypeAsync(int id, string currentUser)
    {
        var clientType = await _context.ClientTypes.FindAsync(id);
        
        if (clientType == null)
        {
            return false;
        }

        // Check if the client type is in use
        var inUse = await _context.Clients.AnyAsync(c => c.ClientTypeId == id);
        if (inUse)
        {
            return false;
        }

        _context.ClientTypes.Remove(clientType);
        await _context.SaveChangesAsync();
        
        return true;
    }
} 