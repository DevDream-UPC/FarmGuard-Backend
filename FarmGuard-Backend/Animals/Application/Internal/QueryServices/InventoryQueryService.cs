using FarmGuard_Backend.Animals.Domain.Model.Aggregates;
using FarmGuard_Backend.Animals.Domain.Model.Queries;
using FarmGuard_Backend.Animals.Domain.Repositories;
using FarmGuard_Backend.Animals.Domain.Services;
using FarmGuard_Backend.Shared.Domain.Repositories;

namespace FarmGuard_Backend.Animals.Application.Internal.QueryServices;

public class InventoryQueryService(IIventoryRepository iventoryRepository,IUnitOfWork unitOfWork):IInventoryQueryService
{
    public Task<Inventory?> Handle(GetInventoryByIdQueries query)
    {
        return iventoryRepository.FindByIdAsync(query.idInventory);
    }
}