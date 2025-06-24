using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MaggiesPlaygroundApi.Models;

public class EmailType
{
    [Key]
    public int EmailTypeId { get; set; }
    
    [Required]
    [Column(TypeName = "varchar")]
    public string Description { get; set; } = string.Empty;
    
    [Column(TypeName = "varchar")]
    public string? ClientId { get; set; }
    
    [Required]
    [Column(TypeName = "varchar")]
    public string Name { get; set; } = string.Empty;
    
    [Required]
    public bool ClientOption { get; set; }
} 