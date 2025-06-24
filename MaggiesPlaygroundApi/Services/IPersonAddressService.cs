using MaggiesPlaygroundApi.Models;

namespace MaggiesPlaygroundApi.Services;

public interface IPersonAddressService
{
    Task<IEnumerable<PersonAddressDto>> GetAllAsync();
    Task<PersonAddressDto?> GetByIdAsync(Guid id);
    Task<IEnumerable<PersonAddressDto>> GetByPersonIdAsync(Guid personId);
    Task<IEnumerable<PersonAddressDto>> GetByAddressIdAsync(Guid addressId);
    Task<PersonAddressDto> CreateAsync(PersonAddressDto personAddressDto);
    Task<PersonAddressDto> UpdateAsync(Guid id, PersonAddressDto personAddressDto);
    Task<bool> DeleteAsync(Guid id);
    Task<bool> ExistsAsync(Guid id);
} 