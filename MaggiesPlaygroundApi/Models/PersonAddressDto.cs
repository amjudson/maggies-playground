namespace MaggiesPlaygroundApi.Models;

public class PersonAddressDto
{
    public Guid PersonAddressId { get; set; }
    public Guid PersonId { get; set; }
    public Guid AddressId { get; set; }
    public bool Active { get; set; }
    public DateTime CreatedDate { get; set; }
    public string EnteredBy { get; set; } = string.Empty;
    
    // Navigation properties
    public PersonDto? Person { get; set; }
    public AddressDto? Address { get; set; }
} 