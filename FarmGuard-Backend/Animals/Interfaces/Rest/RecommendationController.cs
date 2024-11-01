using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FarmGuard_Backend.Animals.Application.Internal.ComandServices;
using FarmGuard_Backend.Animals.Application.Internal.QueryServices;
using FarmGuard_Backend.Animals.Domain.Model.Commands;
using FarmGuard_Backend.Animals.Domain.Model.Queries;
using FarmGuard_Backend.Animals.Domain.Model.Entities;

namespace FarmGuard_Backend.Animals.Interfaces.Rest
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecommendationController : ControllerBase
    {
        private readonly RecommendationCommandService _commandService;
        private readonly RecommendationQueryService _queryService;

        public RecommendationController(RecommendationCommandService commandService, RecommendationQueryService queryService)
        {
            _commandService = commandService;
            _queryService = queryService;
        }

        [HttpGet("inventory/{id}")]
        public async Task<ActionResult<IEnumerable<Recommendations>>> GetByInventoryId(int id)
        {
            var query = new GetRecommendationsByInventoryId { InventoryId = id };
            var recommendations = await _queryService.GetByInventoryIdAsync(query);
            return Ok(recommendations);
        }

        [HttpPost]
        public async Task<ActionResult<Recommendations>> Create(CreateRecommendationCommand command)
        {
            var recommendation = await _commandService.CreateAsync(command);
            return CreatedAtAction(nameof(GetByInventoryId), new { id = recommendation.InventoryId }, recommendation);
        }
    }
}