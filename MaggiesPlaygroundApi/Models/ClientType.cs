using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MaggiesPlaygroundApi.Models;

public class ClientType
{
    [Key]
    public int ClientTypeId { get; set; }
    
    [Required]
    [Column(TypeName = "varchar")]
    public string Name { get; set; } = string.Empty;
    
    [Required]
    public bool Active { get; set; }
    
    [Required]
    public DateTime CreatedDate { get; set; }
    
    [Required]
    [Column(TypeName = "varchar")]
    public string EnteredBy { get; set; } = string.Empty;
} 