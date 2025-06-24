using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MaggiesPlaygroundApi.Models;

public class PersonEmail
{
    [Key]
    public Guid PersonEmailId { get; set; }
    
    [Required]
    public Guid PersonId { get; set; }
    
    [Required]
    public Guid EmailId { get; set; }
    
    [Required]
    public bool Active { get; set; }
    
    [Required]
    public DateTime CreatedDate { get; set; }
    
    [Required]
    [Column(TypeName = "varchar")]
    public string EnteredBy { get; set; } = string.Empty;
    
    [ForeignKey("PersonId")]
    public Person? Person { get; set; }
    
    [ForeignKey("EmailId")]
    public Email? Email { get; set; }
} 