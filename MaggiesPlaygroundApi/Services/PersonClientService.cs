using MaggiesPlaygroundApi.Data;
using MaggiesPlaygroundApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MaggiesPlaygroundApi.Services;

public class PersonClientService : IPersonClientService
{
    private readonly ApplicationDbContext context;

    public PersonClientService(ApplicationDbContext context)
    {
        this.context = context;
    }

    public async Task<IEnumerable<PersonClientDto>> GetAllAsync()
    {
        return await context.PersonClients
            .Include(pc => pc.Person)
            .Include(pc => pc.Client)
            .Where(pc => pc.Active)
            .Select(pc => new PersonClientDto
            {
                PersonClientId = pc.PersonClientId,
                PersonId = pc.PersonId,
                ClientId = pc.ClientId,
                Active = pc.Active,
                CreatedDate = pc.CreatedDate,
                EnteredBy = pc.EnteredBy,
                Person = pc.Person != null ? new PersonDto
                {
                    PersonId = pc.Person.PersonId,
                    LastName = pc.Person.LastName,
                    FirstName = pc.Person.FirstName,
                    MiddleName = pc.Person.MiddleName,
                    Suffix = pc.Person.Suffix,
                    Prefix = pc.Person.Prefix,
                    PersonTypeId = pc.Person.PersonTypeId,
                    Alias = pc.Person.Alias,
                    RaceId = pc.Person.RaceId,
                    DateOfBirth = pc.Person.DateOfBirth,
                    GenderId = pc.Person.GenderId,
                    CreatedDate = pc.Person.CreatedDate,
                    EnteredBy = pc.Person.EnteredBy
                } : null,
                Client = pc.Client != null ? new ClientDto
                {
                    ClientId = pc.Client.ClientId,
                    ClientName = pc.Client.ClientName,
                    ClientTypeId = pc.Client.ClientTypeId,
                    Active = pc.Client.Active,
                    CreatedDate = pc.Client.CreatedDate,
                    EnteredBy = pc.Client.EnteredBy
                } : null
            })
            .ToListAsync();
    }

    public async Task<PersonClientDto?> GetByIdAsync(Guid personClientId)
    {
        var personClient = await context.PersonClients
            .Include(pc => pc.Person)
            .Include(pc => pc.Client)
            .FirstOrDefaultAsync(pc => pc.PersonClientId == personClientId && pc.Active);

        if (personClient == null)
            return null;

        return new PersonClientDto
        {
            PersonClientId = personClient.PersonClientId,
            PersonId = personClient.PersonId,
            ClientId = personClient.ClientId,
            Active = personClient.Active,
            CreatedDate = personClient.CreatedDate,
            EnteredBy = personClient.EnteredBy,
            Person = personClient.Person != null ? new PersonDto
            {
                PersonId = personClient.Person.PersonId,
                LastName = personClient.Person.LastName,
                FirstName = personClient.Person.FirstName,
                MiddleName = personClient.Person.MiddleName,
                Suffix = personClient.Person.Suffix,
                Prefix = personClient.Person.Prefix,
                PersonTypeId = personClient.Person.PersonTypeId,
                Alias = personClient.Person.Alias,
                RaceId = personClient.Person.RaceId,
                DateOfBirth = personClient.Person.DateOfBirth,
                GenderId = personClient.Person.GenderId,
                CreatedDate = personClient.Person.CreatedDate,
                EnteredBy = personClient.Person.EnteredBy
            } : null,
            Client = personClient.Client != null ? new ClientDto
            {
                ClientId = personClient.Client.ClientId,
                ClientName = personClient.Client.ClientName,
                ClientTypeId = personClient.Client.ClientTypeId,
                Active = personClient.Client.Active,
                CreatedDate = personClient.Client.CreatedDate,
                EnteredBy = personClient.Client.EnteredBy
            } : null
        };
    }

