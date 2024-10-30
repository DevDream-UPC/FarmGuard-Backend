using FarmGuard_Backend.Animals.Interfaces.Acl;

namespace FarmGuard_Backend.MedicHistory.Application.Internal.OutboundServices;

public class ExternalAnimalService(IAnimalContextFacade animalContextFacade)
{
    public async Task<int?> GetAnimalByAnimalId(string serialAnimalId)
    {
        var animalId = await animalContextFacade.FetchAnimalByIdAnimal(serialAnimalId);
        System.Console.WriteLine(serialAnimalId);
        if(animalId == 0) return await Task.FromResult<int?>(null);
        return animalId;
    }
}