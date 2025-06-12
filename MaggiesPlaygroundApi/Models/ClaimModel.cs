using System.ComponentModel.DataAnnotations;

namespace MaggiesPlaygroundApi.Models;

public class ClaimModel
{
    [Required]
    public string Type { get; set; } = string.Empty;

    [Required]
    public string Value { get; set; } = string.Empty;
} 