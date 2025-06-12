using MaggiesPlaygroundApi.Data;
using MaggiesPlaygroundApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MaggiesPlaygroundApi.Services;

public class ClientService : IClientService
{
    private readonly ApplicationDbContext _context;

    public ClientService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<(IEnumerable<ClientDto> Clients, int TotalCount)> GetClientsAsync(ClientQueryParameters queryParams)
    {
        var query = _context.Clients.AsQueryable();

        // Apply filters
        if (!string.IsNullOrWhiteSpace(queryParams.SearchTerm))
        {
            query = query.Where(c => c.ClientName.Contains(queryParams.SearchTerm));
        }

        if (queryParams.Active.HasValue)
        {
            query = query.Where(c => c.Active == queryParams.Active.Value);
        }

        if (queryParams.ClientTypeId.HasValue)
        {
            query = query.Where(c => c.ClientTypeId == queryParams.ClientTypeId.Value);
        }

        // Apply sorting
        if (!string.IsNullOrWhiteSpace(queryParams.SortBy))
        {
            query = queryParams.SortBy.ToLower() switch
            {
                "clientname" => queryParams.SortDescending 
                    ? query.OrderByDescending(c => c.ClientName)
                    : query.OrderBy(c => c.ClientName),
                "createddate" => queryParams.SortDescending
                    ? query.OrderByDescending(c => c.CreatedDate)
                    : query.OrderBy(c => c.CreatedDate),
                "clienttypeid" => queryParams.SortDescending
                    ? query.OrderByDescending(c => c.ClientTypeId)
                    : query.OrderBy(c => c.ClientTypeId),
                _ => query.OrderBy(c => c.ClientName)
            };
        }
        else
        {
            query = query.OrderBy(c => c.ClientName);
        }

        // Get total count before pagination
        var totalCount = await query.CountAsync();

        // Apply pagination
        var clients = await query
            .Skip((queryParams.PageNumber - 1) * queryParams.PageSize)
            .Take(queryParams.PageSize)
            .Select(c => new ClientDto
            {
                ClientId = c.ClientId,
                ClientName = c.ClientName,
                Active = c.Active,
                CreatedDate = c.CreatedDate,
                EnteredBy = c.EnteredBy,
                ClientTypeId = c.ClientTypeId
            })
            .ToListAsync();

        return (clients, totalCount);
    }

    public async Task<ClientDto?> GetClientByIdAsync(Guid id)
    {
        var client = await _context.Clients.FindAsync(id);
        
        if (client == null)
        {
            return null;
        }

        return new ClientDto
        {
            ClientId = client.ClientId,
            ClientName = client.ClientName,
            Active = client.Active,
            CreatedDate = client.CreatedDate,
            EnteredBy = client.EnteredBy,
            ClientTypeId = client.ClientTypeId
        };
    }

    public async Task<ClientDto> CreateClientAsync(CreateClientDto clientDto, string currentUser)
    {
        var client = new Client
        {
            ClientId = Guid.NewGuid(),
            ClientName = clientDto.ClientName,
            Active = clientDto.Active,
            CreatedDate = DateTime.UtcNow,
            EnteredBy = currentUser,
            ClientTypeId = clientDto.ClientTypeId
        };

        _context.Clients.Add(client);
        await _context.SaveChangesAsync();

        return new ClientDto
        {
            ClientId = client.ClientId,
            ClientName = client.ClientName,
            Active = client.Active,
            CreatedDate = client.CreatedDate,
            EnteredBy = client.EnteredBy,
            ClientTypeId = client.ClientTypeId
        };
    }

    public async Task<ClientDto?> UpdateClientAsync(Guid id, UpdateClientDto clientDto, string currentUser)
    {
        var existingClient = await _context.Clients.FindAsync(id);
        
        if (existingClient == null)
        {
            return null;
        }

        existingClient.ClientName = clientDto.ClientName;
        existingClient.Active = clientDto.Active;
        existingClient.EnteredBy = currentUser;
        existingClient.ClientTypeId = clientDto.ClientTypeId;

        await _context.SaveChangesAsync();

        return new ClientDto
        {
            ClientId = existingClient.ClientId,
            ClientName = existingClient.ClientName,
            Active = existingClient.Active,
            CreatedDate = existingClient.CreatedDate,
            EnteredBy = existingClient.EnteredBy,
            ClientTypeId = existingClient.ClientTypeId
        };
    }

    public async Task<bool> DeleteClientAsync(Guid id, string currentUser)
    {
        var client = await _context.Clients.FindAsync(id);
        
        if (client == null)
        {
            return false;
        }

        _context.Clients.Remove(client);
        await _context.SaveChangesAsync();
        
        return true;
    }
} 