using MaggiesPlaygroundApi.Models;

namespace MaggiesPlaygroundApi.Services;

public interface IAddressTypeService
{
    Task<(IEnumerable<AddressTypeDto> AddressTypes, int TotalCount)> GetAddressTypesAsync(AddressTypeQueryParameters queryParams);
    Task<AddressTypeDto?> GetAddressTypeByIdAsync(int id);
    Task<AddressTypeDto> CreateAddressTypeAsync(CreateAddressTypeDto addressTypeDto, string currentUser);
    Task<AddressTypeDto?> UpdateAddressTypeAsync(int id, UpdateAddressTypeDto addressTypeDto, string currentUser);
    Task<bool> DeleteAddressTypeAsync(int id, string currentUser);
} 