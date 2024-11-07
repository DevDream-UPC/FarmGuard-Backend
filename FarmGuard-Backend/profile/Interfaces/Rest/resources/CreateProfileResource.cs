namespace FarmGuard_Backend.profile.Interfaces.Rest.Transform;

public record CreateProfileResource(string FirstName, string LastName, string Email, string UrlPhoto, int UserId);