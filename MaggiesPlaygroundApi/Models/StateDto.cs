namespace MaggiesPlaygroundApi.Models;

public class StateDto
{
    public int StateId { get; set; }
    public string Abbreviation { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
}

public class CreateStateDto
{
    public string Abbreviation { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
}

public class UpdateStateDto
{
    public string Abbreviation { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
}

public class StateQueryParameters
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public string? SearchTerm { get; set; }
    public string? SortBy { get; set; }
    public bool SortDescending { get; set; } = false;
} 