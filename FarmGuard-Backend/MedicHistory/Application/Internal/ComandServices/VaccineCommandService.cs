using FarmGuard_Backend.Animals.Domain.Repositories;
using FarmGuard_Backend.MedicHistory.Application.Internal.OutboundServices;
using FarmGuard_Backend.MedicHistory.Domain.Model.Commands;
using FarmGuard_Backend.MedicHistory.Domain.Model.Entities;
using FarmGuard_Backend.MedicHistory.Domain.Repositories;
using FarmGuard_Backend.MedicHistory.Domain.Services;
using FarmGuard_Backend.Shared.Domain.Repositories;

namespace FarmGuard_Backend.MedicHistory.Application.Internal.ComandServices;

public class VaccineCommandService(IVaccineRepository vaccineRepository,IUnitOfWork unitOfWork,ExternalAnimalService externalAnimalService):IVaccineCommandService
{
    public async Task<Vaccine?> Handle(CreateVaccineCommand command)
    {
        try
        {
            
            var idAnimal = await externalAnimalService.GetAnimalByAnimalId(command.SerialAnimalId);
            
            if(idAnimal is null) throw new Exception("Animal not Found");
            
            var vaccine = new Vaccine(command.name, command.description, command.date, idAnimal.Value);
            
            await vaccineRepository.AddAsync(vaccine);
            
            
            await unitOfWork.CompleteAsync();
            
            return vaccine;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

    }

    public async Task<Vaccine?> Handle(DeleteVaccineCommand command)
    {
        var vaccine = await vaccineRepository.FindByIdAsync(command.Id);
        if(vaccine is null) throw new Exception("Vacuna");
        vaccineRepository.Remove(vaccine);
        await unitOfWork.CompleteAsync();
        return vaccine;


    }
}