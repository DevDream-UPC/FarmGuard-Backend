using FarmGuard_Backend.Animals.Domain.Model.Queries;
using FarmGuard_Backend.Animals.Domain.Services;

namespace FarmGuard_Backend.Animals.Interfaces.Acl.Services;

public class AnimalContextFacade(IAnimalQueryService animalQueryService, IAnimalCommandService animalCommandService):IAnimalContextFacade
{
    public async Task<int> FetchAnimalByIdAnimal(string animalId)
    {
        var getAnimalByAnimalId = new GetAnimalBySerialNumberId(animalId);
        var animal = await animalQueryService.Handle(getAnimalByAnimalId);
        
        if (animal == null)
        {
            Console.WriteLine($"Animal con Serial ID {animalId} no encontrado en la base de datos.");
        }
        
        return animal?.Id ?? 0;
    }

    public Task<int> FetchAnimalById(int id)
    {
        throw new NotImplementedException();
    }
}