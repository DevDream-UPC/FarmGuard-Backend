namespace FarmGuard_Backend.profile.Domain.Model.Commands;

public record UpdateProfileCommand(int Id,string FirstName, string LastName, string Email, string UrlPhoto);