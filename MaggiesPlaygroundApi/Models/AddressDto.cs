namespace MaggiesPlaygroundApi.Models;

public class AddressDto
{
    public Guid AddressId { get; set; }
    public string AddressLine1 { get; set; } = string.Empty;
    public string? AddressLine2 { get; set; }
    public string City { get; set; } = string.Empty;
    public int StateId { get; set; }
    public string Zip { get; set; } = string.Empty;
    public int AddressTypeId { get; set; }
}

public class CreateAddressDto
{
    public string AddressLine1 { get; set; } = string.Empty;
    public string? AddressLine2 { get; set; }
    public string City { get; set; } = string.Empty;
    public int StateId { get; set; }
    public string Zip { get; set; } = string.Empty;
    public int AddressTypeId { get; set; }
}

public class UpdateAddressDto
{
    public string AddressLine1 { get; set; } = string.Empty;
    public string? AddressLine2 { get; set; }
    public string City { get; set; } = string.Empty;
    public int StateId { get; set; }
    public string Zip { get; set; } = string.Empty;
    public int AddressTypeId { get; set; }
}

public class AddressQueryParameters
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public string? SearchTerm { get; set; }
    public string? SortBy { get; set; }
    public bool SortDescending { get; set; } = false;
    public int? AddressTypeId { get; set; }
    public int? StateId { get; set; }
} 