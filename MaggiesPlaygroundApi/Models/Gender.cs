using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MaggiesPlaygroundApi.Models;

public class Gender
{
    [Key]
    public int GenderId { get; set; }
    
    [Required]
    [Column(TypeName = "varchar")]
    public string Description { get; set; } = string.Empty;
    
    [Required]
    [Column(TypeName = "varchar")]
    public string Name { get; set; } = string.Empty;
    
    [Required]
    public DateTime CreatedDate { get; set; }
    
    [Required]
    [Column(TypeName = "varchar")]
    public string EnteredBy { get; set; } = string.Empty;
} 