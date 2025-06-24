using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MaggiesPlaygroundApi.Models;

public class Phone
{
    [Key]
    public Guid PhoneId { get; set; }
    
    [Required]
    [Column(TypeName = "varchar")]
    public string PhoneNumber { get; set; } = string.Empty;
    
    [Column(TypeName = "varchar")]
    public string? Extension { get; set; }
    
    [Required]
    public int PhoneTypeId { get; set; }
    
    [ForeignKey("PhoneTypeId")]
    public PhoneType? PhoneType { get; set; }
} 