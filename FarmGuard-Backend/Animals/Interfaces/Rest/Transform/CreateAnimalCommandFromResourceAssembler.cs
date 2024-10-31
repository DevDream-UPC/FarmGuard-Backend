using FarmGuard_Backend.Animals.Domain.Model.Commands;
using FarmGuard_Backend.Animals.Interfaces.Rest.resources;

namespace FarmGuard_Backend.Animals.Interfaces.Rest.Transform;

public class CreateAnimalCommandFromResourceAssembler
{
    public static CreateAnimalCommand ToCommandFromResource(CreateAnimalResource resource,int idInventory)
    {
        return new CreateAnimalCommand(
            resource.name, 
            resource.specie,
            resource.urlIot, 
            resource.urlPhoto,
            resource.location, 
            resource.hearRate, 
            resource.temperature,
            idInventory);
    }
}