using Microsoft.EntityFrameworkCore;
using MaggiesPlaygroundApi.Data;
using MaggiesPlaygroundApi.Models;

namespace MaggiesPlaygroundApi.Services;

public class ClientAddressService : IClientAddressService
{
    private readonly ApplicationDbContext context;

    public ClientAddressService(ApplicationDbContext context)
    {
        this.context = context;
    }

    public async Task<IEnumerable<ClientAddressDto>> GetAllAsync()
    {
        return await context.ClientAddresses
            .Include(ca => ca.Client)
            .Include(ca => ca.Address)
            .ThenInclude(a => a.State)
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
                    ClientTypeId = ca.Client.ClientTypeId,
                    Active = ca.Client.Active,
                    CreatedDate = ca.Client.CreatedDate,
                    EnteredBy = ca.Client.EnteredBy
                } : null,
                Address = ca.Address != null ? new AddressDto
                {
                    AddressId = ca.Address.AddressId,
                    AddressLine1 = ca.Address.AddressLine1,
                    AddressLine2 = ca.Address.AddressLine2,
                    City = ca.Address.City,
                    StateId = ca.Address.StateId,
                    Zip = ca.Address.Zip,
                    AddressTypeId = ca.Address.AddressTypeId,
                    State = ca.Address.State != null ? new StateDto
                    {
                        StateId = ca.Address.State.StateId,
                        Name = ca.Address.State.Name,
                        Abbreviation = ca.Address.State.Abbreviation
                    } : null
                } : null
            })
            .ToListAsync();
    }

    public async Task<ClientAddressDto?> GetByIdAsync(Guid id)
    {
        var clientAddress = await context.ClientAddresses
            .Include(ca => ca.Client)
            .Include(ca => ca.Address)
            .ThenInclude(a => a.State)
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
                ClientTypeId = clientAddress.Client.ClientTypeId,
                Active = clientAddress.Client.Active,
                CreatedDate = clientAddress.Client.CreatedDate,
                EnteredBy = clientAddress.Client.EnteredBy
            } : null,
            Address = clientAddress.Address != null ? new AddressDto
            {
                AddressId = clientAddress.Address.AddressId,
                AddressLine1 = clientAddress.Address.AddressLine1,
                AddressLine2 = clientAddress.Address.AddressLine2,
                City = clientAddress.Address.City,
                StateId = clientAddress.Address.StateId,
                Zip = clientAddress.Address.Zip,
                AddressTypeId = clientAddress.Address.AddressTypeId,
                State = clientAddress.Address.State != null ? new StateDto
                {
                    StateId = clientAddress.Address.State.StateId,
                    Name = clientAddress.Address.State.Name,
                    Abbreviation = clientAddress.Address.State.Abbreviation
                } : null
            } : null
        };
    }

    public async Task<IEnumerable<ClientAddressDto>> GetByClientIdAsync(Guid clientId)
    {
        return await context.ClientAddresses
            .Include(ca => ca.Client)
            .Include(ca => ca.Address)
            .ThenInclude(a => a.State)
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
                    ClientTypeId = ca.Client.ClientTypeId,
                    Active = ca.Client.Active,
                    CreatedDate = ca.Client.CreatedDate,
                    EnteredBy = ca.Client.EnteredBy
                } : null,
                Address = ca.Address != null ? new AddressDto
                {
                    AddressId = ca.Address.AddressId,
                    AddressLine1 = ca.Address.AddressLine1,
                    AddressLine2 = ca.Address.AddressLine2,
                    City = ca.Address.City,
                    StateId = ca.Address.StateId,
                    Zip = ca.Address.Zip,
                    AddressTypeId = ca.Address.AddressTypeId,
                    State = ca.Address.State != null ? new StateDto
                    {
                        StateId = ca.Address.State.StateId,
                        Name = ca.Address.State.Name,
                        Abbreviation = ca.Address.State.Abbreviation
                    } : null
                } : null
            })
            .ToListAsync();
    }

    public async Task<IEnumerable<ClientAddressDto>> GetByAddressIdAsync(Guid addressId)
    {
        return await context.ClientAddresses
            .Include(ca => ca.Client)
            .Include(ca => ca.Address)
            .ThenInclude(a => a.State)
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
                    ClientTypeId = ca.Client.ClientTypeId,
                    Active = ca.Client.Active,
                    CreatedDate = ca.Client.CreatedDate,
                    EnteredBy = ca.Client.EnteredBy
                } : null,
                Address = ca.Address != null ? new AddressDto
                {
                    AddressId = ca.Address.AddressId,
                    AddressLine1 = ca.Address.AddressLine1,
                    AddressLine2 = ca.Address.AddressLine2,
                    City = ca.Address.City,
                    StateId = ca.Address.StateId,
                    Zip = ca.Address.Zip,
                    AddressTypeId = ca.Address.AddressTypeId,
                    State = ca.Address.State != null ? new StateDto
                    {
                        StateId = ca.Address.State.StateId,
                        Name = ca.Address.State.Name,
                        Abbreviation = ca.Address.State.Abbreviation
                    } : null
                } : null
            })
            .ToListAsync();
    }

    public async Task<ClientAddressDto> CreateAsync(ClientAddressDto clientAddressDto)
    {
        var clientAddress = new ClientAddress
        {
            ClientAddressId = Guid.NewGuid(),
            ClientId = clientAddressDto.ClientId,
            AddressId = clientAddressDto.AddressId,
            Active = true,
            CreatedDate = DateTime.UtcNow,
            EnteredBy = clientAddressDto.EnteredBy
        };

        context.ClientAddresses.Add(clientAddress);
        await context.SaveChangesAsync();

        return await GetByIdAsync(clientAddress.ClientAddressId) ?? clientAddressDto;
    }

    public async Task<ClientAddressDto> UpdateAsync(Guid id, ClientAddressDto clientAddressDto)
    {
        var clientAddress = await context.ClientAddresses.FindAsync(id);
        if (clientAddress == null)
            throw new ArgumentException("ClientAddress not found");

        clientAddress.ClientId = clientAddressDto.ClientId;
        clientAddress.AddressId = clientAddressDto.AddressId;
        clientAddress.EnteredBy = clientAddressDto.EnteredBy;

        await context.SaveChangesAsync();

        return await GetByIdAsync(id) ?? clientAddressDto;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var clientAddress = await context.ClientAddresses.FindAsync(id);
        if (clientAddress == null)
            return false;

        clientAddress.Active = false;
        await context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> ExistsAsync(Guid id)
    {
        return await context.ClientAddresses.AnyAsync(ca => ca.ClientAddressId == id && ca.Active);
    }
} 