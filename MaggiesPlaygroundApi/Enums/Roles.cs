namespace MaggiesPlaygroundApi.Enums;

public static class Roles
{
    public const string Admin = "Admin";
    public const string User = "User";
    public const string Manager = "Manager";
    public const string Support = "Support";
    public const string ReadOnly = "ReadOnly";

    public static readonly string[] AllRoles = new[]
    {
        Admin,
        User,
        Manager,
        Support,
        ReadOnly
    };
} 