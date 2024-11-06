using FarmGuard_Backend.Animals.Domain.Model.Aggregates;
using FarmGuard_Backend.Animals.Domain.Model.Queries;

namespace FarmGuard_Backend.Animals.Domain.Services;

public interface IAnimalQueryService
{
    Task<Animal?> Handle(GetAnimalBySerialNumberId query);

    Task<IEnumerable<Animal>> Handle(GetAllAnimalsByIdInventory query);
}