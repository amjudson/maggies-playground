using MaggiesPlaygroundApi.Data;
using MaggiesPlaygroundApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MaggiesPlaygroundApi.Services;

public class AddressService : IAddressService
{
    private readonly ApplicationDbContext context;

    public AddressService(ApplicationDbContext context)
    {
        this.context = context;
    }

    public async Task<(IEnumerable<AddressDto> Addresses, int TotalCount)> GetAddressesAsync(AddressQueryParameters queryParams)
    {
        var query = context.Addresses.AsQueryable();

        // Apply filters
        if (!string.IsNullOrWhiteSpace(queryParams.SearchTerm))
        {
            query = query.Where(a => a.AddressLine1.Contains(queryParams.SearchTerm) || 
                                   a.City.Contains(queryParams.SearchTerm) || 
                                   a.Zip.Contains(queryParams.SearchTerm));
        }

        if (queryParams.AddressTypeId.HasValue)
        {
            query = query.Where(a => a.AddressTypeId == queryParams.AddressTypeId.Value);
        }

        if (queryParams.StateId.HasValue)
        {
            query = query.Where(a => a.StateId == queryParams.StateId.Value);
        }

        // Apply sorting
        if (!string.IsNullOrWhiteSpace(queryParams.SortBy))
        {
            query = queryParams.SortBy.ToLower() switch
            {
                "addressline1" => queryParams.SortDescending 
                    ? query.OrderByDescending(a => a.AddressLine1)
                    : query.OrderBy(a => a.AddressLine1),
                "city" => queryParams.SortDescending
                    ? query.OrderByDescending(a => a.City)
                    : query.OrderBy(a => a.City),
                "zip" => queryParams.SortDescending
                    ? query.OrderByDescending(a => a.Zip)
                    : query.OrderBy(a => a.Zip),
                "addresstypeid" => queryParams.SortDescending
                    ? query.OrderByDescending(a => a.AddressTypeId)
                    : query.OrderBy(a => a.AddressTypeId),
                "stateid" => queryParams.SortDescending
                    ? query.OrderByDescending(a => a.StateId)
                    : query.OrderBy(a => a.StateId),
                _ => query.OrderBy(a => a.AddressLine1)
            };
        }
        else
        {
            query = query.OrderBy(a => a.AddressLine1);
        }

        // Get total count before pagination
        var totalCount = await query.CountAsync();

        // Apply pagination
        var addresses = await query
            .Skip((queryParams.PageNumber - 1) * queryParams.PageSize)
            .Take(queryParams.PageSize)
            .Select(a => new AddressDto
            {
                AddressId = a.AddressId,
                AddressLine1 = a.AddressLine1,
                AddressLine2 = a.AddressLine2,
                City = a.City,
                StateId = a.StateId,
                Zip = a.Zip,
                AddressTypeId = a.AddressTypeId
            })
            .ToListAsync();

        return (addresses, totalCount);
    }

    public async Task<AddressDto?> GetAddressByIdAsync(Guid id)
    {
        var address = await context.Addresses.FindAsync(id);
        
        if (address == null)
        {
            return null;
        }

        return new AddressDto
        {
            AddressId = address.AddressId,
            AddressLine1 = address.AddressLine1,
            AddressLine2 = address.AddressLine2,
            City = address.City,
            StateId = address.StateId,
            Zip = address.Zip,
            AddressTypeId = address.AddressTypeId
        };
    }

    public async Task<AddressDto> CreateAddressAsync(CreateAddressDto addressDto, string currentUser)
    {
        var address = new Address
        {
            AddressId = Guid.NewGuid(),
            AddressLine1 = addressDto.AddressLine1,
            AddressLine2 = addressDto.AddressLine2,
            City = addressDto.City,
            StateId = addressDto.StateId,
            Zip = addressDto.Zip,
            AddressTypeId = addressDto.AddressTypeId
        };

        context.Addresses.Add(address);
        await context.SaveChangesAsync();

        return new AddressDto
        {
            AddressId = address.AddressId,
            AddressLine1 = address.AddressLine1,
            AddressLine2 = address.AddressLine2,
            City = address.City,
            StateId = address.StateId,
            Zip = address.Zip,
            AddressTypeId = address.AddressTypeId
        };
    }

    public async Task<AddressDto?> UpdateAddressAsync(Guid id, UpdateAddressDto addressDto, string currentUser)
    {
        var existingAddress = await context.Addresses.FindAsync(id);
        
        if (existingAddress == null)
        {
            return null;
        }

        existingAddress.AddressLine1 = addressDto.AddressLine1;
        existingAddress.AddressLine2 = addressDto.AddressLine2;
        existingAddress.City = addressDto.City;
        existingAddress.StateId = addressDto.StateId;
        existingAddress.Zip = addressDto.Zip;
        existingAddress.AddressTypeId = addressDto.AddressTypeId;

        await context.SaveChangesAsync();

        return new AddressDto
        {
            AddressId = existingAddress.AddressId,
            AddressLine1 = existingAddress.AddressLine1,
            AddressLine2 = existingAddress.AddressLine2,
            City = existingAddress.City,
            StateId = existingAddress.StateId,
            Zip = existingAddress.Zip,
            AddressTypeId = existingAddress.AddressTypeId
        };
    }

    public async Task<bool> DeleteAddressAsync(Guid id, string currentUser)
    {
        var address = await context.Addresses.FindAsync(id);
        
        if (address == null)
        {
            return false;
        }

        context.Addresses.Remove(address);
        await context.SaveChangesAsync();
        
        return true;
    }
} 