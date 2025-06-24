using MaggiesPlaygroundApi.Models;

namespace MaggiesPlaygroundApi.Services;

public interface IClientService
{
    Task<IEnumerable<ClientDto>> GetAllAsync(int page = 1, int pageSize = 10, string? searchTerm = null);
    Task<ClientDto?> GetByIdAsync(Guid id);
    Task<ClientDto> CreateAsync(ClientDto clientDto);
    Task<ClientDto> UpdateAsync(Guid id, ClientDto clientDto);
    Task<bool> DeleteAsync(Guid id);
} 