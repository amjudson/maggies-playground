using MaggiesPlaygroundApi.Models;

namespace MaggiesPlaygroundApi.Services;

public interface IAddressService
{
    Task<(IEnumerable<AddressDto> Addresses, int TotalCount)> GetAddressesAsync(AddressQueryParameters queryParams);
    Task<AddressDto?> GetAddressByIdAsync(Guid id);
    Task<AddressDto> CreateAddressAsync(CreateAddressDto addressDto, string currentUser);
    Task<AddressDto?> UpdateAddressAsync(Guid id, UpdateAddressDto addressDto, string currentUser);
    Task<bool> DeleteAddressAsync(Guid id, string currentUser);
} 