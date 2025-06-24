using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MaggiesPlaygroundApi.Models;

public class ClientPhone
{
    [Key]
    public Guid ClientPhoneId { get; set; }
    
    [Required]
    public Guid ClientId { get; set; }
    
    [Required]
    public Guid PhoneId { get; set; }
    
    [Required]
    public bool Active { get; set; }
    
    [Required]
    public DateTime CreatedDate { get; set; }
    
    [Required]
    [Column(TypeName = "varchar")]
    public string EnteredBy { get; set; } = string.Empty;
    
    [ForeignKey("ClientId")]
    public Client? Client { get; set; }
    
    [ForeignKey("PhoneId")]
    public Phone? Phone { get; set; }
} 