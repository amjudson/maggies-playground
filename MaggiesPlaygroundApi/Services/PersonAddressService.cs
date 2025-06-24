using Microsoft.EntityFrameworkCore;
using MaggiesPlaygroundApi.Data;
using MaggiesPlaygroundApi.Models;

namespace MaggiesPlaygroundApi.Services;

public class PersonAddressService : IPersonAddressService
{
    private readonly ApplicationDbContext context;

    public PersonAddressService(ApplicationDbContext context)
    {
        this.context = context;
    }

    public async Task<IEnumerable<PersonAddressDto>> GetAllAsync()
    {
        return await context.PersonAddresses
            .Include(pa => pa.Person)
            .Include(pa => pa.Address)
            .ThenInclude(a => a.State)
            .Where(pa => pa.Active)
            .Select(pa => new PersonAddressDto
            {
                PersonAddressId = pa.PersonAddressId,
                PersonId = pa.PersonId,
                AddressId = pa.AddressId,
                Active = pa.Active,
                CreatedDate = pa.CreatedDate,
                EnteredBy = pa.EnteredBy,
                Person = pa.Person != null ? new PersonDto
                {
                    PersonId = pa.Person.PersonId,
                    LastName = pa.Person.LastName,
                    FirstName = pa.Person.FirstName,
                    MiddleName = pa.Person.MiddleName,
                    Suffix = pa.Person.Suffix,
                    Prefix = pa.Person.Prefix,
                    PersonTypeId = pa.Person.PersonTypeId,
                    Alias = pa.Person.Alias,
                    RaceId = pa.Person.RaceId,
                    DateOfBirth = pa.Person.DateOfBirth,
                    GenderId = pa.Person.GenderId,
                    CreatedDate = pa.Person.CreatedDate,
                    EnteredBy = pa.Person.EnteredBy
                } : null,
                Address = pa.Address != null ? new AddressDto
                {
                    AddressId = pa.Address.AddressId,
                    AddressLine1 = pa.Address.AddressLine1,
                    AddressLine2 = pa.Address.AddressLine2,
                    City = pa.Address.City,
                    StateId = pa.Address.StateId,
                    Zip = pa.Address.Zip,
                    AddressTypeId = pa.Address.AddressTypeId,
                    State = pa.Address.State != null ? new StateDto
                    {
                        StateId = pa.Address.State.StateId,
                        Name = pa.Address.State.Name,
                        Abbreviation = pa.Address.State.Abbreviation
                    } : null
                } : null
            })
            .ToListAsync();
    }

    public async Task<PersonAddressDto?> GetByIdAsync(Guid id)
    {
        var personAddress = await context.PersonAddresses
            .Include(pa => pa.Person)
            .Include(pa => pa.Address)
            .ThenInclude(a => a.State)
            .FirstOrDefaultAsync(pa => pa.PersonAddressId == id && pa.Active);

        if (personAddress == null)
            return null;

        return new PersonAddressDto
        {
            PersonAddressId = personAddress.PersonAddressId,
            PersonId = personAddress.PersonId,
            AddressId = personAddress.AddressId,
            Active = personAddress.Active,
            CreatedDate = personAddress.CreatedDate,
            EnteredBy = personAddress.EnteredBy,
            Person = personAddress.Person != null ? new PersonDto
            {
                PersonId = personAddress.Person.PersonId,
                LastName = personAddress.Person.LastName,
                FirstName = personAddress.Person.FirstName,
                MiddleName = personAddress.Person.MiddleName,
                Suffix = personAddress.Person.Suffix,
                Prefix = personAddress.Person.Prefix,
                PersonTypeId = personAddress.Person.PersonTypeId,
                Alias = personAddress.Person.Alias,
                RaceId = personAddress.Person.RaceId,
                DateOfBirth = personAddress.Person.DateOfBirth,
                GenderId = personAddress.Person.GenderId,
                CreatedDate = personAddress.Person.CreatedDate,
                EnteredBy = personAddress.Person.EnteredBy
            } : null,
            Address = personAddress.Address != null ? new AddressDto
            {
                AddressId = personAddress.Address.AddressId,
                AddressLine1 = personAddress.Address.AddressLine1,
                AddressLine2 = personAddress.Address.AddressLine2,
                City = personAddress.Address.City,
                StateId = personAddress.Address.StateId,
                Zip = personAddress.Address.Zip,
                AddressTypeId = personAddress.Address.AddressTypeId,
                State = personAddress.Address.State != null ? new StateDto
                {
                    StateId = personAddress.Address.State.StateId,
                    Name = personAddress.Address.State.Name,
                    Abbreviation = personAddress.Address.State.Abbreviation
                } : null
            } : null
        };
    }

