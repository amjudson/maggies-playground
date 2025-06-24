using MaggiesPlaygroundApi.Data;
using MaggiesPlaygroundApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MaggiesPlaygroundApi.Services;

public class PhoneTypeService : IPhoneTypeService
{
    private readonly ApplicationDbContext context;

    public PhoneTypeService(ApplicationDbContext context)
    {
        this.context = context;
    }

    public async Task<(IEnumerable<PhoneTypeDto> PhoneTypes, int TotalCount)> GetPhoneTypesAsync(PhoneTypeQueryParameters queryParams)
    {
        var query = context.PhoneTypes.AsQueryable();

        // Apply filters
        if (!string.IsNullOrWhiteSpace(queryParams.SearchTerm))
        {
            query = query.Where(pt => pt.Name.Contains(queryParams.SearchTerm) || pt.Description.Contains(queryParams.SearchTerm));
        }

        if (!string.IsNullOrWhiteSpace(queryParams.ClientId))
        {
            query = query.Where(pt => pt.ClientId == queryParams.ClientId);
        }

        // Apply sorting
        if (!string.IsNullOrWhiteSpace(queryParams.SortBy))
        {
            query = queryParams.SortBy.ToLower() switch
            {
                "name" => queryParams.SortDescending 
                    ? query.OrderByDescending(pt => pt.Name)
                    : query.OrderBy(pt => pt.Name),
                "description" => queryParams.SortDescending
                    ? query.OrderByDescending(pt => pt.Description)
                    : query.OrderBy(pt => pt.Description),
                "phonetypeid" => queryParams.SortDescending
                    ? query.OrderByDescending(pt => pt.PhoneTypeId)
                    : query.OrderBy(pt => pt.PhoneTypeId),
                _ => query.OrderBy(pt => pt.Name)
            };
        }
        else
        {
            query = query.OrderBy(pt => pt.Name);
        }

        // Get total count before pagination
        var totalCount = await query.CountAsync();

        // Apply pagination
        var phoneTypes = await query
            .Skip((queryParams.PageNumber - 1) * queryParams.PageSize)
            .Take(queryParams.PageSize)
            .Select(pt => new PhoneTypeDto
            {
                PhoneTypeId = pt.PhoneTypeId,
                Description = pt.Description,
                ClientId = pt.ClientId,
                Name = pt.Name,
                ClientOption = pt.ClientOption
            })
            .ToListAsync();

        return (phoneTypes, totalCount);
    }

    public async Task<PhoneTypeDto?> GetPhoneTypeByIdAsync(int id)
    {
        var phoneType = await context.PhoneTypes.FindAsync(id);
        
        if (phoneType == null)
        {
            return null;
        }

        return new PhoneTypeDto
        {
            PhoneTypeId = phoneType.PhoneTypeId,
            Description = phoneType.Description,
            ClientId = phoneType.ClientId,
            Name = phoneType.Name,
            ClientOption = phoneType.ClientOption
        };
    }

    public async Task<PhoneTypeDto> CreatePhoneTypeAsync(CreatePhoneTypeDto phoneTypeDto, string currentUser)
    {
        var phoneType = new PhoneType
        {
            Description = phoneTypeDto.Description,
            ClientId = phoneTypeDto.ClientId,
            Name = phoneTypeDto.Name,
            ClientOption = phoneTypeDto.ClientOption
        };

        context.PhoneTypes.Add(phoneType);
        await context.SaveChangesAsync();

        return new PhoneTypeDto
        {
            PhoneTypeId = phoneType.PhoneTypeId,
            Description = phoneType.Description,
            ClientId = phoneType.ClientId,
            Name = phoneType.Name,
            ClientOption = phoneType.ClientOption
        };
    }

    public async Task<PhoneTypeDto?> UpdatePhoneTypeAsync(int id, UpdatePhoneTypeDto phoneTypeDto, string currentUser)
    {
        var existingPhoneType = await context.PhoneTypes.FindAsync(id);
        
        if (existingPhoneType == null)
        {
            return null;
        }

        existingPhoneType.Description = phoneTypeDto.Description;
        existingPhoneType.ClientId = phoneTypeDto.ClientId;
        existingPhoneType.Name = phoneTypeDto.Name;
        existingPhoneType.ClientOption = phoneTypeDto.ClientOption;

        await context.SaveChangesAsync();

        return new PhoneTypeDto
        {
            PhoneTypeId = existingPhoneType.PhoneTypeId,
            Description = existingPhoneType.Description,
            ClientId = existingPhoneType.ClientId,
            Name = existingPhoneType.Name,
            ClientOption = existingPhoneType.ClientOption
        };
    }

    public async Task<bool> DeletePhoneTypeAsync(int id, string currentUser)
    {
        var phoneType = await context.PhoneTypes.FindAsync(id);
        
        if (phoneType == null)
        {
            return false;
        }

        context.PhoneTypes.Remove(phoneType);
        await context.SaveChangesAsync();
        
        return true;
    }
} 