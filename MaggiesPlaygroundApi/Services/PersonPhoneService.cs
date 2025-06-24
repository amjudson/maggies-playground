using Microsoft.EntityFrameworkCore;
using MaggiesPlaygroundApi.Data;
using MaggiesPlaygroundApi.Models;

namespace MaggiesPlaygroundApi.Services;

public class PersonPhoneService : IPersonPhoneService
{
    private readonly ApplicationDbContext _context;

    public PersonPhoneService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<PersonPhoneDto>> GetAllAsync()
    {
        return await _context.PersonPhones
            .Include(pp => pp.Person)
            .Include(pp => pp.Phone)
            .ThenInclude(p => p!.PhoneType)
            .Where(pp => pp.Active)
            .Select(pp => new PersonPhoneDto
            {
                PersonPhoneId = pp.PersonPhoneId,
                PersonId = pp.PersonId,
                PhoneId = pp.PhoneId,
                Active = pp.Active,
                CreatedDate = pp.CreatedDate,
                EnteredBy = pp.EnteredBy,
                Person = pp.Person != null ? new PersonDto
                {
                    PersonId = pp.Person.PersonId,
                    LastName = pp.Person.LastName,
                    FirstName = pp.Person.FirstName,
                    MiddleName = pp.Person.MiddleName,
                    Suffix = pp.Person.Suffix,
                    Prefix = pp.Person.Prefix,
                    PersonTypeId = pp.Person.PersonTypeId,
                    Alias = pp.Person.Alias,
                    RaceId = pp.Person.RaceId,
                    DateOfBirth = pp.Person.DateOfBirth,
                    GenderId = pp.Person.GenderId,
                    CreatedDate = pp.Person.CreatedDate,
                    EnteredBy = pp.Person.EnteredBy
                } : null,
                Phone = pp.Phone != null ? new PhoneDto
                {
                    PhoneId = pp.Phone.PhoneId,
                    PhoneNumber = pp.Phone.PhoneNumber,
                    Extension = pp.Phone.Extension,
                    PhoneTypeId = pp.Phone.PhoneTypeId
                } : null
            })
            .ToListAsync();
    }

    public async Task<PersonPhoneDto?> GetByIdAsync(Guid id)
    {
        var personPhone = await _context.PersonPhones
            .Include(pp => pp.Person)
            .Include(pp => pp.Phone)
            .ThenInclude(p => p!.PhoneType)
            .FirstOrDefaultAsync(pp => pp.PersonPhoneId == id && pp.Active);

        if (personPhone == null)
            return null;

        return new PersonPhoneDto
        {
            PersonPhoneId = personPhone.PersonPhoneId,
            PersonId = personPhone.PersonId,
            PhoneId = personPhone.PhoneId,
            Active = personPhone.Active,
            CreatedDate = personPhone.CreatedDate,
            EnteredBy = personPhone.EnteredBy,
            Person = personPhone.Person != null ? new PersonDto
            {
                PersonId = personPhone.Person.PersonId,
                LastName = personPhone.Person.LastName,
                FirstName = personPhone.Person.FirstName,
                MiddleName = personPhone.Person.MiddleName,
                Suffix = personPhone.Person.Suffix,
                Prefix = personPhone.Person.Prefix,
                PersonTypeId = personPhone.Person.PersonTypeId,
                Alias = personPhone.Person.Alias,
                RaceId = personPhone.Person.RaceId,
                DateOfBirth = personPhone.Person.DateOfBirth,
                GenderId = personPhone.Person.GenderId,
                CreatedDate = personPhone.Person.CreatedDate,
                EnteredBy = personPhone.Person.EnteredBy
            } : null,
            Phone = personPhone.Phone != null ? new PhoneDto
            {
                PhoneId = personPhone.Phone.PhoneId,
                PhoneNumber = personPhone.Phone.PhoneNumber,
                Extension = personPhone.Phone.Extension,
                PhoneTypeId = personPhone.Phone.PhoneTypeId
            } : null
        };
    }

