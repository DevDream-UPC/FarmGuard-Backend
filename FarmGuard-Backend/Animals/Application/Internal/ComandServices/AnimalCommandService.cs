using FarmGuard_Backend.Animals.Application.Internal.OutboundServices;
using FarmGuard_Backend.Animals.Domain.Model.Aggregates;
using FarmGuard_Backend.Animals.Domain.Model.Commands;
using FarmGuard_Backend.Animals.Domain.Model.Queries;
using FarmGuard_Backend.Animals.Domain.Repositories;
using FarmGuard_Backend.Animals.Domain.Services;
using FarmGuard_Backend.Shared.Domain.Repositories;

namespace FarmGuard_Backend.Animals.Application.Internal.ComandServices;

public class AnimalCommandService(IAnimalRepository animalRepository,
    IUnitOfWork unitOfWork,
    ExternalNotificationService externalNotificationService,
    IIventoryRepository inIventoryRepository):IAnimalCommandService
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

    public async Task<Animal?> Handle(PutAnimalCommand command)
    {
        try
        {
            var animal = await animalRepository.FindAnimalBySerialNumberIdAsync(command.AnimalId);
            if (animal is null) throw new Exception("No se encontro animal con Cierta Id Animal");
            
            /*aActualizamos los datos*/
            
            animal.UpdateInformationAnimal(command.Name,command.Specie,command.UrlIot,command.UrlPhoto);
            animal.UpdateInformationIot(command.Location,command.HearRate,command.Temperature);
            
            /*Verificamos si la temperatura esta en su rango y vemos si creamos notificaciones*/

            var controlTemperature = animal.GetDescriptionNotificationByTemperature();
            var controlHearRate = animal.GetDescriptionNotificationByHearRate();
            
            //Creamos variables para pasar

            var tittle = $"Notification of {animal.Name}";
            var inventoryId = animal.InventoryId;

            if (controlTemperature)
            {
                var state = "Low";
                var description =
                    $"La frecuencia cardíaca de {animal.Temperature} está dentro del rango normal para la especie {animal.Specie.ToString()}.";
                await externalNotificationService.CreateNotification(tittle,description,state,inventoryId);
            }
            else
            {
                var state = "High";
                var description =$"La frecuencia cardíaca de {animal.Temperature} está fuera del rango normal para la especie {animal.Specie.ToString()}.";
                await externalNotificationService.CreateNotification(tittle,description,state,inventoryId);
                
            }

            if (controlHearRate)
            {
                var state = "Low";
                var description = $"La Temperatura de {animal.HearRate} está dentro del rango normal para la especie {animal.Specie.ToString()}.";
                await externalNotificationService.CreateNotification(tittle,description,state,inventoryId);
            }
            else
            {
                var state = "High";
                var description =$"La Temperatura de {animal.HearRate} está fuera del rango normal para la especie {animal.Specie.ToString()}.";
                await externalNotificationService.CreateNotification(tittle,description,state,inventoryId);
            }
            
            
            
                
            
            /*Verificamos si el ritmo cardiaco esta en su rango*/
            
            animalRepository.Update(animal);
            await unitOfWork.CompleteAsync();
            
            return animal;

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<Animal?> Handle(DeleteAnimalByIdAnimalCommand command)
    {
        var animal = await animalRepository.FindAnimalBySerialNumberIdAsync(command.AnimalId);
        if (animal is null) throw new Exception("No se encontro animal con Cierta Id Animal");
        
        animalRepository.Remove(animal);
        await unitOfWork.CompleteAsync();

        return animal;
    }
}