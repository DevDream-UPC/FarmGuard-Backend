using FarmGuard_Backend.Animals.Domain.Model.Aggregates;
using FarmGuard_Backend.Animals.Domain.Model.Queries;
using FarmGuard_Backend.Animals.Domain.Repositories;
using FarmGuard_Backend.Animals.Domain.Services;
using FarmGuard_Backend.Animals.Infrastructure.Persistence.EFC.Repositories;
using FarmGuard_Backend.Shared.Domain.Repositories;

namespace FarmGuard_Backend.Animals.Application.Internal.QueryServices;

public class AnimalQueryService (IAnimalRepository animalRepository,IIventoryRepository iventoryRepository ,IUnitOfWork unitOfWork) : IAnimalQueryService
{
    public async Task<Animal?> Handle(GetAnimalBySerialNumberId query)
    {
        return await animalRepository.FindAnimalBySerialNumberIdAsync(query.serial);
    }

    public async Task<IEnumerable<Animal>> Handle(GetAllAnimalsByIdInventory query)
    {
        var idInventory = await iventoryRepository.FindByIdAsync(query.IdInventory);
        if (idInventory is null) throw new Exception($"No se encontro un inventario con el id{query.IdInventory}");

        return await animalRepository.FindAnimalsByIdInventory(query.IdInventory);
    }
}