namespace MaggiesPlaygroundApi.Models;

public class ClientAddressDto
{
    public Guid ClientAddressId { get; set; }
    public Guid ClientId { get; set; }
    public Guid AddressId { get; set; }
    public bool Active { get; set; }
    public DateTime CreatedDate { get; set; }
    public string EnteredBy { get; set; } = string.Empty;
    
    // Navigation properties
    public ClientDto? Client { get; set; }
    public AddressDto? Address { get; set; }
} 