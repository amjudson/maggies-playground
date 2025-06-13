using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MaggiesPlaygroundApi.Models;

public class Person
{
    [Key]
    public Guid PersonId { get; set; }
    
    [Required]
    [Column(TypeName = "varchar")]
    public string LastName { get; set; } = string.Empty;
    
    [Required]
    [Column(TypeName = "varchar")]
    public string FirstName { get; set; } = string.Empty;
    
    [Column(TypeName = "varchar")]
    public string? MiddleName { get; set; }
    
    [Column(TypeName = "varchar")]
    public string? Suffix { get; set; }
    
    [Column(TypeName = "varchar")]
    public string? Prefix { get; set; }
    
    [Required]
    public int PersonTypeId { get; set; }
    
    [Required]
    [Column(TypeName = "varchar")]
    public string Alias { get; set; } = string.Empty;
    
    [Required]
    public int RaceId { get; set; }
    
    [Required]
    public DateTime DateOfBirth { get; set; }
    
    [Required]
    public int GenderId { get; set; }
    
    [Required]
    public DateTime CreatedDate { get; set; }
    
    [Required]
    [Column(TypeName = "varchar")]
    public string EnteredBy { get; set; } = string.Empty;
    
    [ForeignKey("PersonTypeId")]
    public PersonType? PersonType { get; set; }
    
    [ForeignKey("RaceId")]
    public Race? Race { get; set; }
    
    [ForeignKey("GenderId")]
    public Gender? Gender { get; set; }
} 