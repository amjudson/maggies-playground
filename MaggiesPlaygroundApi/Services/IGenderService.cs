using MaggiesPlaygroundApi.Models;

namespace MaggiesPlaygroundApi.Services;

public interface IGenderService
{
    Task<(IEnumerable<GenderDto> Genders, int TotalCount)> GetGendersAsync(GenderQueryParameters queryParams);
    Task<GenderDto?> GetGenderByIdAsync(int id);
    Task<GenderDto> CreateGenderAsync(CreateGenderDto genderDto, string currentUser);
    Task<GenderDto?> UpdateGenderAsync(int id, UpdateGenderDto genderDto, string currentUser);
    Task<bool> DeleteGenderAsync(int id, string currentUser);
} 