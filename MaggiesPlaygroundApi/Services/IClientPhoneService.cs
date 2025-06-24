using MaggiesPlaygroundApi.Models;

namespace MaggiesPlaygroundApi.Services;

public interface IClientPhoneService
{
    Task<IEnumerable<ClientPhoneDto>> GetAllAsync();
    Task<ClientPhoneDto?> GetByIdAsync(Guid id);
    Task<IEnumerable<ClientPhoneDto>> GetByClientIdAsync(Guid clientId);
    Task<IEnumerable<ClientPhoneDto>> GetByPhoneIdAsync(Guid phoneId);
    Task<ClientPhoneDto> CreateAsync(ClientPhoneDto clientPhoneDto);
    Task<ClientPhoneDto> UpdateAsync(Guid id, ClientPhoneDto clientPhoneDto);
    Task<bool> DeleteAsync(Guid id);
    Task<bool> ExistsAsync(Guid id);
} 