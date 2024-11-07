namespace FarmGuard_Backend.IAM.Interfaces.REST.Resources;

public record SignUpResource(string Username, string Password,string FirstName, string LastName, string Email, string UrlPhoto);