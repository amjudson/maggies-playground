using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MaggiesPlaygroundApi.Models;

public class ClientEmail
{
    [Key]
    public Guid ClientEmailId { get; set; }
    
    [Required]
    public Guid ClientId { get; set; }
    
    [Required]
    public Guid EmailId { get; set; }
    
    [Required]
    public bool Active { get; set; }
    
    [Required]
    public DateTime CreatedDate { get; set; }
    
    [Required]
    [Column(TypeName = "varchar")]
    public string EnteredBy { get; set; } = string.Empty;
    
    [ForeignKey("ClientId")]
    public Client? Client { get; set; }
    
    [ForeignKey("EmailId")]
    public Email? Email { get; set; }
} 