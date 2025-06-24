using Microsoft.EntityFrameworkCore;
using MaggiesPlaygroundApi.Data;
using MaggiesPlaygroundApi.Models;

namespace MaggiesPlaygroundApi.Services;

public class ClientEmailService : IClientEmailService
{
    private readonly ApplicationDbContext context;

    public ClientEmailService(ApplicationDbContext context)
    {
        this.context = context;
    }

    public async Task<IEnumerable<ClientEmailDto>> GetAllAsync()
    {
        return await context.ClientEmails
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
                    ClientTypeId = ce.Client.ClientTypeId,
                    Active = ce.Client.Active,
                    CreatedDate = ce.Client.CreatedDate,
                    EnteredBy = ce.Client.EnteredBy
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
        var clientEmail = await context.ClientEmails
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
                ClientTypeId = clientEmail.Client.ClientTypeId,
                Active = clientEmail.Client.Active,
                CreatedDate = clientEmail.Client.CreatedDate,
                EnteredBy = clientEmail.Client.EnteredBy
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
        return await context.ClientEmails
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
                    ClientTypeId = ce.Client.ClientTypeId,
                    Active = ce.Client.Active,
                    CreatedDate = ce.Client.CreatedDate,
                    EnteredBy = ce.Client.EnteredBy
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
        return await context.ClientEmails
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
                    ClientTypeId = ce.Client.ClientTypeId,
                    Active = ce.Client.Active,
                    CreatedDate = ce.Client.CreatedDate,
                    EnteredBy = ce.Client.EnteredBy
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

    public async Task<ClientEmailDto> CreateAsync(ClientEmailDto clientEmailDto)
    {
        var clientEmail = new ClientEmail
        {
            ClientEmailId = Guid.NewGuid(),
            ClientId = clientEmailDto.ClientId,
            EmailId = clientEmailDto.EmailId,
            Active = true,
            CreatedDate = DateTime.UtcNow,
            EnteredBy = clientEmailDto.EnteredBy
        };

        context.ClientEmails.Add(clientEmail);
        await context.SaveChangesAsync();

        return await GetByIdAsync(clientEmail.ClientEmailId) ?? clientEmailDto;
    }

    public async Task<ClientEmailDto> UpdateAsync(Guid id, ClientEmailDto clientEmailDto)
    {
        var clientEmail = await context.ClientEmails.FindAsync(id);
        if (clientEmail == null)
            throw new ArgumentException("ClientEmail not found");

        clientEmail.ClientId = clientEmailDto.ClientId;
        clientEmail.EmailId = clientEmailDto.EmailId;
        clientEmail.EnteredBy = clientEmailDto.EnteredBy;

        await context.SaveChangesAsync();

        return await GetByIdAsync(id) ?? clientEmailDto;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var clientEmail = await context.ClientEmails.FindAsync(id);
        if (clientEmail == null)
            return false;

        clientEmail.Active = false;
        await context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> ExistsAsync(Guid id)
    {
        return await context.ClientEmails.AnyAsync(ce => ce.ClientEmailId == id && ce.Active);
    }
} 