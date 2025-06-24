namespace MaggiesPlaygroundApi.Models;

public class PersonClientDto
{
    public Guid PersonClientId { get; set; }
    public Guid PersonId { get; set; }
    public Guid ClientId { get; set; }
    public bool Active { get; set; }
    public DateTime CreatedDate { get; set; }
    public string EnteredBy { get; set; } = string.Empty;
    
    // Navigation properties
    public PersonDto? Person { get; set; }
    public ClientDto? Client { get; set; }
} 