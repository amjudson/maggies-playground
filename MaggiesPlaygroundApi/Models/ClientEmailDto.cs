namespace MaggiesPlaygroundApi.Models;

public class ClientEmailDto
{
    public Guid ClientEmailId { get; set; }
    public Guid ClientId { get; set; }
    public Guid EmailId { get; set; }
    public bool Active { get; set; }
    public DateTime CreatedDate { get; set; }
    public string EnteredBy { get; set; } = string.Empty;
    
    // Navigation properties
    public ClientDto? Client { get; set; }
    public EmailDto? Email { get; set; }
} 