    public async Task<IEnumerable<PersonAddressDto>> GetByPersonIdAsync(Guid personId)
    {
        return await context.PersonAddresses
            .Include(pa => pa.Person)
            .Include(pa => pa.Address)
            .ThenInclude(a => a.State)
            .Where(pa => pa.PersonId == personId && pa.Active)
            .Select(pa => new PersonAddressDto
            {
                PersonAddressId = pa.PersonAddressId,
                PersonId = pa.PersonId,
                AddressId = pa.AddressId,
                Active = pa.Active,
                CreatedDate = pa.CreatedDate,
                EnteredBy = pa.EnteredBy,
                Person = pa.Person != null ? new PersonDto
                {
                    PersonId = pa.Person.PersonId,
                    LastName = pa.Person.LastName,
                    FirstName = pa.Person.FirstName,
                    MiddleName = pa.Person.MiddleName,
                    Suffix = pa.Person.Suffix,
                    Prefix = pa.Person.Prefix,
                    PersonTypeId = pa.Person.PersonTypeId,
                    Alias = pa.Person.Alias,
                    RaceId = pa.Person.RaceId,
                    DateOfBirth = pa.Person.DateOfBirth,
                    GenderId = pa.Person.GenderId,
                    CreatedDate = pa.Person.CreatedDate,
                    EnteredBy = pa.Person.EnteredBy
                } : null,
                Address = pa.Address != null ? new AddressDto
                {
                    AddressId = pa.Address.AddressId,
                    AddressLine1 = pa.Address.AddressLine1,
                    AddressLine2 = pa.Address.AddressLine2,
                    City = pa.Address.City,
                    StateId = pa.Address.StateId,
                    Zip = pa.Address.Zip,
                    AddressTypeId = pa.Address.AddressTypeId,
                    State = pa.Address.State != null ? new StateDto
                    {
                        StateId = pa.Address.State.StateId,
                        Name = pa.Address.State.Name,
                        Abbreviation = pa.Address.State.Abbreviation
                    } : null
                } : null
            })
            .ToListAsync();
    }

    public async Task<IEnumerable<PersonAddressDto>> GetByAddressIdAsync(Guid addressId)
    {
        return await context.PersonAddresses
            .Include(pa => pa.Person)
            .Include(pa => pa.Address)
            .ThenInclude(a => a.State)
            .Where(pa => pa.AddressId == addressId && pa.Active)
            .Select(pa => new PersonAddressDto
            {
                PersonAddressId = pa.PersonAddressId,
                PersonId = pa.PersonId,
                AddressId = pa.AddressId,
                Active = pa.Active,
                CreatedDate = pa.CreatedDate,
                EnteredBy = pa.EnteredBy,
                Person = pa.Person != null ? new PersonDto
                {
                    PersonId = pa.Person.PersonId,
                    LastName = pa.Person.LastName,
                    FirstName = pa.Person.FirstName,
                    MiddleName = pa.Person.MiddleName,
                    Suffix = pa.Person.Suffix,
                    Prefix = pa.Person.Prefix,
                    PersonTypeId = pa.Person.PersonTypeId,
                    Alias = pa.Person.Alias,
                    RaceId = pa.Person.RaceId,
                    DateOfBirth = pa.Person.DateOfBirth,
                    GenderId = pa.Person.GenderId,
                    CreatedDate = pa.Person.CreatedDate,
                    EnteredBy = pa.Person.EnteredBy
                } : null,
                Address = pa.Address != null ? new AddressDto
                {
                    AddressId = pa.Address.AddressId,
                    AddressLine1 = pa.Address.AddressLine1,
                    AddressLine2 = pa.Address.AddressLine2,
                    City = pa.Address.City,
                    StateId = pa.Address.StateId,
                    Zip = pa.Address.Zip,
                    AddressTypeId = pa.Address.AddressTypeId,
                    State = pa.Address.State != null ? new StateDto
                    {
                        StateId = pa.Address.State.StateId,
                        Name = pa.Address.State.Name,
                        Abbreviation = pa.Address.State.Abbreviation
                    } : null
                } : null
            })
            .ToListAsync();
    }

    public async Task<PersonAddressDto> CreateAsync(PersonAddressDto personAddressDto)
    {
        var personAddress = new PersonAddress
        {
            PersonAddressId = Guid.NewGuid(),
            PersonId = personAddressDto.PersonId,
            AddressId = personAddressDto.AddressId,
            Active = true,
            CreatedDate = DateTime.UtcNow,
            EnteredBy = personAddressDto.EnteredBy
        };

        context.PersonAddresses.Add(personAddress);
        await context.SaveChangesAsync();

        return await GetByIdAsync(personAddress.PersonAddressId) ?? personAddressDto;
    }

    public async Task<PersonAddressDto> UpdateAsync(Guid id, PersonAddressDto personAddressDto)
    {
        var personAddress = await context.PersonAddresses.FindAsync(id);
        if (personAddress == null)
            throw new ArgumentException("PersonAddress not found");

        personAddress.PersonId = personAddressDto.PersonId;
        personAddress.AddressId = personAddressDto.AddressId;
        personAddress.EnteredBy = personAddressDto.EnteredBy;

        await context.SaveChangesAsync();

        return await GetByIdAsync(id) ?? personAddressDto;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var personAddress = await context.PersonAddresses.FindAsync(id);
        if (personAddress == null)
            return false;

        personAddress.Active = false;
        await context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> ExistsAsync(Guid id)
    {
        return await context.PersonAddresses.AnyAsync(pa => pa.PersonAddressId == id && pa.Active);
    }
} 