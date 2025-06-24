using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MaggiesPlaygroundApi.Models;

public class State
{
    [Key]
    public int StateId { get; set; }
    
    [Required]
    [Column(TypeName = "varchar")]
    public string Abbreviation { get; set; } = string.Empty;
    
    [Required]
    [Column(TypeName = "varchar")]
    public string Name { get; set; } = string.Empty;
} 