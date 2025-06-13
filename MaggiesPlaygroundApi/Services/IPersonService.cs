using MaggiesPlaygroundApi.Models;

namespace MaggiesPlaygroundApi.Services;

public interface IPersonService
{
    Task<(IEnumerable<PersonDto> People, int TotalCount)> GetPeopleAsync(PersonQueryParameters queryParams);
    Task<PersonDto?> GetPersonByIdAsync(Guid id);
    Task<PersonDto> CreatePersonAsync(CreatePersonDto personDto, string currentUser);
    Task<PersonDto?> UpdatePersonAsync(Guid id, UpdatePersonDto personDto, string currentUser);
    Task<bool> DeletePersonAsync(Guid id, string currentUser);
} 