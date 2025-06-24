using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MaggiesPlaygroundApi.Models;

public class PersonAddress
{
    [Key]
    public Guid PersonAddressId { get; set; }
    
    [Required]
    public Guid PersonId { get; set; }
    
    [Required]
    public Guid AddressId { get; set; }
    
    [Required]
    public bool Active { get; set; }
    
    [Required]
    public DateTime CreatedDate { get; set; }
    
    [Required]
    [Column(TypeName = "varchar")]
    public string EnteredBy { get; set; } = string.Empty;
    
    [ForeignKey("PersonId")]
    public Person? Person { get; set; }
    
    [ForeignKey("AddressId")]
    public Address? Address { get; set; }
} 