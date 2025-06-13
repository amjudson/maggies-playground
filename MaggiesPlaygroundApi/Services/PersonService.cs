using MaggiesPlaygroundApi.Data;
using MaggiesPlaygroundApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MaggiesPlaygroundApi.Services;

public class PersonService : IPersonService
{
    private readonly ApplicationDbContext context;

    public PersonService(ApplicationDbContext context)
    {
        this.context = context;
    }

    public async Task<(IEnumerable<PersonDto> People, int TotalCount)> GetPeopleAsync(PersonQueryParameters queryParams)
    {
        var query = context.People
            .Include(p => p.PersonType)
            .Include(p => p.Race)
            .Include(p => p.Gender)
            .AsQueryable();

        // Apply filters
        if (!string.IsNullOrWhiteSpace(queryParams.SearchTerm))
        {
            query = query.Where(p => 
                p.FirstName.Contains(queryParams.SearchTerm) || 
                p.LastName.Contains(queryParams.SearchTerm) ||
                p.Alias.Contains(queryParams.SearchTerm));
        }

        if (queryParams.PersonTypeId.HasValue)
        {
            query = query.Where(p => p.PersonTypeId == queryParams.PersonTypeId.Value);
        }

        if (queryParams.RaceId.HasValue)
        {
            query = query.Where(p => p.RaceId == queryParams.RaceId.Value);
        }

        if (queryParams.GenderId.HasValue)
        {
            query = query.Where(p => p.GenderId == queryParams.GenderId.Value);
        }

        // Apply sorting
        if (!string.IsNullOrWhiteSpace(queryParams.SortBy))
        {
            query = queryParams.SortBy.ToLower() switch
            {
                "lastname" => queryParams.SortDescending 
                    ? query.OrderByDescending(p => p.LastName)
                    : query.OrderBy(p => p.LastName),
                "firstname" => queryParams.SortDescending 
                    ? query.OrderByDescending(p => p.FirstName)
                    : query.OrderBy(p => p.FirstName),
                "dateofbirth" => queryParams.SortDescending 
                    ? query.OrderByDescending(p => p.DateOfBirth)
                    : query.OrderBy(p => p.DateOfBirth),
                "createddate" => queryParams.SortDescending 
                    ? query.OrderByDescending(p => p.CreatedDate)
                    : query.OrderBy(p => p.CreatedDate),
                _ => query.OrderBy(p => p.LastName)
            };
        }
        else
        {
            query = query.OrderBy(p => p.LastName);
        }

        var totalCount = await query.CountAsync();

        var people = await query
            .Skip((queryParams.PageNumber - 1) * queryParams.PageSize)
            .Take(queryParams.PageSize)
            .Select(p => new PersonDto
            {
                PersonId = p.PersonId,
                LastName = p.LastName,
                FirstName = p.FirstName,
                MiddleName = p.MiddleName,
                Suffix = p.Suffix,
                Prefix = p.Prefix,
                PersonTypeId = p.PersonTypeId,
                Alias = p.Alias,
                RaceId = p.RaceId,
                DateOfBirth = p.DateOfBirth,
                GenderId = p.GenderId,
                CreatedDate = p.CreatedDate,
                EnteredBy = p.EnteredBy,
                PersonType = p.PersonType != null ? new PersonTypeDto
                {
                    PersonTypeId = p.PersonType.PersonTypeId,
                    Name = p.PersonType.Name,
                    Description = p.PersonType.Description,
                    ClientId = p.PersonType.ClientId,
                    ClientOption = p.PersonType.ClientOption,
                    CreatedDate = p.PersonType.CreatedDate,
                    EnteredBy = p.PersonType.EnteredBy
                } : null,
                Race = p.Race != null ? new RaceDto
                {
                    RaceId = p.Race.RaceId,
                    Name = p.Race.Name,
                    Description = p.Race.Description,
                    CreatedDate = p.Race.CreatedDate,
                    EnteredBy = p.Race.EnteredBy
                } : null,
                Gender = p.Gender != null ? new GenderDto
                {
                    GenderId = p.Gender.GenderId,
                    Name = p.Gender.Name,
                    Description = p.Gender.Description,
                    CreatedDate = p.Gender.CreatedDate,
                    EnteredBy = p.Gender.EnteredBy
                } : null
            })
            .ToListAsync();

        return (people, totalCount);
    }

