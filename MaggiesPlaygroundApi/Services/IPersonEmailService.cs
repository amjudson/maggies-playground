using MaggiesPlaygroundApi.Models;

namespace MaggiesPlaygroundApi.Services;

public interface IPersonEmailService
{
    Task<IEnumerable<PersonEmailDto>> GetAllAsync();
    Task<PersonEmailDto?> GetByIdAsync(Guid id);
    Task<IEnumerable<PersonEmailDto>> GetByPersonIdAsync(Guid personId);
    Task<IEnumerable<PersonEmailDto>> GetByEmailIdAsync(Guid emailId);
    Task<PersonEmailDto> CreateAsync(PersonEmailDto personEmailDto);
    Task<PersonEmailDto> UpdateAsync(Guid id, PersonEmailDto personEmailDto);
    Task<bool> DeleteAsync(Guid id);
    Task<bool> ExistsAsync(Guid id);
} 