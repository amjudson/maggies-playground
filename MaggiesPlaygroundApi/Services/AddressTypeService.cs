using MaggiesPlaygroundApi.Data;
using MaggiesPlaygroundApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MaggiesPlaygroundApi.Services;

public class AddressTypeService : IAddressTypeService
{
    private readonly ApplicationDbContext context;

    public AddressTypeService(ApplicationDbContext context)
    {
        this.context = context;
    }

    public async Task<(IEnumerable<AddressTypeDto> AddressTypes, int TotalCount)> GetAddressTypesAsync(AddressTypeQueryParameters queryParams)
    {
        var query = context.AddressTypes.AsQueryable();

        // Apply filters
        if (!string.IsNullOrWhiteSpace(queryParams.SearchTerm))
        {
            query = query.Where(at => at.Name.Contains(queryParams.SearchTerm) || at.Description.Contains(queryParams.SearchTerm));
        }

        if (!string.IsNullOrWhiteSpace(queryParams.ClientId))
        {
            query = query.Where(at => at.ClientId == queryParams.ClientId);
        }

        // Apply sorting
        if (!string.IsNullOrWhiteSpace(queryParams.SortBy))
        {
            query = queryParams.SortBy.ToLower() switch
            {
                "name" => queryParams.SortDescending 
                    ? query.OrderByDescending(at => at.Name)
                    : query.OrderBy(at => at.Name),
                "description" => queryParams.SortDescending
                    ? query.OrderByDescending(at => at.Description)
                    : query.OrderBy(at => at.Description),
                "addresstypeid" => queryParams.SortDescending
                    ? query.OrderByDescending(at => at.AddressTypeId)
                    : query.OrderBy(at => at.AddressTypeId),
                _ => query.OrderBy(at => at.Name)
            };
        }
        else
        {
            query = query.OrderBy(at => at.Name);
        }

        // Get total count before pagination
        var totalCount = await query.CountAsync();

        // Apply pagination
        var addressTypes = await query
            .Skip((queryParams.PageNumber - 1) * queryParams.PageSize)
            .Take(queryParams.PageSize)
            .Select(at => new AddressTypeDto
            {
                AddressTypeId = at.AddressTypeId,
                Description = at.Description,
                ClientId = at.ClientId,
                Name = at.Name,
                ClientOption = at.ClientOption
            })
            .ToListAsync();

        return (addressTypes, totalCount);
    }

    public async Task<AddressTypeDto?> GetAddressTypeByIdAsync(int id)
    {
        var addressType = await context.AddressTypes.FindAsync(id);
        
        if (addressType == null)
        {
            return null;
        }

        return new AddressTypeDto
        {
            AddressTypeId = addressType.AddressTypeId,
            Description = addressType.Description,
            ClientId = addressType.ClientId,
            Name = addressType.Name,
            ClientOption = addressType.ClientOption
        };
    }

    public async Task<AddressTypeDto> CreateAddressTypeAsync(CreateAddressTypeDto addressTypeDto, string currentUser)
    {
        var addressType = new AddressType
        {
            Description = addressTypeDto.Description,
            ClientId = addressTypeDto.ClientId,
            Name = addressTypeDto.Name,
            ClientOption = addressTypeDto.ClientOption
        };

        context.AddressTypes.Add(addressType);
        await context.SaveChangesAsync();

        return new AddressTypeDto
        {
            AddressTypeId = addressType.AddressTypeId,
            Description = addressType.Description,
            ClientId = addressType.ClientId,
            Name = addressType.Name,
            ClientOption = addressType.ClientOption
        };
    }

    public async Task<AddressTypeDto?> UpdateAddressTypeAsync(int id, UpdateAddressTypeDto addressTypeDto, string currentUser)
    {
        var existingAddressType = await context.AddressTypes.FindAsync(id);
        
        if (existingAddressType == null)
        {
            return null;
        }

        existingAddressType.Description = addressTypeDto.Description;
        existingAddressType.ClientId = addressTypeDto.ClientId;
        existingAddressType.Name = addressTypeDto.Name;
        existingAddressType.ClientOption = addressTypeDto.ClientOption;

        await context.SaveChangesAsync();

        return new AddressTypeDto
        {
            AddressTypeId = existingAddressType.AddressTypeId,
            Description = existingAddressType.Description,
            ClientId = existingAddressType.ClientId,
            Name = existingAddressType.Name,
            ClientOption = existingAddressType.ClientOption
        };
    }

    public async Task<bool> DeleteAddressTypeAsync(int id, string currentUser)
    {
        var addressType = await context.AddressTypes.FindAsync(id);
        
        if (addressType == null)
        {
            return false;
        }

        context.AddressTypes.Remove(addressType);
        await context.SaveChangesAsync();
        
        return true;
    }
} 