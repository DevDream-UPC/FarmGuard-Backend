using FarmGuard_Backend.Animals.Domain.Model.Aggregates;
using FarmGuard_Backend.Shared.Domain.Repositories;

namespace FarmGuard_Backend.Animals.Domain.Repositories;

public interface IAnimalRepository:IBaseRepository<Animal>
{
    Task<Animal?> FindAnimalBySerialNumberIdAsync(string serialNumber);
    
    Task<IEnumerable<Animal>> FindAnimalsByIdInventory(int idInventory);
}