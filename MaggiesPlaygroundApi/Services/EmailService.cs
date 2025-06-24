using MaggiesPlaygroundApi.Data;
using MaggiesPlaygroundApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MaggiesPlaygroundApi.Services;

public class EmailService : IEmailService
{
    private readonly ApplicationDbContext context;

    public EmailService(ApplicationDbContext context)
    {
        this.context = context;
    }

    public async Task<(IEnumerable<EmailDto> Emails, int TotalCount)> GetEmailsAsync(EmailQueryParameters queryParams)
    {
        var query = context.Emails.AsQueryable();

        // Apply filters
        if (!string.IsNullOrWhiteSpace(queryParams.SearchTerm))
        {
            query = query.Where(e => e.EmailAddress.Contains(queryParams.SearchTerm));
        }

        if (queryParams.EmailTypeId.HasValue)
        {
            query = query.Where(e => e.EmailTypeId == queryParams.EmailTypeId.Value);
        }

        // Apply sorting
        if (!string.IsNullOrWhiteSpace(queryParams.SortBy))
        {
            query = queryParams.SortBy.ToLower() switch
            {
                "emailaddress" => queryParams.SortDescending 
                    ? query.OrderByDescending(e => e.EmailAddress)
                    : query.OrderBy(e => e.EmailAddress),
                "emailtypeid" => queryParams.SortDescending
                    ? query.OrderByDescending(e => e.EmailTypeId)
                    : query.OrderBy(e => e.EmailTypeId),
                _ => query.OrderBy(e => e.EmailAddress)
            };
        }
        else
        {
            query = query.OrderBy(e => e.EmailAddress);
        }

        // Get total count before pagination
        var totalCount = await query.CountAsync();

        // Apply pagination
        var emails = await query
            .Skip((queryParams.PageNumber - 1) * queryParams.PageSize)
            .Take(queryParams.PageSize)
            .Select(e => new EmailDto
            {
                EmailId = e.EmailId,
                EmailAddress = e.EmailAddress,
                EmailTypeId = e.EmailTypeId
            })
            .ToListAsync();

        return (emails, totalCount);
    }

    public async Task<EmailDto?> GetEmailByIdAsync(Guid id)
    {
        var email = await context.Emails.FindAsync(id);
        
        if (email == null)
        {
            return null;
        }

        return new EmailDto
        {
            EmailId = email.EmailId,
            EmailAddress = email.EmailAddress,
            EmailTypeId = email.EmailTypeId
        };
    }

    public async Task<EmailDto> CreateEmailAsync(CreateEmailDto emailDto, string currentUser)
    {
        var email = new Email
        {
            EmailId = Guid.NewGuid(),
            EmailAddress = emailDto.EmailAddress,
            EmailTypeId = emailDto.EmailTypeId
        };

        context.Emails.Add(email);
        await context.SaveChangesAsync();

        return new EmailDto
        {
            EmailId = email.EmailId,
            EmailAddress = email.EmailAddress,
            EmailTypeId = email.EmailTypeId
        };
    }

    public async Task<EmailDto?> UpdateEmailAsync(Guid id, UpdateEmailDto emailDto, string currentUser)
    {
        var existingEmail = await context.Emails.FindAsync(id);
        
        if (existingEmail == null)
        {
            return null;
        }

        existingEmail.EmailAddress = emailDto.EmailAddress;
        existingEmail.EmailTypeId = emailDto.EmailTypeId;

        await context.SaveChangesAsync();

        return new EmailDto
        {
            EmailId = existingEmail.EmailId,
            EmailAddress = existingEmail.EmailAddress,
            EmailTypeId = existingEmail.EmailTypeId
        };
    }

    public async Task<bool> DeleteEmailAsync(Guid id, string currentUser)
    {
        var email = await context.Emails.FindAsync(id);
        
        if (email == null)
        {
            return false;
        }

        context.Emails.Remove(email);
        await context.SaveChangesAsync();
        
        return true;
    }
} 