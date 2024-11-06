using FarmGuard_Backend.Animals.Domain.Model.Aggregates;
using FarmGuard_Backend.Animals.Interfaces.Rest.resources;

namespace FarmGuard_Backend.Animals.Interfaces.Rest.Transform;

public class AnimalResourceFromEntityAssembler
{
    public static AnimalResource ToResourceFromEntity(Animal entity)
    {
        return new AnimalResource(
            entity.Id,
            entity.Name,
            entity.SerialNumber.Number,
            entity.Specie.ToString(),
            entity.UrlIot,
            entity.UrlPhoto,
            entity.InventoryId,
            entity.Location,
            entity.HearRate,
            entity.Temperature);
    }
}