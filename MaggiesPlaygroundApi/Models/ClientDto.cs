using System.ComponentModel.DataAnnotations;

namespace MaggiesPlaygroundApi.Models;

public class ClientDto
{
    public Guid ClientId { get; set; }
    
    [Required]
    [StringLength(255)]
    public string ClientName { get; set; } = string.Empty;
    
    public bool Active { get; set; }
    
    public DateTime CreatedDate { get; set; }
    
    [Required]
    [StringLength(100)]
    public string EnteredBy { get; set; } = string.Empty;
    
    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "ClientTypeId must be greater than 0")]
    public int ClientTypeId { get; set; }
}

public class CreateClientDto
{
    [Required]
    [StringLength(255)]
    public string ClientName { get; set; } = string.Empty;
    
    public bool Active { get; set; } = true;
    
    [Required]
    [StringLength(100)]
    public string EnteredBy { get; set; } = string.Empty;
    
    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "ClientTypeId must be greater than 0")]
    public int ClientTypeId { get; set; }
}

public class UpdateClientDto
{
    [Required]
    [StringLength(255)]
    public string ClientName { get; set; } = string.Empty;
    
    public bool Active { get; set; }
    
    [Required]
    [StringLength(100)]
    public string EnteredBy { get; set; } = string.Empty;
    
    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "ClientTypeId must be greater than 0")]
    public int ClientTypeId { get; set; }
}

public class ClientQueryParameters
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
    public bool? Active { get; set; }
    public int? ClientTypeId { get; set; }
    public string? SortBy { get; set; }
    public bool SortDescending { get; set; }
} 