    public async Task<PersonDto?> GetPersonByIdAsync(Guid id)
    {
        var person = await context.People
            .Include(p => p.PersonType)
            .Include(p => p.Race)
            .Include(p => p.Gender)
            .FirstOrDefaultAsync(p => p.PersonId == id);

        if (person == null)
        {
            return null;
        }

        return new PersonDto
        {
            PersonId = person.PersonId,
            LastName = person.LastName,
            FirstName = person.FirstName,
            MiddleName = person.MiddleName,
            Suffix = person.Suffix,
            Prefix = person.Prefix,
            PersonTypeId = person.PersonTypeId,
            Alias = person.Alias,
            RaceId = person.RaceId,
            DateOfBirth = person.DateOfBirth,
            GenderId = person.GenderId,
            CreatedDate = person.CreatedDate,
            EnteredBy = person.EnteredBy,
            PersonType = person.PersonType != null ? new PersonTypeDto
            {
                PersonTypeId = person.PersonType.PersonTypeId,
                Name = person.PersonType.Name,
                Description = person.PersonType.Description,
                ClientId = person.PersonType.ClientId,
                ClientOption = person.PersonType.ClientOption,
                CreatedDate = person.PersonType.CreatedDate,
                EnteredBy = person.PersonType.EnteredBy
            } : null,
            Race = person.Race != null ? new RaceDto
            {
                RaceId = person.Race.RaceId,
                Name = person.Race.Name,
                Description = person.Race.Description,
                CreatedDate = person.Race.CreatedDate,
                EnteredBy = person.Race.EnteredBy
            } : null,
            Gender = person.Gender != null ? new GenderDto
            {
                GenderId = person.Gender.GenderId,
                Name = person.Gender.Name,
                Description = person.Gender.Description,
                CreatedDate = person.Gender.CreatedDate,
                EnteredBy = person.Gender.EnteredBy
            } : null
        };
    }

    public async Task<PersonDto> CreatePersonAsync(CreatePersonDto personDto, string currentUser)
    {
        var person = new Person
        {
            PersonId = Guid.NewGuid(),
            LastName = personDto.LastName,
            FirstName = personDto.FirstName,
            MiddleName = personDto.MiddleName,
            Suffix = personDto.Suffix,
            Prefix = personDto.Prefix,
            PersonTypeId = personDto.PersonTypeId,
            Alias = personDto.Alias,
            RaceId = personDto.RaceId,
            DateOfBirth = personDto.DateOfBirth,
            GenderId = personDto.GenderId,
            CreatedDate = DateTime.UtcNow,
            EnteredBy = currentUser
        };

        context.People.Add(person);
        await context.SaveChangesAsync();

        return await GetPersonByIdAsync(person.PersonId) ?? throw new InvalidOperationException("Failed to retrieve created person");
    }

    public async Task<PersonDto?> UpdatePersonAsync(Guid id, UpdatePersonDto personDto, string currentUser)
    {
        var existingPerson = await context.People.FindAsync(id);
        
        if (existingPerson == null)
        {
            return null;
        }

        existingPerson.LastName = personDto.LastName;
        existingPerson.FirstName = personDto.FirstName;
        existingPerson.MiddleName = personDto.MiddleName;
        existingPerson.Suffix = personDto.Suffix;
        existingPerson.Prefix = personDto.Prefix;
        existingPerson.PersonTypeId = personDto.PersonTypeId;
        existingPerson.Alias = personDto.Alias;
        existingPerson.RaceId = personDto.RaceId;
        existingPerson.DateOfBirth = personDto.DateOfBirth;
        existingPerson.GenderId = personDto.GenderId;
        existingPerson.EnteredBy = currentUser;

        await context.SaveChangesAsync();

        return await GetPersonByIdAsync(id);
    }

    public async Task<bool> DeletePersonAsync(Guid id, string currentUser)
    {
        var person = await context.People.FindAsync(id);
        
        if (person == null)
        {
            return false;
        }

        context.People.Remove(person);
        await context.SaveChangesAsync();
        
        return true;
    }
} 