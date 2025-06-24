using MaggiesPlaygroundApi.Models;

namespace MaggiesPlaygroundApi.Services;

public interface IPersonClientService
{
    Task<IEnumerable<PersonClientDto>> GetAllAsync();
    Task<PersonClientDto?> GetByIdAsync(Guid personClientId);
    Task<IEnumerable<PersonClientDto>> GetByPersonIdAsync(Guid personId);
    Task<IEnumerable<PersonClientDto>> GetByClientIdAsync(Guid clientId);
    Task<PersonClientDto> CreateAsync(PersonClientDto personClientDto);
    Task<PersonClientDto> UpdateAsync(Guid personClientId, PersonClientDto personClientDto);
    Task<bool> DeleteAsync(Guid personClientId);
    Task<bool> ExistsAsync(Guid personClientId);
} 