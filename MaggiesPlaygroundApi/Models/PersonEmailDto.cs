namespace MaggiesPlaygroundApi.Models;

public class PersonEmailDto
{
    public Guid PersonEmailId { get; set; }
    public Guid PersonId { get; set; }
    public Guid EmailId { get; set; }
    public bool Active { get; set; }
    public DateTime CreatedDate { get; set; }
    public string EnteredBy { get; set; } = string.Empty;
    
    // Navigation properties
    public PersonDto? Person { get; set; }
    public EmailDto? Email { get; set; }
} 