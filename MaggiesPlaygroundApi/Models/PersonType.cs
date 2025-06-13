using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MaggiesPlaygroundApi.Models;

public class PersonType
{
    [Key]
    public int PersonTypeId { get; set; }
    
    [Required]
    [Column(TypeName = "varchar")]
    public string Description { get; set; } = string.Empty;
    
    public Guid? ClientId { get; set; }
    
    [Required]
    [Column(TypeName = "varchar")]
    public string Name { get; set; } = string.Empty;
    
    [Required]
    public bool ClientOption { get; set; }
    
    [Required]
    public DateTime CreatedDate { get; set; }
    
    [Required]
    [Column(TypeName = "varchar")]
    public string EnteredBy { get; set; } = string.Empty;
    
    [ForeignKey("ClientId")]
    public Client? Client { get; set; }
} 