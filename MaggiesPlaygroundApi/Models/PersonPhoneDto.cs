namespace MaggiesPlaygroundApi.Models;

public class PersonPhoneDto
{
    public Guid PersonPhoneId { get; set; }
    public Guid PersonId { get; set; }
    public Guid PhoneId { get; set; }
    public bool Active { get; set; }
    public DateTime CreatedDate { get; set; }
    public string EnteredBy { get; set; } = string.Empty;
    
    // Navigation properties
    public PersonDto? Person { get; set; }
    public PhoneDto? Phone { get; set; }
} 