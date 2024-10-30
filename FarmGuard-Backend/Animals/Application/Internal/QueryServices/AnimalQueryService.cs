using FarmGuard_Backend.Animals.Domain.Model.Aggregates;
using FarmGuard_Backend.Animals.Domain.Model.Queries;
using FarmGuard_Backend.Animals.Domain.Repositories;
using FarmGuard_Backend.Animals.Domain.Services;
using FarmGuard_Backend.Shared.Domain.Repositories;

namespace FarmGuard_Backend.Animals.Application.Internal.QueryServices;

public class AnimalQueryService (IAnimalRepository animalRepository,IUnitOfWork unitOfWork) : IAnimalQueryService
{
    public async Task<Animal?> Handle(GetAnimalBySerialNumberId query)
    {
        return await animalRepository.FindAnimalBySerialNumberIdAsync(query.serial);
    }
}