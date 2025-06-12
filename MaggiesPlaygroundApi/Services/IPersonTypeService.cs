using MaggiesPlaygroundApi.Models;

namespace MaggiesPlaygroundApi.Services;

public interface IPersonTypeService
{
    Task<(IEnumerable<PersonTypeDto> PersonTypes, int TotalCount)> GetPersonTypesAsync(PersonTypeQueryParameters queryParams);
    Task<PersonTypeDto?> GetPersonTypeByIdAsync(int id);
    Task<PersonTypeDto> CreatePersonTypeAsync(CreatePersonTypeDto personTypeDto, string currentUser);
    Task<PersonTypeDto?> UpdatePersonTypeAsync(int id, UpdatePersonTypeDto personTypeDto, string currentUser);
    Task<bool> DeletePersonTypeAsync(int id, string currentUser);
} 