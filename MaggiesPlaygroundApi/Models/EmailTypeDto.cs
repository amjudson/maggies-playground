namespace MaggiesPlaygroundApi.Models;

public class EmailTypeDto
{
    public int EmailTypeId { get; set; }
    public string Description { get; set; } = string.Empty;
    public string? ClientId { get; set; }
    public string Name { get; set; } = string.Empty;
    public bool ClientOption { get; set; }
}

public class CreateEmailTypeDto
{
    public string Description { get; set; } = string.Empty;
    public string? ClientId { get; set; }
    public string Name { get; set; } = string.Empty;
    public bool ClientOption { get; set; }
}

public class UpdateEmailTypeDto
{
    public string Description { get; set; } = string.Empty;
    public string? ClientId { get; set; }
    public string Name { get; set; } = string.Empty;
    public bool ClientOption { get; set; }
}

public class EmailTypeQueryParameters
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public string? SearchTerm { get; set; }
    public string? SortBy { get; set; }
    public bool SortDescending { get; set; } = false;
    public string? ClientId { get; set; }
} 