using MaggiesPlaygroundApi.Models;

namespace MaggiesPlaygroundApi.Services;

public interface IPhoneService
{
    Task<(IEnumerable<PhoneDto> Phones, int TotalCount)> GetPhonesAsync(PhoneQueryParameters queryParams);
    Task<PhoneDto?> GetPhoneByIdAsync(Guid id);
    Task<PhoneDto> CreatePhoneAsync(CreatePhoneDto phoneDto, string currentUser);
    Task<PhoneDto?> UpdatePhoneAsync(Guid id, UpdatePhoneDto phoneDto, string currentUser);
    Task<bool> DeletePhoneAsync(Guid id, string currentUser);
} 