using Microsoft.EntityFrameworkCore;
using MaggiesPlaygroundApi.Data;
using MaggiesPlaygroundApi.Models;

namespace MaggiesPlaygroundApi.Services;

public class PersonEmailService : IPersonEmailService
{
    private readonly ApplicationDbContext _context;

    public PersonEmailService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<PersonEmailDto>> GetAllAsync()
    {
        return await _context.PersonEmails
            .Include(pe => pe.Person)
            .Include(pe => pe.Email)
            .ThenInclude(e => e!.EmailType)
            .Where(pe => pe.Active)
            .Select(pe => new PersonEmailDto
            {
                PersonEmailId = pe.PersonEmailId,
                PersonId = pe.PersonId,
                EmailId = pe.EmailId,
                Active = pe.Active,
                CreatedDate = pe.CreatedDate,
                EnteredBy = pe.EnteredBy,
                Person = pe.Person != null ? new PersonDto
                {
                    PersonId = pe.Person.PersonId,
                    LastName = pe.Person.LastName,
                    FirstName = pe.Person.FirstName,
                    MiddleName = pe.Person.MiddleName,
                    Suffix = pe.Person.Suffix,
                    Prefix = pe.Person.Prefix,
                    PersonTypeId = pe.Person.PersonTypeId,
                    Alias = pe.Person.Alias,
                    RaceId = pe.Person.RaceId,
                    DateOfBirth = pe.Person.DateOfBirth,
                    GenderId = pe.Person.GenderId,
                    CreatedDate = pe.Person.CreatedDate,
                    EnteredBy = pe.Person.EnteredBy
                } : null,
                Email = pe.Email != null ? new EmailDto
                {
                    EmailId = pe.Email.EmailId,
                    EmailAddress = pe.Email.EmailAddress,
                    EmailTypeId = pe.Email.EmailTypeId
                } : null
            })
            .ToListAsync();
    }

    public async Task<PersonEmailDto?> GetByIdAsync(Guid id)
    {
        var personEmail = await _context.PersonEmails
            .Include(pe => pe.Person)
            .Include(pe => pe.Email)
            .ThenInclude(e => e!.EmailType)
            .FirstOrDefaultAsync(pe => pe.PersonEmailId == id && pe.Active);

        if (personEmail == null)
            return null;

        return new PersonEmailDto
        {
            PersonEmailId = personEmail.PersonEmailId,
            PersonId = personEmail.PersonId,
            EmailId = personEmail.EmailId,
            Active = personEmail.Active,
            CreatedDate = personEmail.CreatedDate,
            EnteredBy = personEmail.EnteredBy,
            Person = personEmail.Person != null ? new PersonDto
            {
                PersonId = personEmail.Person.PersonId,
                LastName = personEmail.Person.LastName,
                FirstName = personEmail.Person.FirstName,
                MiddleName = personEmail.Person.MiddleName,
                Suffix = personEmail.Person.Suffix,
                Prefix = personEmail.Person.Prefix,
                PersonTypeId = personEmail.Person.PersonTypeId,
                Alias = personEmail.Person.Alias,
                RaceId = personEmail.Person.RaceId,
                DateOfBirth = personEmail.Person.DateOfBirth,
                GenderId = personEmail.Person.GenderId,
                CreatedDate = personEmail.Person.CreatedDate,
                EnteredBy = personEmail.Person.EnteredBy
            } : null,
            Email = personEmail.Email != null ? new EmailDto
            {
                EmailId = personEmail.Email.EmailId,
                EmailAddress = personEmail.Email.EmailAddress,
                EmailTypeId = personEmail.Email.EmailTypeId
            } : null
        };
    }

