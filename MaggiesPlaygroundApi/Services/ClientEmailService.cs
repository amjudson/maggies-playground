using Microsoft.EntityFrameworkCore;
using MaggiesPlaygroundApi.Data;
using MaggiesPlaygroundApi.Models;

namespace MaggiesPlaygroundApi.Services;

public class ClientEmailService : IClientEmailService
{
    private readonly ApplicationDbContext _context;

    public ClientEmailService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ClientEmailDto>> GetAllAsync()
    {
        return await _context.ClientEmails
            .Include(ce => ce.Client)
            .Include(ce => ce.Email)
            .ThenInclude(e => e!.EmailType)
            .Where(ce => ce.Active)
            .Select(ce => new ClientEmailDto
            {
                ClientEmailId = ce.ClientEmailId,
                ClientId = ce.ClientId,
                EmailId = ce.EmailId,
                Active = ce.Active,
                CreatedDate = ce.CreatedDate,
                EnteredBy = ce.EnteredBy,
                Client = ce.Client != null ? new ClientDto
                {
                    ClientId = ce.Client.ClientId,
                    ClientName = ce.Client.ClientName,
                    Active = ce.Client.Active,
                    CreatedDate = ce.Client.CreatedDate,
                    EnteredBy = ce.Client.EnteredBy,
                    ClientTypeId = ce.Client.ClientTypeId
                } : null,
                Email = ce.Email != null ? new EmailDto
                {
                    EmailId = ce.Email.EmailId,
                    EmailAddress = ce.Email.EmailAddress,
                    EmailTypeId = ce.Email.EmailTypeId
                } : null
            })
            .ToListAsync();
    }

    public async Task<ClientEmailDto?> GetByIdAsync(Guid id)
    {
        var clientEmail = await _context.ClientEmails
            .Include(ce => ce.Client)
            .Include(ce => ce.Email)
            .ThenInclude(e => e!.EmailType)
            .FirstOrDefaultAsync(ce => ce.ClientEmailId == id && ce.Active);

        if (clientEmail == null)
            return null;

        return new ClientEmailDto
        {
            ClientEmailId = clientEmail.ClientEmailId,
            ClientId = clientEmail.ClientId,
            EmailId = clientEmail.EmailId,
            Active = clientEmail.Active,
            CreatedDate = clientEmail.CreatedDate,
            EnteredBy = clientEmail.EnteredBy,
            Client = clientEmail.Client != null ? new ClientDto
            {
                ClientId = clientEmail.Client.ClientId,
                ClientName = clientEmail.Client.ClientName,
                Active = clientEmail.Client.Active,
                CreatedDate = clientEmail.Client.CreatedDate,
                EnteredBy = clientEmail.Client.EnteredBy,
                ClientTypeId = clientEmail.Client.ClientTypeId
            } : null,
            Email = clientEmail.Email != null ? new EmailDto
            {
                EmailId = clientEmail.Email.EmailId,
                EmailAddress = clientEmail.Email.EmailAddress,
                EmailTypeId = clientEmail.Email.EmailTypeId
            } : null
        };
    }

    public async Task<IEnumerable<ClientEmailDto>> GetByClientIdAsync(Guid clientId)
    {
        return await _context.ClientEmails
            .Include(ce => ce.Client)
            .Include(ce => ce.Email)
            .ThenInclude(e => e!.EmailType)
            .Where(ce => ce.ClientId == clientId && ce.Active)
            .Select(ce => new ClientEmailDto
            {
                ClientEmailId = ce.ClientEmailId,
                ClientId = ce.ClientId,
                EmailId = ce.EmailId,
                Active = ce.Active,
                CreatedDate = ce.CreatedDate,
                EnteredBy = ce.EnteredBy,
                Client = ce.Client != null ? new ClientDto
                {
                    ClientId = ce.Client.ClientId,
                    ClientName = ce.Client.ClientName,
                    Active = ce.Client.Active,
                    CreatedDate = ce.Client.CreatedDate,
                    EnteredBy = ce.Client.EnteredBy,
                    ClientTypeId = ce.Client.ClientTypeId
                } : null,
                Email = ce.Email != null ? new EmailDto
                {
                    EmailId = ce.Email.EmailId,
                    EmailAddress = ce.Email.EmailAddress,
                    EmailTypeId = ce.Email.EmailTypeId
                } : null
            })
            .ToListAsync();
    }

    public async Task<IEnumerable<ClientEmailDto>> GetByEmailIdAsync(Guid emailId)
    {
        return await _context.ClientEmails
            .Include(ce => ce.Client)
            .Include(ce => ce.Email)
            .ThenInclude(e => e!.EmailType)
            .Where(ce => ce.EmailId == emailId && ce.Active)
            .Select(ce => new ClientEmailDto
            {
                ClientEmailId = ce.ClientEmailId,
                ClientId = ce.ClientId,
                EmailId = ce.EmailId,
                Active = ce.Active,
                CreatedDate = ce.CreatedDate,
                EnteredBy = ce.EnteredBy,
                Client = ce.Client != null ? new ClientDto
                {
                    ClientId = ce.Client.ClientId,
                    ClientName = ce.Client.ClientName,
                    Active = ce.Client.Active,
                    CreatedDate = ce.Client.CreatedDate,
                    EnteredBy = ce.Client.EnteredBy,
                    ClientTypeId = ce.Client.ClientTypeId
                } : null,
                Email = ce.Email != null ? new EmailDto
                {
                    EmailId = ce.Email.EmailId,
                    EmailAddress = ce.Email.EmailAddress,
                    EmailTypeId = ce.Email.EmailTypeId
                } : null
            })
            .ToListAsync();
    }

    public async Task<ClientEmailDto> CreateAsync(ClientEmailDto clientEmailDto, string enteredBy)
    {
        var clientEmail = new ClientEmail
        {
            ClientEmailId = Guid.NewGuid(),
            ClientId = clientEmailDto.ClientId,
            EmailId = clientEmailDto.EmailId,
            Active = true,
            CreatedDate = DateTime.UtcNow,
            EnteredBy = enteredBy
        };

        _context.ClientEmails.Add(clientEmail);
        await _context.SaveChangesAsync();

        return await GetByIdAsync(clientEmail.ClientEmailId) ?? clientEmailDto;
    }

    public async Task<ClientEmailDto> UpdateAsync(Guid id, ClientEmailDto clientEmailDto, string enteredBy)
    {
        var clientEmail = await _context.ClientEmails.FindAsync(id);
        if (clientEmail == null)
            throw new ArgumentException("ClientEmail not found");

        clientEmail.ClientId = clientEmailDto.ClientId;
        clientEmail.EmailId = clientEmailDto.EmailId;
        clientEmail.Active = clientEmailDto.Active;
        clientEmail.EnteredBy = enteredBy;

        await _context.SaveChangesAsync();

        return await GetByIdAsync(id) ?? clientEmailDto;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var clientEmail = await _context.ClientEmails.FindAsync(id);
        if (clientEmail == null)
            return false;

        clientEmail.Active = false;
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> ExistsAsync(Guid id)
    {
        return await _context.ClientEmails.AnyAsync(ce => ce.ClientEmailId == id && ce.Active);
    }
} 