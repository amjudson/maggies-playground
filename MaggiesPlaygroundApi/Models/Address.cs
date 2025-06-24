using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MaggiesPlaygroundApi.Models;

public class Address
{
    [Key]
    public Guid AddressId { get; set; }
    
    [Required]
    [Column(TypeName = "varchar")]
    public string AddressLine1 { get; set; } = string.Empty;
    
    [Column(TypeName = "varchar")]
    public string? AddressLine2 { get; set; }
    
    [Required]
    [Column(TypeName = "varchar")]
    public string City { get; set; } = string.Empty;
    
    [Required]
    public int StateId { get; set; }
    
    [Required]
    [Column(TypeName = "varchar")]
    public string Zip { get; set; } = string.Empty;
    
    [Required]
    public int AddressTypeId { get; set; }
} 