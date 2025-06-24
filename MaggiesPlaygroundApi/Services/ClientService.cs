using MaggiesPlaygroundApi.Data;
using MaggiesPlaygroundApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MaggiesPlaygroundApi.Services;

public class ClientService : IClientService
{
    private readonly ApplicationDbContext context;

    public ClientService(ApplicationDbContext context)
    {
        this.context = context;
    }

    public async Task<IEnumerable<ClientDto>> GetAllAsync(int page = 1, int pageSize = 10, string? searchTerm = null)
    {
        var query = context.Clients.AsQueryable();

        if (!string.IsNullOrWhiteSpace(searchTerm))
        {
            query = query.Where(c => c.ClientName.Contains(searchTerm));
        }

        var totalCount = await query.CountAsync();
        var clients = await query
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return clients.Select(c => new ClientDto
        {
            ClientId = c.ClientId,
            ClientName = c.ClientName,
            ClientTypeId = c.ClientTypeId,
            Active = c.Active,
            CreatedDate = c.CreatedDate,
            EnteredBy = c.EnteredBy
        });
    }

    public async Task<ClientDto?> GetByIdAsync(Guid id)
    {
        var client = await context.Clients.FindAsync(id);
        if (client == null)
            return null;

        return new ClientDto
        {
            ClientId = client.ClientId,
            ClientName = client.ClientName,
            ClientTypeId = client.ClientTypeId,
            Active = client.Active,
            CreatedDate = client.CreatedDate,
            EnteredBy = client.EnteredBy
        };
    }

    public async Task<ClientDto> CreateAsync(ClientDto clientDto)
    {
        var client = new Client
        {
            ClientId = Guid.NewGuid(),
            ClientName = clientDto.ClientName,
            ClientTypeId = clientDto.ClientTypeId,
            Active = true,
            CreatedDate = DateTime.UtcNow,
            EnteredBy = clientDto.EnteredBy
        };

        context.Clients.Add(client);
        await context.SaveChangesAsync();

        return await GetByIdAsync(client.ClientId) ?? clientDto;
    }

    public async Task<ClientDto> UpdateAsync(Guid id, ClientDto clientDto)
    {
        var existingClient = await context.Clients.FindAsync(id);
        if (existingClient == null)
            throw new ArgumentException("Client not found");

        existingClient.ClientName = clientDto.ClientName;
        existingClient.ClientTypeId = clientDto.ClientTypeId;
        existingClient.Active = clientDto.Active;
        existingClient.EnteredBy = clientDto.EnteredBy;

        await context.SaveChangesAsync();

        return await GetByIdAsync(id) ?? clientDto;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var client = await context.Clients.FindAsync(id);
        if (client == null)
            return false;

        context.Clients.Remove(client);
        await context.SaveChangesAsync();

        return true;
    }
} 