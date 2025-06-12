using MaggiesPlaygroundApi.Data;
using MaggiesPlaygroundApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MaggiesPlaygroundApi.Services;

public class PersonTypeService : IPersonTypeService
{
    private readonly ApplicationDbContext context;

    public PersonTypeService(ApplicationDbContext context)
    {
        this.context = context;
    }

    public async Task<(IEnumerable<PersonTypeDto> PersonTypes, int TotalCount)> GetPersonTypesAsync(PersonTypeQueryParameters queryParams)
    {
        var query = context.PersonTypes.AsQueryable();

        // Apply filters
        if (!string.IsNullOrWhiteSpace(queryParams.SearchTerm))
        {
            query = query.Where(pt => pt.Name.Contains(queryParams.SearchTerm) || pt.Description.Contains(queryParams.SearchTerm));
        }

        if (queryParams.ClientId.HasValue)
        {
            query = query.Where(pt => pt.ClientId == queryParams.ClientId.Value);
        }

        if (queryParams.ClientOption.HasValue)
        {
            query = query.Where(pt => pt.ClientOption == queryParams.ClientOption.Value);
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
                "clientoption" => queryParams.SortDescending
                    ? query.OrderByDescending(pt => pt.ClientOption)
                    : query.OrderBy(pt => pt.ClientOption),
                "createddate" => queryParams.SortDescending
                    ? query.OrderByDescending(pt => pt.CreatedDate)
                    : query.OrderBy(pt => pt.CreatedDate),
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
        var personTypes = await query
            .Skip((queryParams.PageNumber - 1) * queryParams.PageSize)
            .Take(queryParams.PageSize)
            .Select(pt => new PersonTypeDto
            {
                PersonTypeId = pt.PersonTypeId,
                Name = pt.Name,
                Description = pt.Description,
                ClientId = pt.ClientId,
                ClientOption = pt.ClientOption,
                CreatedDate = pt.CreatedDate,
                EnteredBy = pt.EnteredBy
            })
            .ToListAsync();

        return (personTypes, totalCount);
    }

    public async Task<PersonTypeDto?> GetPersonTypeByIdAsync(int id)
    {
        var personType = await context.PersonTypes.FindAsync(id);
        
        if (personType == null)
        {
            return null;
        }

        return new PersonTypeDto
        {
            PersonTypeId = personType.PersonTypeId,
            Name = personType.Name,
            Description = personType.Description,
            ClientId = personType.ClientId,
            ClientOption = personType.ClientOption,
            CreatedDate = personType.CreatedDate,
            EnteredBy = personType.EnteredBy
        };
    }

    public async Task<PersonTypeDto> CreatePersonTypeAsync(CreatePersonTypeDto personTypeDto, string currentUser)
    {
        var personType = new PersonType
        {
            Name = personTypeDto.Name,
            Description = personTypeDto.Description,
            ClientId = personTypeDto.ClientId,
            ClientOption = personTypeDto.ClientOption,
            CreatedDate = DateTime.UtcNow,
            EnteredBy = currentUser
        };

        context.PersonTypes.Add(personType);
        await context.SaveChangesAsync();

        return new PersonTypeDto
        {
            PersonTypeId = personType.PersonTypeId,
            Name = personType.Name,
            Description = personType.Description,
            ClientId = personType.ClientId,
            ClientOption = personType.ClientOption,
            CreatedDate = personType.CreatedDate,
            EnteredBy = personType.EnteredBy
        };
    }

    public async Task<PersonTypeDto?> UpdatePersonTypeAsync(int id, UpdatePersonTypeDto personTypeDto, string currentUser)
    {
        var existingPersonType = await context.PersonTypes.FindAsync(id);
        
        if (existingPersonType == null)
        {
            return null;
        }

        existingPersonType.Name = personTypeDto.Name;
        existingPersonType.Description = personTypeDto.Description;
        existingPersonType.ClientId = personTypeDto.ClientId;
        existingPersonType.ClientOption = personTypeDto.ClientOption;
        existingPersonType.EnteredBy = currentUser;

        await context.SaveChangesAsync();

        return new PersonTypeDto
        {
            PersonTypeId = existingPersonType.PersonTypeId,
            Name = existingPersonType.Name,
            Description = existingPersonType.Description,
            ClientId = existingPersonType.ClientId,
            ClientOption = existingPersonType.ClientOption,
            CreatedDate = existingPersonType.CreatedDate,
            EnteredBy = existingPersonType.EnteredBy
        };
    }

    public async Task<bool> DeletePersonTypeAsync(int id, string currentUser)
    {
        var personType = await context.PersonTypes.FindAsync(id);
        
        if (personType == null)
        {
            return false;
        }

        context.PersonTypes.Remove(personType);
        await context.SaveChangesAsync();
        
        return true;
    }
} 