    public async Task<IEnumerable<PersonEmailDto>> GetByPersonIdAsync(Guid personId)
    {
        return await _context.PersonEmails
            .Include(pe => pe.Person)
            .Include(pe => pe.Email)
            .ThenInclude(e => e!.EmailType)
            .Where(pe => pe.PersonId == personId && pe.Active)
            .Select(pe => new PersonEmailDto
            {
                PersonEmailId = pe.PersonEmailId,
                PersonId = pe.PersonId,
                EmailId = pe.EmailId,
                Active = pe.Active,
                CreatedDate = pe.CreatedDate,
                EnteredBy = pe.EnteredBy,
                Person = pe.Person != null ? new PersonDto
                {
                    PersonId = pe.Person.PersonId,
                    LastName = pe.Person.LastName,
                    FirstName = pe.Person.FirstName,
                    MiddleName = pe.Person.MiddleName,
                    Suffix = pe.Person.Suffix,
                    Prefix = pe.Person.Prefix,
                    PersonTypeId = pe.Person.PersonTypeId,
                    Alias = pe.Person.Alias,
                    RaceId = pe.Person.RaceId,
                    DateOfBirth = pe.Person.DateOfBirth,
                    GenderId = pe.Person.GenderId,
                    CreatedDate = pe.Person.CreatedDate,
                    EnteredBy = pe.Person.EnteredBy
                } : null,
                Email = pe.Email != null ? new EmailDto
                {
                    EmailId = pe.Email.EmailId,
                    EmailAddress = pe.Email.EmailAddress,
                    EmailTypeId = pe.Email.EmailTypeId
                } : null
            })
            .ToListAsync();
    }

    public async Task<IEnumerable<PersonEmailDto>> GetByEmailIdAsync(Guid emailId)
    {
        return await _context.PersonEmails
            .Include(pe => pe.Person)
            .Include(pe => pe.Email)
            .ThenInclude(e => e!.EmailType)
            .Where(pe => pe.EmailId == emailId && pe.Active)
            .Select(pe => new PersonEmailDto
            {
                PersonEmailId = pe.PersonEmailId,
                PersonId = pe.PersonId,
                EmailId = pe.EmailId,
                Active = pe.Active,
                CreatedDate = pe.CreatedDate,
                EnteredBy = pe.EnteredBy,
                Person = pe.Person != null ? new PersonDto
                {
                    PersonId = pe.Person.PersonId,
                    LastName = pe.Person.LastName,
                    FirstName = pe.Person.FirstName,
                    MiddleName = pe.Person.MiddleName,
                    Suffix = pe.Person.Suffix,
                    Prefix = pe.Person.Prefix,
                    PersonTypeId = pe.Person.PersonTypeId,
                    Alias = pe.Person.Alias,
                    RaceId = pe.Person.RaceId,
                    DateOfBirth = pe.Person.DateOfBirth,
                    GenderId = pe.Person.GenderId,
                    CreatedDate = pe.Person.CreatedDate,
                    EnteredBy = pe.Person.EnteredBy
                } : null,
                Email = pe.Email != null ? new EmailDto
                {
                    EmailId = pe.Email.EmailId,
                    EmailAddress = pe.Email.EmailAddress,
                    EmailTypeId = pe.Email.EmailTypeId
                } : null
            })
            .ToListAsync();
    }

    public async Task<PersonEmailDto> CreateAsync(PersonEmailDto personEmailDto, string enteredBy)
    {
        var personEmail = new PersonEmail
        {
            PersonEmailId = Guid.NewGuid(),
            PersonId = personEmailDto.PersonId,
            EmailId = personEmailDto.EmailId,
            Active = true,
            CreatedDate = DateTime.UtcNow,
            EnteredBy = enteredBy
        };

        _context.PersonEmails.Add(personEmail);
        await _context.SaveChangesAsync();

        return await GetByIdAsync(personEmail.PersonEmailId) ?? personEmailDto;
    }

    public async Task<PersonEmailDto> UpdateAsync(Guid id, PersonEmailDto personEmailDto, string enteredBy)
    {
        var personEmail = await _context.PersonEmails.FindAsync(id);
        if (personEmail == null)
            throw new ArgumentException("PersonEmail not found");

        personEmail.PersonId = personEmailDto.PersonId;
        personEmail.EmailId = personEmailDto.EmailId;
        personEmail.Active = personEmailDto.Active;
        personEmail.EnteredBy = enteredBy;

        await _context.SaveChangesAsync();

        return await GetByIdAsync(id) ?? personEmailDto;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var personEmail = await _context.PersonEmails.FindAsync(id);
        if (personEmail == null)
            return false;

        personEmail.Active = false;
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> ExistsAsync(Guid id)
    {
        return await _context.PersonEmails.AnyAsync(pe => pe.PersonEmailId == id && pe.Active);
    }
} 