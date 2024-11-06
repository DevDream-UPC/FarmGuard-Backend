using FarmGuard_Backend.MedicHistory.Domain.Model.Entities;
using FarmGuard_Backend.MedicHistory.Domain.Repositories;
using FarmGuard_Backend.Shared.Infrastructure.Persistance.EFC.Configuration;
using FarmGuard_Backend.Shared.Infrastructure.Persistance.EFC.Configuration.Extensions;
using FarmGuard_Backend.Shared.Infrastructure.Persistance.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FarmGuard_Backend.MedicHistory.Infrastructure.Persistence.EFC.Repositories;

public class VaccineRepository(AppDbContext context) : BaseRepository<Vaccine>(context), IVaccineRepository
{
    public async Task<IEnumerable<Vaccine>> FindByVaccinesByIdAnimal(int idAnimal)
    {
        return await Context.Set<Vaccine>()
            .Where(v => v.AnimalId == idAnimal)
            .ToListAsync();
    }
}