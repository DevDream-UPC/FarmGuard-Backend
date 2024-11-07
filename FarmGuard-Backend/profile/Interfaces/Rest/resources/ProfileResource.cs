namespace FarmGuard_Backend.profile.Interfaces.Rest.Transform;

public record ProfileResource(int Id,string FirstName, string LastName, string? Email, string UrlPhoto, int IdInventory,int UserId);