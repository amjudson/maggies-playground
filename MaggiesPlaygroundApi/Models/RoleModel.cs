using System.ComponentModel.DataAnnotations;

namespace MaggiesPlaygroundApi.Models;

public class RoleModel
{
    [Required]
    public string Name { get; set; } = string.Empty;
} 