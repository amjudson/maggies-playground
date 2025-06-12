using MaggiesPlaygroundApi.Data;
using MaggiesPlaygroundApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MaggiesPlaygroundApi.Services;

public class GenderService : IGenderService
{
    private readonly ApplicationDbContext context;

    public GenderService(ApplicationDbContext context)
    {
        this.context = context;
    }

    public async Task<(IEnumerable<GenderDto> Genders, int TotalCount)> GetGendersAsync(GenderQueryParameters queryParams)
    {
        var query = context.Genders.AsQueryable();

        // Apply filters
        if (!string.IsNullOrWhiteSpace(queryParams.SearchTerm))
        {
            query = query.Where(g => g.Name.Contains(queryParams.SearchTerm) || g.Description.Contains(queryParams.SearchTerm));
        }

        // Apply sorting
        if (!string.IsNullOrWhiteSpace(queryParams.SortBy))
        {
            query = queryParams.SortBy.ToLower() switch
            {
                "name" => queryParams.SortDescending 
                    ? query.OrderByDescending(g => g.Name)
                    : query.OrderBy(g => g.Name),
                "description" => queryParams.SortDescending
                    ? query.OrderByDescending(g => g.Description)
                    : query.OrderBy(g => g.Description),
                "createddate" => queryParams.SortDescending
                    ? query.OrderByDescending(g => g.CreatedDate)
                    : query.OrderBy(g => g.CreatedDate),
                _ => query.OrderBy(g => g.Name)
            };
        }
        else
        {
            query = query.OrderBy(g => g.Name);
        }

        // Get total count before pagination
        var totalCount = await query.CountAsync();

        // Apply pagination
        var genders = await query
            .Skip((queryParams.PageNumber - 1) * queryParams.PageSize)
            .Take(queryParams.PageSize)
            .Select(g => new GenderDto
            {
                GenderId = g.GenderId,
                Name = g.Name,
                Description = g.Description,
                CreatedDate = g.CreatedDate,
                EnteredBy = g.EnteredBy
            })
            .ToListAsync();

        return (genders, totalCount);
    }

    public async Task<GenderDto?> GetGenderByIdAsync(int id)
    {
        var gender = await context.Genders.FindAsync(id);
        
        if (gender == null)
        {
            return null;
        }

        return new GenderDto
        {
            GenderId = gender.GenderId,
            Name = gender.Name,
            Description = gender.Description,
            CreatedDate = gender.CreatedDate,
            EnteredBy = gender.EnteredBy
        };
    }

    public async Task<GenderDto> CreateGenderAsync(CreateGenderDto genderDto, string currentUser)
    {
        var gender = new Gender
        {
            Name = genderDto.Name,
            Description = genderDto.Description,
            CreatedDate = DateTime.UtcNow,
            EnteredBy = currentUser
        };

        context.Genders.Add(gender);
        await context.SaveChangesAsync();

        return new GenderDto
        {
            GenderId = gender.GenderId,
            Name = gender.Name,
            Description = gender.Description,
            CreatedDate = gender.CreatedDate,
            EnteredBy = gender.EnteredBy
        };
    }

    public async Task<GenderDto?> UpdateGenderAsync(int id, UpdateGenderDto genderDto, string currentUser)
    {
        var existingGender = await context.Genders.FindAsync(id);
        
        if (existingGender == null)
        {
            return null;
        }

        existingGender.Name = genderDto.Name;
        existingGender.Description = genderDto.Description;
        existingGender.EnteredBy = currentUser;

        await context.SaveChangesAsync();

        return new GenderDto
        {
            GenderId = existingGender.GenderId,
            Name = existingGender.Name,
            Description = existingGender.Description,
            CreatedDate = existingGender.CreatedDate,
            EnteredBy = existingGender.EnteredBy
        };
    }

    public async Task<bool> DeleteGenderAsync(int id, string currentUser)
    {
        var gender = await context.Genders.FindAsync(id);
        
        if (gender == null)
        {
            return false;
        }

        context.Genders.Remove(gender);
        await context.SaveChangesAsync();
        
        return true;
    }
} 