using System.ComponentModel.DataAnnotations;

namespace MaggiesPlaygroundApi.Models;

public class PersonDto
{
    public Guid PersonId { get; set; }
    
    [Required]
    [StringLength(255)]
    public string LastName { get; set; } = string.Empty;
    
    [Required]
    [StringLength(255)]
    public string FirstName { get; set; } = string.Empty;
    
    [StringLength(255)]
    public string? MiddleName { get; set; }
    
    [StringLength(255)]
    public string? Suffix { get; set; }
    
    [StringLength(255)]
    public string? Prefix { get; set; }
    
    [Required]
    public int PersonTypeId { get; set; }
    
    [Required]
    [StringLength(255)]
    public string Alias { get; set; } = string.Empty;
    
    [Required]
    public int RaceId { get; set; }
    
    [Required]
    public DateTime DateOfBirth { get; set; }
    
    [Required]
    public int GenderId { get; set; }
    
    public DateTime CreatedDate { get; set; }
    
    [Required]
    [StringLength(100)]
    public string EnteredBy { get; set; } = string.Empty;
    
    public PersonTypeDto? PersonType { get; set; }
    public RaceDto? Race { get; set; }
    public GenderDto? Gender { get; set; }
}

public class CreatePersonDto
{
    [Required]
    [StringLength(255)]
    public string LastName { get; set; } = string.Empty;
    
    [Required]
    [StringLength(255)]
    public string FirstName { get; set; } = string.Empty;
    
    [StringLength(255)]
    public string? MiddleName { get; set; }
    
    [StringLength(255)]
    public string? Suffix { get; set; }
    
    [StringLength(255)]
    public string? Prefix { get; set; }
    
    [Required]
    public int PersonTypeId { get; set; }
    
    [Required]
    [StringLength(255)]
    public string Alias { get; set; } = string.Empty;
    
    [Required]
    public int RaceId { get; set; }
    
    [Required]
    public DateTime DateOfBirth { get; set; }
    
    [Required]
    public int GenderId { get; set; }
    
    [Required]
    [StringLength(100)]
    public string EnteredBy { get; set; } = string.Empty;
}

public class UpdatePersonDto
{
    [Required]
    [StringLength(255)]
    public string LastName { get; set; } = string.Empty;
    
    [Required]
    [StringLength(255)]
    public string FirstName { get; set; } = string.Empty;
    
    [StringLength(255)]
    public string? MiddleName { get; set; }
    
    [StringLength(255)]
    public string? Suffix { get; set; }
    
    [StringLength(255)]
    public string? Prefix { get; set; }
    
    [Required]
    public int PersonTypeId { get; set; }
    
    [Required]
    [StringLength(255)]
    public string Alias { get; set; } = string.Empty;
    
    [Required]
    public int RaceId { get; set; }
    
    [Required]
    public DateTime DateOfBirth { get; set; }
    
    [Required]
    public int GenderId { get; set; }
    
    [Required]
    [StringLength(100)]
    public string EnteredBy { get; set; } = string.Empty;
}

public class PersonQueryParameters
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
    public int? PersonTypeId { get; set; }
    public int? RaceId { get; set; }
    public int? GenderId { get; set; }
    public string? SortBy { get; set; }
    public bool SortDescending { get; set; }
} 