using MaggiesPlaygroundApi.Data;
using MaggiesPlaygroundApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MaggiesPlaygroundApi.Services;

public class EmailTypeService : IEmailTypeService
{
    private readonly ApplicationDbContext context;

    public EmailTypeService(ApplicationDbContext context)
    {
        this.context = context;
    }

    public async Task<(IEnumerable<EmailTypeDto> EmailTypes, int TotalCount)> GetEmailTypesAsync(EmailTypeQueryParameters queryParams)
    {
        var query = context.EmailTypes.AsQueryable();

        // Apply filters
        if (!string.IsNullOrWhiteSpace(queryParams.SearchTerm))
        {
            query = query.Where(et => et.Name.Contains(queryParams.SearchTerm) || et.Description.Contains(queryParams.SearchTerm));
        }

        if (!string.IsNullOrWhiteSpace(queryParams.ClientId))
        {
            query = query.Where(et => et.ClientId == queryParams.ClientId);
        }

        // Apply sorting
        if (!string.IsNullOrWhiteSpace(queryParams.SortBy))
        {
            query = queryParams.SortBy.ToLower() switch
            {
                "name" => queryParams.SortDescending 
                    ? query.OrderByDescending(et => et.Name)
                    : query.OrderBy(et => et.Name),
                "description" => queryParams.SortDescending
                    ? query.OrderByDescending(et => et.Description)
                    : query.OrderBy(et => et.Description),
                "emailtypeid" => queryParams.SortDescending
                    ? query.OrderByDescending(et => et.EmailTypeId)
                    : query.OrderBy(et => et.EmailTypeId),
                _ => query.OrderBy(et => et.Name)
            };
        }
        else
        {
            query = query.OrderBy(et => et.Name);
        }

        // Get total count before pagination
        var totalCount = await query.CountAsync();

        // Apply pagination
        var emailTypes = await query
            .Skip((queryParams.PageNumber - 1) * queryParams.PageSize)
            .Take(queryParams.PageSize)
            .Select(et => new EmailTypeDto
            {
                EmailTypeId = et.EmailTypeId,
                Description = et.Description,
                ClientId = et.ClientId,
                Name = et.Name,
                ClientOption = et.ClientOption
            })
            .ToListAsync();

        return (emailTypes, totalCount);
    }

    public async Task<EmailTypeDto?> GetEmailTypeByIdAsync(int id)
    {
        var emailType = await context.EmailTypes.FindAsync(id);
        
        if (emailType == null)
        {
            return null;
        }

        return new EmailTypeDto
        {
            EmailTypeId = emailType.EmailTypeId,
            Description = emailType.Description,
            ClientId = emailType.ClientId,
            Name = emailType.Name,
            ClientOption = emailType.ClientOption
        };
    }

    public async Task<EmailTypeDto> CreateEmailTypeAsync(CreateEmailTypeDto emailTypeDto, string currentUser)
    {
        var emailType = new EmailType
        {
            Description = emailTypeDto.Description,
            ClientId = emailTypeDto.ClientId,
            Name = emailTypeDto.Name,
            ClientOption = emailTypeDto.ClientOption
        };

        context.EmailTypes.Add(emailType);
        await context.SaveChangesAsync();

        return new EmailTypeDto
        {
            EmailTypeId = emailType.EmailTypeId,
            Description = emailType.Description,
            ClientId = emailType.ClientId,
            Name = emailType.Name,
            ClientOption = emailType.ClientOption
        };
    }

    public async Task<EmailTypeDto?> UpdateEmailTypeAsync(int id, UpdateEmailTypeDto emailTypeDto, string currentUser)
    {
        var existingEmailType = await context.EmailTypes.FindAsync(id);
        
        if (existingEmailType == null)
        {
            return null;
        }

        existingEmailType.Description = emailTypeDto.Description;
        existingEmailType.ClientId = emailTypeDto.ClientId;
        existingEmailType.Name = emailTypeDto.Name;
        existingEmailType.ClientOption = emailTypeDto.ClientOption;

        await context.SaveChangesAsync();

        return new EmailTypeDto
        {
            EmailTypeId = existingEmailType.EmailTypeId,
            Description = existingEmailType.Description,
            ClientId = existingEmailType.ClientId,
            Name = existingEmailType.Name,
            ClientOption = existingEmailType.ClientOption
        };
    }

    public async Task<bool> DeleteEmailTypeAsync(int id, string currentUser)
    {
        var emailType = await context.EmailTypes.FindAsync(id);
        
        if (emailType == null)
        {
            return false;
        }

        context.EmailTypes.Remove(emailType);
        await context.SaveChangesAsync();
        
        return true;
    }
} 