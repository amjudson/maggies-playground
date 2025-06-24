using MaggiesPlaygroundApi.Models;

namespace MaggiesPlaygroundApi.Services;

public interface IClientTypeService
{
    Task<IEnumerable<ClientTypeDto>> GetAllAsync(int page = 1, int pageSize = 10, string? searchTerm = null);
    Task<ClientTypeDto?> GetByIdAsync(int id);
    Task<ClientTypeDto> CreateAsync(ClientTypeDto clientTypeDto);
    Task<ClientTypeDto> UpdateAsync(int id, ClientTypeDto clientTypeDto);
    Task<bool> DeleteAsync(int id);
} 