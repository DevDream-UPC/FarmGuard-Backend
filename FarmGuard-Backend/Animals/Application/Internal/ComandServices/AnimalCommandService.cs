using FarmGuard_Backend.Animals.Domain.Model.Aggregates;
using FarmGuard_Backend.Animals.Domain.Model.Commands;
using FarmGuard_Backend.Animals.Domain.Repositories;
using FarmGuard_Backend.Animals.Domain.Services;
using FarmGuard_Backend.Shared.Domain.Repositories;

namespace FarmGuard_Backend.Animals.Application.Internal.ComandServices;

public class AnimalCommandService(IAnimalRepository animalRepository,IUnitOfWork unitOfWork,IIventoryRepository inIventoryRepository):IAnimalCommandService
{
    public async Task<Animal?> Handle(CreateAnimalCommand command)
    {
        try
        {
            /*Aca iria las reglas del negocio*/
            var inventory = await inIventoryRepository.FindByIdAsync(command.inventoryId);
            if (inventory is null) throw new Exception("Inventory not found");
            
            /*Aqui se crea la la entidad animal*/
            var animal = new Animal(
                command.name, 
                command.specie, 
                command.urlIot, 
                command.urlPhoto, 
                command.location,
                command.hearRate, 
                command.temperature,inventory.Id);
            
            
            /*Aca se guarda en db por transaccion*/
            await animalRepository.AddAsync(animal);
            await unitOfWork.CompleteAsync();
            return animal;

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}