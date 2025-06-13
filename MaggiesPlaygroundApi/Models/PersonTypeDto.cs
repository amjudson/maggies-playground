using System.ComponentModel.DataAnnotations;

namespace MaggiesPlaygroundApi.Models;

public class PersonTypeDto
{
    public int PersonTypeId { get; set; }
    
    [Required]
    [StringLength(255)]
    public string Description { get; set; } = string.Empty;
    
    public Guid? ClientId { get; set; }
    
    [Required]
    [StringLength(255)]
    public string Name { get; set; } = string.Empty;
    
    [Required]
    public bool ClientOption { get; set; }
    
    public DateTime CreatedDate { get; set; }
    
    [Required]
    [StringLength(100)]
    public string EnteredBy { get; set; } = string.Empty;
}

public class CreatePersonTypeDto
{
    [Required]
    [StringLength(255)]
    public string Description { get; set; } = string.Empty;
    
    public Guid? ClientId { get; set; }
    
    [Required]
    [StringLength(255)]
    public string Name { get; set; } = string.Empty;
    
    [Required]
    public bool ClientOption { get; set; }
    
    [Required]
    [StringLength(100)]
    public string EnteredBy { get; set; } = string.Empty;
}

public class UpdatePersonTypeDto
{
    [Required]
    [StringLength(255)]
    public string Description { get; set; } = string.Empty;
    
    public Guid? ClientId { get; set; }
    
    [Required]
    [StringLength(255)]
    public string Name { get; set; } = string.Empty;
    
    [Required]
    public bool ClientOption { get; set; }
    
    [Required]
    [StringLength(100)]
    public string EnteredBy { get; set; } = string.Empty;
}

public class PersonTypeQueryParameters
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
    public Guid? ClientId { get; set; }
    public bool? ClientOption { get; set; }
    public string? SortBy { get; set; }
    public bool SortDescending { get; set; }
} 