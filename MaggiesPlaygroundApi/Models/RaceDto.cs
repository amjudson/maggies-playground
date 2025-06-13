using System.ComponentModel.DataAnnotations;

namespace MaggiesPlaygroundApi.Models;

public class RaceDto
{
    public int RaceId { get; set; }
    
    [Required]
    [StringLength(255)]
    public string Description { get; set; } = string.Empty;
    
    [Required]
    [StringLength(255)]
    public string Name { get; set; } = string.Empty;
    
    public DateTime CreatedDate { get; set; }
    
    [Required]
    [StringLength(100)]
    public string EnteredBy { get; set; } = string.Empty;
}

public class CreateRaceDto
{
    [Required]
    [StringLength(255)]
    public string Description { get; set; } = string.Empty;
    
    [Required]
    [StringLength(255)]
    public string Name { get; set; } = string.Empty;
    
    [Required]
    [StringLength(100)]
    public string EnteredBy { get; set; } = string.Empty;
}

public class UpdateRaceDto
{
    [Required]
    [StringLength(255)]
    public string Description { get; set; } = string.Empty;
    
    [Required]
    [StringLength(255)]
    public string Name { get; set; } = string.Empty;
    
    [Required]
    [StringLength(100)]
    public string EnteredBy { get; set; } = string.Empty;
}

public class RaceQueryParameters
{
    private const int MaxPageSize = 50;
    private int pageSize = 10;
    
    public int PageNumber { get; set; } = 1;
    
    public int PageSize
    {
        get => pageSize;
        set => pageSize = Math.Min(value, MaxPageSize);
    }
    
    public string? SearchTerm { get; set; }
    public string? SortBy { get; set; }
    public bool SortDescending { get; set; }
} 