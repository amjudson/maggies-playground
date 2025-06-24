using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MaggiesPlaygroundApi.Models;

public class Email
{
    [Key]
    public Guid EmailId { get; set; }
    
    [Required]
    [Column(TypeName = "varchar")]
    public string EmailAddress { get; set; } = string.Empty;
    
    [Required]
    public int EmailTypeId { get; set; }
} 