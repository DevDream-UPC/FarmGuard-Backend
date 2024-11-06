using FarmGuard_Backend.Animals.Domain.Model.Aggregates;
using FarmGuard_Backend.Animals.Domain.Repositories;
using FarmGuard_Backend.Shared.Infrastructure.Persistance.EFC.Configuration;
using FarmGuard_Backend.Shared.Infrastructure.Persistance.EFC.Configuration.Extensions;
using FarmGuard_Backend.Shared.Infrastructure.Persistance.EFC.Repositories;

namespace FarmGuard_Backend.Animals.Infrastructure.Persistence.EFC.Repositories;

public class InventoryRepository(AppDbContext context):BaseRepository<Inventory>(context),IIventoryRepository
{
    
}