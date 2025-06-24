namespace MaggiesPlaygroundApi.Models;

public class PhoneDto
{
    public Guid PhoneId { get; set; }
    public string PhoneNumber { get; set; } = string.Empty;
    public string? Extension { get; set; }
    public int PhoneTypeId { get; set; }
}

public class CreatePhoneDto
{
    public string PhoneNumber { get; set; } = string.Empty;
    public string? Extension { get; set; }
    public int PhoneTypeId { get; set; }
}

public class UpdatePhoneDto
{
    public string PhoneNumber { get; set; } = string.Empty;
    public string? Extension { get; set; }
    public int PhoneTypeId { get; set; }
}

public class PhoneQueryParameters
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public string? SearchTerm { get; set; }
    public string? SortBy { get; set; }
    public bool SortDescending { get; set; } = false;
    public int? PhoneTypeId { get; set; }
} 