    public async Task<IEnumerable<PersonClientDto>> GetByPersonIdAsync(Guid personId)
    {
        return await context.PersonClients
            .Include(pc => pc.Person)
            .Include(pc => pc.Client)
            .Where(pc => pc.PersonId == personId && pc.Active)
            .Select(pc => new PersonClientDto
            {
                PersonClientId = pc.PersonClientId,
                PersonId = pc.PersonId,
                ClientId = pc.ClientId,
                Active = pc.Active,
                CreatedDate = pc.CreatedDate,
                EnteredBy = pc.EnteredBy,
                Person = pc.Person != null ? new PersonDto
                {
                    PersonId = pc.Person.PersonId,
                    LastName = pc.Person.LastName,
                    FirstName = pc.Person.FirstName,
                    MiddleName = pc.Person.MiddleName,
                    Suffix = pc.Person.Suffix,
                    Prefix = pc.Person.Prefix,
                    PersonTypeId = pc.Person.PersonTypeId,
                    Alias = pc.Person.Alias,
                    RaceId = pc.Person.RaceId,
                    DateOfBirth = pc.Person.DateOfBirth,
                    GenderId = pc.Person.GenderId,
                    CreatedDate = pc.Person.CreatedDate,
                    EnteredBy = pc.Person.EnteredBy
                } : null,
                Client = pc.Client != null ? new ClientDto
                {
                    ClientId = pc.Client.ClientId,
                    ClientName = pc.Client.ClientName,
                    ClientTypeId = pc.Client.ClientTypeId,
                    Active = pc.Client.Active,
                    CreatedDate = pc.Client.CreatedDate,
                    EnteredBy = pc.Client.EnteredBy
                } : null
            })
            .ToListAsync();
    }

    public async Task<IEnumerable<PersonClientDto>> GetByClientIdAsync(Guid clientId)
    {
        return await context.PersonClients
            .Include(pc => pc.Person)
            .Include(pc => pc.Client)
            .Where(pc => pc.ClientId == clientId && pc.Active)
            .Select(pc => new PersonClientDto
            {
                PersonClientId = pc.PersonClientId,
                PersonId = pc.PersonId,
                ClientId = pc.ClientId,
                Active = pc.Active,
                CreatedDate = pc.CreatedDate,
                EnteredBy = pc.EnteredBy,
                Person = pc.Person != null ? new PersonDto
                {
                    PersonId = pc.Person.PersonId,
                    LastName = pc.Person.LastName,
                    FirstName = pc.Person.FirstName,
                    MiddleName = pc.Person.MiddleName,
                    Suffix = pc.Person.Suffix,
                    Prefix = pc.Person.Prefix,
                    PersonTypeId = pc.Person.PersonTypeId,
                    Alias = pc.Person.Alias,
                    RaceId = pc.Person.RaceId,
                    DateOfBirth = pc.Person.DateOfBirth,
                    GenderId = pc.Person.GenderId,
                    CreatedDate = pc.Person.CreatedDate,
                    EnteredBy = pc.Person.EnteredBy
                } : null,
                Client = pc.Client != null ? new ClientDto
                {
                    ClientId = pc.Client.ClientId,
                    ClientName = pc.Client.ClientName,
                    ClientTypeId = pc.Client.ClientTypeId,
                    Active = pc.Client.Active,
                    CreatedDate = pc.Client.CreatedDate,
                    EnteredBy = pc.Client.EnteredBy
                } : null
            })
            .ToListAsync();
    }

    public async Task<PersonClientDto> CreateAsync(PersonClientDto personClientDto)
    {
        var personClient = new PersonClient
        {
            PersonClientId = Guid.NewGuid(),
            PersonId = personClientDto.PersonId,
            ClientId = personClientDto.ClientId,
            Active = true,
            CreatedDate = DateTime.UtcNow,
            EnteredBy = personClientDto.EnteredBy
        };

        context.PersonClients.Add(personClient);
        await context.SaveChangesAsync();

        return await GetByIdAsync(personClient.PersonClientId) ?? personClientDto;
    }

    public async Task<PersonClientDto> UpdateAsync(Guid personClientId, PersonClientDto personClientDto)
    {
        var personClient = await context.PersonClients
            .FirstOrDefaultAsync(pc => pc.PersonClientId == personClientId && pc.Active);

        if (personClient == null)
            throw new ArgumentException("PersonClient not found");

        personClient.PersonId = personClientDto.PersonId;
        personClient.ClientId = personClientDto.ClientId;
        personClient.EnteredBy = personClientDto.EnteredBy;

        await context.SaveChangesAsync();

        return await GetByIdAsync(personClientId) ?? personClientDto;
    }

    public async Task<bool> DeleteAsync(Guid personClientId)
    {
        var personClient = await context.PersonClients
            .FirstOrDefaultAsync(pc => pc.PersonClientId == personClientId && pc.Active);

        if (personClient == null)
            return false;

        personClient.Active = false;
        await context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> ExistsAsync(Guid personClientId)
    {
        return await context.PersonClients
            .AnyAsync(pc => pc.PersonClientId == personClientId && pc.Active);
    }
} 