namespace FarmGuard_Backend.Animals.Interfaces.Acl;

public interface IAnimalContextFacade
{
    Task<int> FetchAnimalByIdAnimal(string animalId);

    Task<int> FetchAnimalById(int id);
    
}