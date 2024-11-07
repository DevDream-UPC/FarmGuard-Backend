namespace FarmGuard_Backend.IAM.Interfaces.REST.Resources;

public record AuthenticatedUserResource(int Id, string Username,int ProfileId,int InventoryId ,string Token);