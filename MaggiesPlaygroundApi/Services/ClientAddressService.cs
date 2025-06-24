using Microsoft.EntityFrameworkCore;
using MaggiesPlaygroundApi.Data;
using MaggiesPlaygroundApi.Models;

namespace MaggiesPlaygroundApi.Services;

public class ClientAddressService : IClientAddressService
{
    private readonly ApplicationDbContext _context;

    public ClientAddressService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ClientAddressDto>> GetAllAsync()
    {
        return await _context.ClientAddresses
            .Include(ca => ca.Client)
            .Include(ca => ca.Address)
            .ThenInclude(a => a!.AddressType)
            .Include(ca => ca.Address)
            .ThenInclude(a => a!.State)
            .Where(ca => ca.Active)
            .Select(ca => new ClientAddressDto
            {
                ClientAddressId = ca.ClientAddressId,
                ClientId = ca.ClientId,
                AddressId = ca.AddressId,
                Active = ca.Active,
                CreatedDate = ca.CreatedDate,
                EnteredBy = ca.EnteredBy,
                Client = ca.Client != null ? new ClientDto
                {
                    ClientId = ca.Client.ClientId,
                    ClientName = ca.Client.ClientName,
                    Active = ca.Client.Active,
                    CreatedDate = ca.Client.CreatedDate,
                    EnteredBy = ca.Client.EnteredBy,
                    ClientTypeId = ca.Client.ClientTypeId
                } : null,
                Address = ca.Address != null ? new AddressDto
                {
                    AddressId = ca.Address.AddressId,
                    AddressLine1 = ca.Address.AddressLine1,
                    AddressLine2 = ca.Address.AddressLine2,
                    City = ca.Address.City,
                    StateId = ca.Address.StateId,
                    Zip = ca.Address.Zip,
                    AddressTypeId = ca.Address.AddressTypeId
                } : null
            })
            .ToListAsync();
    }

    public async Task<ClientAddressDto?> GetByIdAsync(Guid id)
    {
        var clientAddress = await _context.ClientAddresses
            .Include(ca => ca.Client)
            .Include(ca => ca.Address)
            .ThenInclude(a => a!.AddressType)
            .Include(ca => ca.Address)
            .ThenInclude(a => a!.State)
            .FirstOrDefaultAsync(ca => ca.ClientAddressId == id && ca.Active);

        if (clientAddress == null)
            return null;

        return new ClientAddressDto
        {
            ClientAddressId = clientAddress.ClientAddressId,
            ClientId = clientAddress.ClientId,
            AddressId = clientAddress.AddressId,
            Active = clientAddress.Active,
            CreatedDate = clientAddress.CreatedDate,
            EnteredBy = clientAddress.EnteredBy,
            Client = clientAddress.Client != null ? new ClientDto
            {
                ClientId = clientAddress.Client.ClientId,
                ClientName = clientAddress.Client.ClientName,
                Active = clientAddress.Client.Active,
                CreatedDate = clientAddress.Client.CreatedDate,
                EnteredBy = clientAddress.Client.EnteredBy,
                ClientTypeId = clientAddress.Client.ClientTypeId
            } : null,
            Address = clientAddress.Address != null ? new AddressDto
            {
                AddressId = clientAddress.Address.AddressId,
                AddressLine1 = clientAddress.Address.AddressLine1,
                AddressLine2 = clientAddress.Address.AddressLine2,
                City = clientAddress.Address.City,
                StateId = clientAddress.Address.StateId,
                Zip = clientAddress.Address.Zip,
                AddressTypeId = clientAddress.Address.AddressTypeId
            } : null
        };
    }

