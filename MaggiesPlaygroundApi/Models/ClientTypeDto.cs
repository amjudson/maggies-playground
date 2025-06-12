using System.ComponentModel.DataAnnotations;

namespace MaggiesPlaygroundApi.Models;

public class ClientTypeDto
{
    public int ClientTypeId { get; set; }
    
    [Required]
    [StringLength(255)]
    public string Name { get; set; } = string.Empty;
    
    public bool Active { get; set; }
    
    public DateTime CreatedDate { get; set; }
    
    [Required]
    [StringLength(100)]
    public string EnteredBy { get; set; } = string.Empty;
}

public class CreateClientTypeDto
{
    [Required]
    [StringLength(255)]
    public string Name { get; set; } = string.Empty;
    
    public bool Active { get; set; } = true;
    
    [Required]
    [StringLength(100)]
    public string EnteredBy { get; set; } = string.Empty;
}

public class UpdateClientTypeDto
{
    [Required]
    [StringLength(255)]
    public string Name { get; set; } = string.Empty;
    
    public bool Active { get; set; }
    
    [Required]
    [StringLength(100)]
    public string EnteredBy { get; set; } = string.Empty;
}

public class ClientTypeQueryParameters
{
    private const int MaxPageSize = 50;
    private int _pageSize = 10;
    
    public int PageNumber { get; set; } = 1;
    
    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = Math.Min(value, MaxPageSize);
    }
    
    public string? SearchTerm { get; set; }
    public bool? Active { get; set; }
    public string? SortBy { get; set; }
    public bool SortDescending { get; set; }
} 