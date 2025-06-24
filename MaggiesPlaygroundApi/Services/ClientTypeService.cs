using MaggiesPlaygroundApi.Data;
using MaggiesPlaygroundApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MaggiesPlaygroundApi.Services;

public class ClientTypeService : IClientTypeService
{
    private readonly ApplicationDbContext context;

    public ClientTypeService(ApplicationDbContext context)
    {
        this.context = context;
    }

    public async Task<IEnumerable<ClientTypeDto>> GetAllAsync(int page = 1, int pageSize = 10, string? searchTerm = null)
    {
        var query = context.ClientTypes.AsQueryable();

        if (!string.IsNullOrWhiteSpace(searchTerm))
        {
            query = query.Where(ct => ct.Name.Contains(searchTerm));
        }

        var totalCount = await query.CountAsync();
        var clientTypes = await query
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return clientTypes.Select(ct => new ClientTypeDto
        {
            ClientTypeId = ct.ClientTypeId,
            Name = ct.Name,
            Active = ct.Active,
            CreatedDate = ct.CreatedDate,
            EnteredBy = ct.EnteredBy
        });
    }

    public async Task<ClientTypeDto?> GetByIdAsync(int id)
    {
        var clientType = await context.ClientTypes.FindAsync(id);
        if (clientType == null)
            return null;

        return new ClientTypeDto
        {
            ClientTypeId = clientType.ClientTypeId,
            Name = clientType.Name,
            Active = clientType.Active,
            CreatedDate = clientType.CreatedDate,
            EnteredBy = clientType.EnteredBy
        };
    }

    public async Task<ClientTypeDto> CreateAsync(ClientTypeDto clientTypeDto)
    {
        var clientType = new ClientType
        {
            ClientTypeId = 0, // Will be auto-generated
            Name = clientTypeDto.Name,
            Active = true,
            CreatedDate = DateTime.UtcNow,
            EnteredBy = clientTypeDto.EnteredBy
        };

        context.ClientTypes.Add(clientType);
        await context.SaveChangesAsync();

        return await GetByIdAsync(clientType.ClientTypeId) ?? clientTypeDto;
    }

    public async Task<ClientTypeDto> UpdateAsync(int id, ClientTypeDto clientTypeDto)
    {
        var existingClientType = await context.ClientTypes.FindAsync(id);
        if (existingClientType == null)
            throw new ArgumentException("ClientType not found");

        existingClientType.Name = clientTypeDto.Name;
        existingClientType.Active = clientTypeDto.Active;
        existingClientType.EnteredBy = clientTypeDto.EnteredBy;

        await context.SaveChangesAsync();

        return await GetByIdAsync(id) ?? clientTypeDto;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var clientType = await context.ClientTypes.FindAsync(id);
        if (clientType == null)
            return false;

        // Check if any clients are using this type
        var inUse = await context.Clients.AnyAsync(c => c.ClientTypeId == id);
        if (inUse)
            throw new InvalidOperationException("Cannot delete client type that is in use by clients");

        context.ClientTypes.Remove(clientType);
        await context.SaveChangesAsync();

        return true;
    }
} 