    public async Task<IEnumerable<ClientAddressDto>> GetByClientIdAsync(Guid clientId)
    {
        return await _context.ClientAddresses
            .Include(ca => ca.Client)
            .Include(ca => ca.Address)
            .ThenInclude(a => a!.AddressType)
            .Include(ca => ca.Address)
            .ThenInclude(a => a!.State)
            .Where(ca => ca.ClientId == clientId && ca.Active)
            .Select(ca => new ClientAddressDto
            {
                ClientAddressId = ca.ClientAddressId,
                ClientId = ca.ClientId,
                AddressId = ca.AddressId,
                Active = ca.Active,
                CreatedDate = ca.CreatedDate,
                EnteredBy = ca.EnteredBy,
                Client = ca.Client != null ? new ClientDto
                {
                    ClientId = ca.Client.ClientId,
                    ClientName = ca.Client.ClientName,
                    Active = ca.Client.Active,
                    CreatedDate = ca.Client.CreatedDate,
                    EnteredBy = ca.Client.EnteredBy,
                    ClientTypeId = ca.Client.ClientTypeId
                } : null,
                Address = ca.Address != null ? new AddressDto
                {
                    AddressId = ca.Address.AddressId,
                    AddressLine1 = ca.Address.AddressLine1,
                    AddressLine2 = ca.Address.AddressLine2,
                    City = ca.Address.City,
                    StateId = ca.Address.StateId,
                    Zip = ca.Address.Zip,
                    AddressTypeId = ca.Address.AddressTypeId
                } : null
            })
            .ToListAsync();
    }

    public async Task<IEnumerable<ClientAddressDto>> GetByAddressIdAsync(Guid addressId)
    {
        return await _context.ClientAddresses
            .Include(ca => ca.Client)
            .Include(ca => ca.Address)
            .ThenInclude(a => a!.AddressType)
            .Include(ca => ca.Address)
            .ThenInclude(a => a!.State)
            .Where(ca => ca.AddressId == addressId && ca.Active)
            .Select(ca => new ClientAddressDto
            {
                ClientAddressId = ca.ClientAddressId,
                ClientId = ca.ClientId,
                AddressId = ca.AddressId,
                Active = ca.Active,
                CreatedDate = ca.CreatedDate,
                EnteredBy = ca.EnteredBy,
                Client = ca.Client != null ? new ClientDto
                {
                    ClientId = ca.Client.ClientId,
                    ClientName = ca.Client.ClientName,
                    Active = ca.Client.Active,
                    CreatedDate = ca.Client.CreatedDate,
                    EnteredBy = ca.Client.EnteredBy,
                    ClientTypeId = ca.Client.ClientTypeId
                } : null,
                Address = ca.Address != null ? new AddressDto
                {
                    AddressId = ca.Address.AddressId,
                    AddressLine1 = ca.Address.AddressLine1,
                    AddressLine2 = ca.Address.AddressLine2,
                    City = ca.Address.City,
                    StateId = ca.Address.StateId,
                    Zip = ca.Address.Zip,
                    AddressTypeId = ca.Address.AddressTypeId
                } : null
            })
            .ToListAsync();
    }

    public async Task<ClientAddressDto> CreateAsync(ClientAddressDto clientAddressDto, string enteredBy)
    {
        var clientAddress = new ClientAddress
        {
            ClientAddressId = Guid.NewGuid(),
            ClientId = clientAddressDto.ClientId,
            AddressId = clientAddressDto.AddressId,
            Active = true,
            CreatedDate = DateTime.UtcNow,
            EnteredBy = enteredBy
        };

        _context.ClientAddresses.Add(clientAddress);
        await _context.SaveChangesAsync();

        return await GetByIdAsync(clientAddress.ClientAddressId) ?? clientAddressDto;
    }

    public async Task<ClientAddressDto> UpdateAsync(Guid id, ClientAddressDto clientAddressDto, string enteredBy)
    {
        var clientAddress = await _context.ClientAddresses.FindAsync(id);
        if (clientAddress == null)
            throw new ArgumentException("ClientAddress not found");

        clientAddress.ClientId = clientAddressDto.ClientId;
        clientAddress.AddressId = clientAddressDto.AddressId;
        clientAddress.Active = clientAddressDto.Active;
        clientAddress.EnteredBy = enteredBy;

        await _context.SaveChangesAsync();

        return await GetByIdAsync(id) ?? clientAddressDto;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var clientAddress = await _context.ClientAddresses.FindAsync(id);
        if (clientAddress == null)
            return false;

        clientAddress.Active = false;
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> ExistsAsync(Guid id)
    {
        return await _context.ClientAddresses.AnyAsync(ca => ca.ClientAddressId == id && ca.Active);
    }
} 