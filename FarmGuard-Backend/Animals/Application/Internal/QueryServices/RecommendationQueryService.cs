using System.Collections.Generic;
using System.Threading.Tasks;
using FarmGuard_Backend.Animals.Domain.Model.Entities;
using FarmGuard_Backend.Animals.Domain.Model.Queries;
using FarmGuard_Backend.Animals.Infrastructure.Persistence.EFC.Repositories;

namespace FarmGuard_Backend.Animals.Application.Internal.QueryServices
{
public class RecommendationQueryService
{
    private readonly RecommendationRepository _repository;

    public RecommendationQueryService(RecommendationRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Recommendations>> GetByInventoryIdAsync(GetRecommendationsByInventoryId query)
    {
        return await _repository.GetByInventoryIdAsync(query.InventoryId);
    }
}
}