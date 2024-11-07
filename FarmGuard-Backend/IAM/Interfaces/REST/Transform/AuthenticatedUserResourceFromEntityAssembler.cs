using FarmGuard_Backend.IAM.Domain.Model.Aggregates;
using FarmGuard_Backend.IAM.Interfaces.REST.Resources;

namespace FarmGuard_Backend.IAM.Interfaces.REST.Transform;

public static class AuthenticatedUserResourceFromEntityAssembler
{
    public static AuthenticatedUserResource ToResourceFromEntity(
        User user, string token, int inventoryId)
    {
        return new AuthenticatedUserResource(user.Id, user.Username,user.IdProfile,inventoryId, token);
    }
}