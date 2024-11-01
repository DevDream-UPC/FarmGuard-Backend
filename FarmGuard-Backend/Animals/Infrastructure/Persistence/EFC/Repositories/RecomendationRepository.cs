using System.Collections.Generic;
using System.Linq;
using FarmGuard_Backend.Animals.Domain.Model.Entities;
using FarmGuard_Backend.Shared.Infrastructure.Persistance.EFC.Configuration.Extensions;
using FarmGuard_Backend.Shared.Infrastructure.Persistance.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FarmGuard_Backend.Animals.Infrastructure.Persistence.EFC.Repositories
{
    public class RecommendationRepository : BaseRepository<Recommendations>
    {
        private readonly AppDbContext _context;

        public RecommendationRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Recommendations>> GetByInventoryIdAsync(int inventoryId)
        {
            return await Context.Set<Recommendations>()
                .Where(r => r.InventoryId == inventoryId)
                .ToListAsync();
        }
    }
}