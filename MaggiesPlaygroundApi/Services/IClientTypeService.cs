using MaggiesPlaygroundApi.Models;

namespace MaggiesPlaygroundApi.Services;

public interface IClientTypeService
{
    Task<(IEnumerable<ClientTypeDto> ClientTypes, int TotalCount)> GetClientTypesAsync(ClientTypeQueryParameters queryParams);
    Task<ClientTypeDto?> GetClientTypeByIdAsync(int id);
    Task<ClientTypeDto> CreateClientTypeAsync(CreateClientTypeDto clientTypeDto, string currentUser);
    Task<ClientTypeDto?> UpdateClientTypeAsync(int id, UpdateClientTypeDto clientTypeDto, string currentUser);
    Task<bool> DeleteClientTypeAsync(int id, string currentUser);
} 