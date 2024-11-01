using System;
using System.Threading.Tasks;
using FarmGuard_Backend.Animals.Domain.Model.Commands;
using FarmGuard_Backend.Animals.Domain.Model.Entities;
using FarmGuard_Backend.Animals.Infrastructure.Persistence.EFC.Repositories;

namespace FarmGuard_Backend.Animals.Application.Internal.ComandServices
{
public class RecommendationCommandService
{
    private readonly RecommendationRepository _repository;
    private readonly InventoryRepository _inventoryRepository;

    public RecommendationCommandService(RecommendationRepository repository, InventoryRepository inventoryRepository)
    {
        _repository = repository;
        _inventoryRepository = inventoryRepository;
    }

    public async Task<Recommendations> CreateAsync(CreateRecommendationCommand command)
    {
        var inventory = await _inventoryRepository.FindByIdAsync(command.InventoryId);
        if (inventory == null)
            throw new KeyNotFoundException($"Inventory with id {command.InventoryId} not found");

        var recommendation = new Recommendations
        {
            Content = command.Content,
            Species = command.Species,
            InventoryId = command.InventoryId
        };

        await _repository.AddAsync(recommendation);
        return recommendation;
    }
}
}