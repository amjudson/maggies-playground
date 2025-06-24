using Microsoft.EntityFrameworkCore;
using MaggiesPlaygroundApi.Data;
using MaggiesPlaygroundApi.Models;

namespace MaggiesPlaygroundApi.Services;

public class ClientPhoneService : IClientPhoneService
{
    private readonly ApplicationDbContext context;

    public ClientPhoneService(ApplicationDbContext context)
    {
        this.context = context;
    }

    public async Task<IEnumerable<ClientPhoneDto>> GetAllAsync()
    {
        return await context.ClientPhones
            .Include(cp => cp.Client)
            .Include(cp => cp.Phone)
            .Where(cp => cp.Active)
            .Select(cp => new ClientPhoneDto
            {
                ClientPhoneId = cp.ClientPhoneId,
                ClientId = cp.ClientId,
                PhoneId = cp.PhoneId,
                Active = cp.Active,
                CreatedDate = cp.CreatedDate,
                EnteredBy = cp.EnteredBy,
                Client = cp.Client != null ? new ClientDto
                {
                    ClientId = cp.Client.ClientId,
                    ClientName = cp.Client.ClientName,
                    ClientTypeId = cp.Client.ClientTypeId,
                    Active = cp.Client.Active,
                    CreatedDate = cp.Client.CreatedDate,
                    EnteredBy = cp.Client.EnteredBy
                } : null,
                Phone = cp.Phone != null ? new PhoneDto
                {
                    PhoneId = cp.Phone.PhoneId,
                    PhoneNumber = cp.Phone.PhoneNumber,
                    Extension = cp.Phone.Extension,
                    PhoneTypeId = cp.Phone.PhoneTypeId
                } : null
            })
            .ToListAsync();
    }

    public async Task<ClientPhoneDto?> GetByIdAsync(Guid id)
    {
        var clientPhone = await context.ClientPhones
            .Include(cp => cp.Client)
            .Include(cp => cp.Phone)
            .FirstOrDefaultAsync(cp => cp.ClientPhoneId == id && cp.Active);

        if (clientPhone == null)
            return null;

        return new ClientPhoneDto
        {
            ClientPhoneId = clientPhone.ClientPhoneId,
            ClientId = clientPhone.ClientId,
            PhoneId = clientPhone.PhoneId,
            Active = clientPhone.Active,
            CreatedDate = clientPhone.CreatedDate,
            EnteredBy = clientPhone.EnteredBy,
            Client = clientPhone.Client != null ? new ClientDto
            {
                ClientId = clientPhone.Client.ClientId,
                ClientName = clientPhone.Client.ClientName,
                ClientTypeId = clientPhone.Client.ClientTypeId,
                Active = clientPhone.Client.Active,
                CreatedDate = clientPhone.Client.CreatedDate,
                EnteredBy = clientPhone.Client.EnteredBy
            } : null,
            Phone = clientPhone.Phone != null ? new PhoneDto
            {
                PhoneId = clientPhone.Phone.PhoneId,
                PhoneNumber = clientPhone.Phone.PhoneNumber,
                Extension = clientPhone.Phone.Extension,
                PhoneTypeId = clientPhone.Phone.PhoneTypeId
            } : null
        };
    }

    public async Task<IEnumerable<ClientPhoneDto>> GetByClientIdAsync(Guid clientId)
    {
        return await context.ClientPhones
            .Include(cp => cp.Client)
            .Include(cp => cp.Phone)
            .Where(cp => cp.ClientId == clientId && cp.Active)
            .Select(cp => new ClientPhoneDto
            {
                ClientPhoneId = cp.ClientPhoneId,
                ClientId = cp.ClientId,
                PhoneId = cp.PhoneId,
                Active = cp.Active,
                CreatedDate = cp.CreatedDate,
                EnteredBy = cp.EnteredBy,
                Client = cp.Client != null ? new ClientDto
                {
                    ClientId = cp.Client.ClientId,
                    ClientName = cp.Client.ClientName,
                    ClientTypeId = cp.Client.ClientTypeId,
                    Active = cp.Client.Active,
                    CreatedDate = cp.Client.CreatedDate,
                    EnteredBy = cp.Client.EnteredBy
                } : null,
                Phone = cp.Phone != null ? new PhoneDto
                {
                    PhoneId = cp.Phone.PhoneId,
                    PhoneNumber = cp.Phone.PhoneNumber,
                    Extension = cp.Phone.Extension,
                    PhoneTypeId = cp.Phone.PhoneTypeId
                } : null
            })
            .ToListAsync();
    }

    public async Task<IEnumerable<ClientPhoneDto>> GetByPhoneIdAsync(Guid phoneId)
    {
        return await context.ClientPhones
            .Include(cp => cp.Client)
            .Include(cp => cp.Phone)
            .Where(cp => cp.PhoneId == phoneId && cp.Active)
            .Select(cp => new ClientPhoneDto
            {
                ClientPhoneId = cp.ClientPhoneId,
                ClientId = cp.ClientId,
                PhoneId = cp.PhoneId,
                Active = cp.Active,
                CreatedDate = cp.CreatedDate,
                EnteredBy = cp.EnteredBy,
                Client = cp.Client != null ? new ClientDto
                {
                    ClientId = cp.Client.ClientId,
                    ClientName = cp.Client.ClientName,
                    ClientTypeId = cp.Client.ClientTypeId,
                    Active = cp.Client.Active,
                    CreatedDate = cp.Client.CreatedDate,
                    EnteredBy = cp.Client.EnteredBy
                } : null,
                Phone = cp.Phone != null ? new PhoneDto
                {
                    PhoneId = cp.Phone.PhoneId,
                    PhoneNumber = cp.Phone.PhoneNumber,
                    Extension = cp.Phone.Extension,
                    PhoneTypeId = cp.Phone.PhoneTypeId
                } : null
            })
            .ToListAsync();
    }

    public async Task<ClientPhoneDto> CreateAsync(ClientPhoneDto clientPhoneDto)
    {
        var clientPhone = new ClientPhone
        {
            ClientPhoneId = Guid.NewGuid(),
            ClientId = clientPhoneDto.ClientId,
            PhoneId = clientPhoneDto.PhoneId,
            Active = true,
            CreatedDate = DateTime.UtcNow,
            EnteredBy = clientPhoneDto.EnteredBy
        };

        context.ClientPhones.Add(clientPhone);
        await context.SaveChangesAsync();

        return await GetByIdAsync(clientPhone.ClientPhoneId) ?? clientPhoneDto;
    }

    public async Task<ClientPhoneDto> UpdateAsync(Guid id, ClientPhoneDto clientPhoneDto)
    {
        var clientPhone = await context.ClientPhones.FindAsync(id);
        if (clientPhone == null)
            throw new ArgumentException("ClientPhone not found");

        clientPhone.ClientId = clientPhoneDto.ClientId;
        clientPhone.PhoneId = clientPhoneDto.PhoneId;
        clientPhone.EnteredBy = clientPhoneDto.EnteredBy;

        await context.SaveChangesAsync();

        return await GetByIdAsync(id) ?? clientPhoneDto;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var clientPhone = await context.ClientPhones.FindAsync(id);
        if (clientPhone == null)
            return false;

        clientPhone.Active = false;
        await context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> ExistsAsync(Guid id)
    {
        return await context.ClientPhones.AnyAsync(cp => cp.ClientPhoneId == id && cp.Active);
    }
} 