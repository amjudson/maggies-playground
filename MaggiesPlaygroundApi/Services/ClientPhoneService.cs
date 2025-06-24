using Microsoft.EntityFrameworkCore;
using MaggiesPlaygroundApi.Data;
using MaggiesPlaygroundApi.Models;

namespace MaggiesPlaygroundApi.Services;

public class ClientPhoneService : IClientPhoneService
{
    private readonly ApplicationDbContext _context;

    public ClientPhoneService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ClientPhoneDto>> GetAllAsync()
    {
        return await _context.ClientPhones
            .Include(cp => cp.Client)
            .Include(cp => cp.Phone)
            .ThenInclude(p => p!.PhoneType)
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
                    Active = cp.Client.Active,
                    CreatedDate = cp.Client.CreatedDate,
                    EnteredBy = cp.Client.EnteredBy,
                    ClientTypeId = cp.Client.ClientTypeId
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
        var clientPhone = await _context.ClientPhones
            .Include(cp => cp.Client)
            .Include(cp => cp.Phone)
            .ThenInclude(p => p!.PhoneType)
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
                Active = clientPhone.Client.Active,
                CreatedDate = clientPhone.Client.CreatedDate,
                EnteredBy = clientPhone.Client.EnteredBy,
                ClientTypeId = clientPhone.Client.ClientTypeId
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
        return await _context.ClientPhones
            .Include(cp => cp.Client)
            .Include(cp => cp.Phone)
            .ThenInclude(p => p!.PhoneType)
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
                    Active = cp.Client.Active,
                    CreatedDate = cp.Client.CreatedDate,
                    EnteredBy = cp.Client.EnteredBy,
                    ClientTypeId = cp.Client.ClientTypeId
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
        return await _context.ClientPhones
            .Include(cp => cp.Client)
            .Include(cp => cp.Phone)
            .ThenInclude(p => p!.PhoneType)
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
                    Active = cp.Client.Active,
                    CreatedDate = cp.Client.CreatedDate,
                    EnteredBy = cp.Client.EnteredBy,
                    ClientTypeId = cp.Client.ClientTypeId
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

    public async Task<ClientPhoneDto> CreateAsync(ClientPhoneDto clientPhoneDto, string enteredBy)
    {
        var clientPhone = new ClientPhone
        {
            ClientPhoneId = Guid.NewGuid(),
            ClientId = clientPhoneDto.ClientId,
            PhoneId = clientPhoneDto.PhoneId,
            Active = true,
            CreatedDate = DateTime.UtcNow,
            EnteredBy = enteredBy
        };

        _context.ClientPhones.Add(clientPhone);
        await _context.SaveChangesAsync();

        return await GetByIdAsync(clientPhone.ClientPhoneId) ?? clientPhoneDto;
    }

    public async Task<ClientPhoneDto> UpdateAsync(Guid id, ClientPhoneDto clientPhoneDto, string enteredBy)
    {
        var clientPhone = await _context.ClientPhones.FindAsync(id);
        if (clientPhone == null)
            throw new ArgumentException("ClientPhone not found");

        clientPhone.ClientId = clientPhoneDto.ClientId;
        clientPhone.PhoneId = clientPhoneDto.PhoneId;
        clientPhone.Active = clientPhoneDto.Active;
        clientPhone.EnteredBy = enteredBy;

        await _context.SaveChangesAsync();

        return await GetByIdAsync(id) ?? clientPhoneDto;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var clientPhone = await _context.ClientPhones.FindAsync(id);
        if (clientPhone == null)
            return false;

        clientPhone.Active = false;
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> ExistsAsync(Guid id)
    {
        return await _context.ClientPhones.AnyAsync(cp => cp.ClientPhoneId == id && cp.Active);
    }
} 