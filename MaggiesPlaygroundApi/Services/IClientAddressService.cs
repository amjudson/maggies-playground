using MaggiesPlaygroundApi.Models;

namespace MaggiesPlaygroundApi.Services;

public interface IClientAddressService
{
    Task<IEnumerable<ClientAddressDto>> GetAllAsync();
    Task<ClientAddressDto?> GetByIdAsync(Guid id);
    Task<IEnumerable<ClientAddressDto>> GetByClientIdAsync(Guid clientId);
    Task<IEnumerable<ClientAddressDto>> GetByAddressIdAsync(Guid addressId);
    Task<ClientAddressDto> CreateAsync(ClientAddressDto clientAddressDto);
    Task<ClientAddressDto> UpdateAsync(Guid id, ClientAddressDto clientAddressDto);
    Task<bool> DeleteAsync(Guid id);
    Task<bool> ExistsAsync(Guid id);
} 