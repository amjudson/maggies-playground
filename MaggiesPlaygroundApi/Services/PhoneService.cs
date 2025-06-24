using MaggiesPlaygroundApi.Data;
using MaggiesPlaygroundApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MaggiesPlaygroundApi.Services;

public class PhoneService : IPhoneService
{
    private readonly ApplicationDbContext context;

    public PhoneService(ApplicationDbContext context)
    {
        this.context = context;
    }

    public async Task<(IEnumerable<PhoneDto> Phones, int TotalCount)> GetPhonesAsync(PhoneQueryParameters queryParams)
    {
        var query = context.Phones.AsQueryable();

        // Apply filters
        if (!string.IsNullOrWhiteSpace(queryParams.SearchTerm))
        {
            query = query.Where(p => p.PhoneNumber.Contains(queryParams.SearchTerm) || 
                                   p.Extension != null && p.Extension.Contains(queryParams.SearchTerm));
        }

        if (queryParams.PhoneTypeId.HasValue)
        {
            query = query.Where(p => p.PhoneTypeId == queryParams.PhoneTypeId.Value);
        }

        // Apply sorting
        if (!string.IsNullOrWhiteSpace(queryParams.SortBy))
        {
            query = queryParams.SortBy.ToLower() switch
            {
                "phonenumber" => queryParams.SortDescending 
                    ? query.OrderByDescending(p => p.PhoneNumber)
                    : query.OrderBy(p => p.PhoneNumber),
                "extension" => queryParams.SortDescending
                    ? query.OrderByDescending(p => p.Extension)
                    : query.OrderBy(p => p.Extension),
                "phonetypeid" => queryParams.SortDescending
                    ? query.OrderByDescending(p => p.PhoneTypeId)
                    : query.OrderBy(p => p.PhoneTypeId),
                _ => query.OrderBy(p => p.PhoneNumber)
            };
        }
        else
        {
            query = query.OrderBy(p => p.PhoneNumber);
        }

        // Get total count before pagination
        var totalCount = await query.CountAsync();

        // Apply pagination
        var phones = await query
            .Skip((queryParams.PageNumber - 1) * queryParams.PageSize)
            .Take(queryParams.PageSize)
            .Select(p => new PhoneDto
            {
                PhoneId = p.PhoneId,
                PhoneNumber = p.PhoneNumber,
                Extension = p.Extension,
                PhoneTypeId = p.PhoneTypeId
            })
            .ToListAsync();

        return (phones, totalCount);
    }

    public async Task<PhoneDto?> GetPhoneByIdAsync(Guid id)
    {
        var phone = await context.Phones.FindAsync(id);
        
        if (phone == null)
        {
            return null;
        }

        return new PhoneDto
        {
            PhoneId = phone.PhoneId,
            PhoneNumber = phone.PhoneNumber,
            Extension = phone.Extension,
            PhoneTypeId = phone.PhoneTypeId
        };
    }

    public async Task<PhoneDto> CreatePhoneAsync(CreatePhoneDto phoneDto, string currentUser)
    {
        var phone = new Phone
        {
            PhoneId = Guid.NewGuid(),
            PhoneNumber = phoneDto.PhoneNumber,
            Extension = phoneDto.Extension,
            PhoneTypeId = phoneDto.PhoneTypeId
        };

        context.Phones.Add(phone);
        await context.SaveChangesAsync();

        return new PhoneDto
        {
            PhoneId = phone.PhoneId,
            PhoneNumber = phone.PhoneNumber,
            Extension = phone.Extension,
            PhoneTypeId = phone.PhoneTypeId
        };
    }

    public async Task<PhoneDto?> UpdatePhoneAsync(Guid id, UpdatePhoneDto phoneDto, string currentUser)
    {
        var existingPhone = await context.Phones.FindAsync(id);
        
        if (existingPhone == null)
        {
            return null;
        }

        existingPhone.PhoneNumber = phoneDto.PhoneNumber;
        existingPhone.Extension = phoneDto.Extension;
        existingPhone.PhoneTypeId = phoneDto.PhoneTypeId;

        await context.SaveChangesAsync();

        return new PhoneDto
        {
            PhoneId = existingPhone.PhoneId,
            PhoneNumber = existingPhone.PhoneNumber,
            Extension = existingPhone.Extension,
            PhoneTypeId = existingPhone.PhoneTypeId
        };
    }

    public async Task<bool> DeletePhoneAsync(Guid id, string currentUser)
    {
        var phone = await context.Phones.FindAsync(id);
        
        if (phone == null)
        {
            return false;
        }

        context.Phones.Remove(phone);
        await context.SaveChangesAsync();
        
        return true;
    }
} 