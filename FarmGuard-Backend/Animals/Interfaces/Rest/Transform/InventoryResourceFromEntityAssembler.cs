using FarmGuard_Backend.Animals.Domain.Model.Aggregates;
using FarmGuard_Backend.Animals.Interfaces.Rest.resources;

namespace FarmGuard_Backend.Animals.Interfaces.Rest.Transform;

public class InventoryResourceFromEntityAssembler
{
    public static InventoryResource ToEntityFromResource(Inventory entity)
    {
        return new InventoryResource(entity.Id,entity.Name, entity.ProfileId);
    }
}