using MaggiesPlaygroundApi.Models;

namespace MaggiesPlaygroundApi.Services;

public interface IEmailService
{
    Task<(IEnumerable<EmailDto> Emails, int TotalCount)> GetEmailsAsync(EmailQueryParameters queryParams);
    Task<EmailDto?> GetEmailByIdAsync(Guid id);
    Task<EmailDto> CreateEmailAsync(CreateEmailDto emailDto, string currentUser);
    Task<EmailDto?> UpdateEmailAsync(Guid id, UpdateEmailDto emailDto, string currentUser);
    Task<bool> DeleteEmailAsync(Guid id, string currentUser);
} 