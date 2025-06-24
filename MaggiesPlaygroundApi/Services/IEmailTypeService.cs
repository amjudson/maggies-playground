using MaggiesPlaygroundApi.Models;

namespace MaggiesPlaygroundApi.Services;

public interface IEmailTypeService
{
    Task<(IEnumerable<EmailTypeDto> EmailTypes, int TotalCount)> GetEmailTypesAsync(EmailTypeQueryParameters queryParams);
    Task<EmailTypeDto?> GetEmailTypeByIdAsync(int id);
    Task<EmailTypeDto> CreateEmailTypeAsync(CreateEmailTypeDto emailTypeDto, string currentUser);
    Task<EmailTypeDto?> UpdateEmailTypeAsync(int id, UpdateEmailTypeDto emailTypeDto, string currentUser);
    Task<bool> DeleteEmailTypeAsync(int id, string currentUser);
} 