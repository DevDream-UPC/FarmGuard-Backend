namespace FarmGuard_Backend.profile.Domain.Model.Commands;

public record CreateProfileCommand(string FirstName, string LastName, string Email, string UrlPhoto);