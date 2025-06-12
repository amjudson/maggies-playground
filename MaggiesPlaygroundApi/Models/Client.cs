using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MaggiesPlaygroundApi.Models;

public class Client
{
    [Key]
    public Guid ClientId { get; set; }
    
    [Required]
    [Column(TypeName = "varchar")]
    public string ClientName { get; set; } = string.Empty;
    
    [Required]
    public bool Active { get; set; }
    
    [Required]
    public DateTime CreatedDate { get; set; }
    
    [Required]
    [Column(TypeName = "varchar")]
    public string EnteredBy { get; set; } = string.Empty;
    
    [Required]
    public int ClientTypeId { get; set; }
} 