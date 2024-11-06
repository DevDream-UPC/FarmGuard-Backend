using FarmGuard_Backend.MedicHistory.Domain.Model.Commands;
using FarmGuard_Backend.MedicHistory.Interfaces.Rest.resources;

namespace FarmGuard_Backend.MedicHistory.Interfaces.Rest.Transform;

public class CreateVaccineCommandFromResourceAssembler
{
    public static CreateVaccineCommand ToCommandFromResource(CreateVaccineResource resource, string serialAnimalId)
    {
        return new CreateVaccineCommand(
            serialAnimalId, 
            resource.name, 
            resource.description, 
            resource.date_expiration);
    }
}