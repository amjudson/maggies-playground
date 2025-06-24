namespace MaggiesPlaygroundApi.Models;

public class EmailDto
{
    public Guid EmailId { get; set; }
    public string EmailAddress { get; set; } = string.Empty;
    public int EmailTypeId { get; set; }
}

public class CreateEmailDto
{
    public string EmailAddress { get; set; } = string.Empty;
    public int EmailTypeId { get; set; }
}

public class UpdateEmailDto
{
    public string EmailAddress { get; set; } = string.Empty;
    public int EmailTypeId { get; set; }
}

public class EmailQueryParameters
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public string? SearchTerm { get; set; }
    public string? SortBy { get; set; }
    public bool SortDescending { get; set; } = false;
    public int? EmailTypeId { get; set; }
} 