    public async Task<IEnumerable<PersonPhoneDto>> GetByPersonIdAsync(Guid personId)
    {
        return await _context.PersonPhones
            .Include(pp => pp.Person)
            .Include(pp => pp.Phone)
            .ThenInclude(p => p!.PhoneType)
            .Where(pp => pp.PersonId == personId && pp.Active)
            .Select(pp => new PersonPhoneDto
            {
                PersonPhoneId = pp.PersonPhoneId,
                PersonId = pp.PersonId,
                PhoneId = pp.PhoneId,
                Active = pp.Active,
                CreatedDate = pp.CreatedDate,
                EnteredBy = pp.EnteredBy,
                Person = pp.Person != null ? new PersonDto
                {
                    PersonId = pp.Person.PersonId,
                    LastName = pp.Person.LastName,
                    FirstName = pp.Person.FirstName,
                    MiddleName = pp.Person.MiddleName,
                    Suffix = pp.Person.Suffix,
                    Prefix = pp.Person.Prefix,
                    PersonTypeId = pp.Person.PersonTypeId,
                    Alias = pp.Person.Alias,
                    RaceId = pp.Person.RaceId,
                    DateOfBirth = pp.Person.DateOfBirth,
                    GenderId = pp.Person.GenderId,
                    CreatedDate = pp.Person.CreatedDate,
                    EnteredBy = pp.Person.EnteredBy
                } : null,
                Phone = pp.Phone != null ? new PhoneDto
                {
                    PhoneId = pp.Phone.PhoneId,
                    PhoneNumber = pp.Phone.PhoneNumber,
                    Extension = pp.Phone.Extension,
                    PhoneTypeId = pp.Phone.PhoneTypeId
                } : null
            })
            .ToListAsync();
    }

    public async Task<IEnumerable<PersonPhoneDto>> GetByPhoneIdAsync(Guid phoneId)
    {
        return await _context.PersonPhones
            .Include(pp => pp.Person)
            .Include(pp => pp.Phone)
            .ThenInclude(p => p!.PhoneType)
            .Where(pp => pp.PhoneId == phoneId && pp.Active)
            .Select(pp => new PersonPhoneDto
            {
                PersonPhoneId = pp.PersonPhoneId,
                PersonId = pp.PersonId,
                PhoneId = pp.PhoneId,
                Active = pp.Active,
                CreatedDate = pp.CreatedDate,
                EnteredBy = pp.EnteredBy,
                Person = pp.Person != null ? new PersonDto
                {
                    PersonId = pp.Person.PersonId,
                    LastName = pp.Person.LastName,
                    FirstName = pp.Person.FirstName,
                    MiddleName = pp.Person.MiddleName,
                    Suffix = pp.Person.Suffix,
                    Prefix = pp.Person.Prefix,
                    PersonTypeId = pp.Person.PersonTypeId,
                    Alias = pp.Person.Alias,
                    RaceId = pp.Person.RaceId,
                    DateOfBirth = pp.Person.DateOfBirth,
                    GenderId = pp.Person.GenderId,
                    CreatedDate = pp.Person.CreatedDate,
                    EnteredBy = pp.Person.EnteredBy
                } : null,
                Phone = pp.Phone != null ? new PhoneDto
                {
                    PhoneId = pp.Phone.PhoneId,
                    PhoneNumber = pp.Phone.PhoneNumber,
                    Extension = pp.Phone.Extension,
                    PhoneTypeId = pp.Phone.PhoneTypeId
                } : null
            })
            .ToListAsync();
    }

    public async Task<PersonPhoneDto> CreateAsync(PersonPhoneDto personPhoneDto, string enteredBy)
    {
        var personPhone = new PersonPhone
        {
            PersonPhoneId = Guid.NewGuid(),
            PersonId = personPhoneDto.PersonId,
            PhoneId = personPhoneDto.PhoneId,
            Active = true,
            CreatedDate = DateTime.UtcNow,
            EnteredBy = enteredBy
        };

        _context.PersonPhones.Add(personPhone);
        await _context.SaveChangesAsync();

        return await GetByIdAsync(personPhone.PersonPhoneId) ?? personPhoneDto;
    }

    public async Task<PersonPhoneDto> UpdateAsync(Guid id, PersonPhoneDto personPhoneDto, string enteredBy)
    {
        var personPhone = await _context.PersonPhones.FindAsync(id);
        if (personPhone == null)
            throw new ArgumentException("PersonPhone not found");

        personPhone.PersonId = personPhoneDto.PersonId;
        personPhone.PhoneId = personPhoneDto.PhoneId;
        personPhone.Active = personPhoneDto.Active;
        personPhone.EnteredBy = enteredBy;

        await _context.SaveChangesAsync();

        return await GetByIdAsync(id) ?? personPhoneDto;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var personPhone = await _context.PersonPhones.FindAsync(id);
        if (personPhone == null)
            return false;

        personPhone.Active = false;
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> ExistsAsync(Guid id)
    {
        return await _context.PersonPhones.AnyAsync(pp => pp.PersonPhoneId == id && pp.Active);
    }
} 