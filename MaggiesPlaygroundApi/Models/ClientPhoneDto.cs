namespace MaggiesPlaygroundApi.Models;

public class ClientPhoneDto
{
    public Guid ClientPhoneId { get; set; }
    public Guid ClientId { get; set; }
    public Guid PhoneId { get; set; }
    public bool Active { get; set; }
    public DateTime CreatedDate { get; set; }
    public string EnteredBy { get; set; } = string.Empty;
    
    // Navigation properties
    public ClientDto? Client { get; set; }
    public PhoneDto? Phone { get; set; }
} 