using FarmGuard_Backend.Animals.Domain.Model.Aggregates;
using FarmGuard_Backend.Animals.Domain.Model.Queries;

namespace FarmGuard_Backend.Animals.Domain.Services;

public interface IInventoryQueryService
{
    Task<Inventory?> Handle(GetInventoryByIdQueries query);
}