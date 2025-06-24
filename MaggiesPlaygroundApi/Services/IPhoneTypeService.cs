using MaggiesPlaygroundApi.Models;

namespace MaggiesPlaygroundApi.Services;

public interface IPhoneTypeService
{
    Task<(IEnumerable<PhoneTypeDto> PhoneTypes, int TotalCount)> GetPhoneTypesAsync(PhoneTypeQueryParameters queryParams);
    Task<PhoneTypeDto?> GetPhoneTypeByIdAsync(int id);
    Task<PhoneTypeDto> CreatePhoneTypeAsync(CreatePhoneTypeDto phoneTypeDto, string currentUser);
    Task<PhoneTypeDto?> UpdatePhoneTypeAsync(int id, UpdatePhoneTypeDto phoneTypeDto, string currentUser);
    Task<bool> DeletePhoneTypeAsync(int id, string currentUser);
} 