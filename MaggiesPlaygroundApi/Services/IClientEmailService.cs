using MaggiesPlaygroundApi.Models;

namespace MaggiesPlaygroundApi.Services;

public interface IClientEmailService
{
    Task<IEnumerable<ClientEmailDto>> GetAllAsync();
    Task<ClientEmailDto?> GetByIdAsync(Guid id);
    Task<IEnumerable<ClientEmailDto>> GetByClientIdAsync(Guid clientId);
    Task<IEnumerable<ClientEmailDto>> GetByEmailIdAsync(Guid emailId);
    Task<ClientEmailDto> CreateAsync(ClientEmailDto clientEmailDto, string enteredBy);
    Task<ClientEmailDto> UpdateAsync(Guid id, ClientEmailDto clientEmailDto, string enteredBy);
    Task<bool> DeleteAsync(Guid id);
    Task<bool> ExistsAsync(Guid id);
} 