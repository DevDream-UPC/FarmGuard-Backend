using FarmGuard_Backend.profile.Domain.Model.Aggregate;

namespace FarmGuard_Backend.profile.Interfaces.Rest.Transform;

public class ProfileResourceFromEntityAssembler
{
    public static ProfileResource ToResourceFromEntity(Profile entity)
    {
        return new ProfileResource(
            entity.Id,
            entity.Name.FirstName,
            entity.Name.LastName,
            entity.Email.EAddress,
            entity.UrlPhoto,
            entity.InventoryId,
            entity.UserId);
    }
}