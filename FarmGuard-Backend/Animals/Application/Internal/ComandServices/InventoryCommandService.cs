using FarmGuard_Backend.Animals.Domain.Model.Aggregates;
using FarmGuard_Backend.Animals.Domain.Model.Commands;
using FarmGuard_Backend.Animals.Domain.Repositories;
using FarmGuard_Backend.Animals.Domain.Services;
using FarmGuard_Backend.Animals.Infrastructure.Persistence.EFC.Repositories;
using FarmGuard_Backend.Shared.Domain.Repositories;

namespace FarmGuard_Backend.Animals.Application.Internal.ComandServices;

public class InventoryCommandService(IIventoryRepository iventoryRepository,IUnitOfWork unitOfWork):IInventoryCommandService
{
    
    public async Task<Inventory?> Handle(CreateInventoryCommand command)
    {
        try
        {
            var inventory = new Inventory(command.Name,command.IdProfile);
            await iventoryRepository.AddAsync(inventory);
            await unitOfWork.CompleteAsync();
            return inventory;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}