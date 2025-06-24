using MaggiesPlaygroundApi.Models;

namespace MaggiesPlaygroundApi.Services;

public interface IPersonPhoneService
{
    Task<IEnumerable<PersonPhoneDto>> GetAllAsync();
    Task<PersonPhoneDto?> GetByIdAsync(Guid id);
    Task<IEnumerable<PersonPhoneDto>> GetByPersonIdAsync(Guid personId);
    Task<IEnumerable<PersonPhoneDto>> GetByPhoneIdAsync(Guid phoneId);
    Task<PersonPhoneDto> CreateAsync(PersonPhoneDto personPhoneDto, string enteredBy);
    Task<PersonPhoneDto> UpdateAsync(Guid id, PersonPhoneDto personPhoneDto, string enteredBy);
    Task<bool> DeleteAsync(Guid id);
    Task<bool> ExistsAsync(Guid id);
} 