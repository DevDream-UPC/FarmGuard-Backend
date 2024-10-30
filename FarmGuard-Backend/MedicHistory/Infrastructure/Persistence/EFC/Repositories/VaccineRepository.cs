using FarmGuard_Backend.MedicHistory.Domain.Model.Entities;
using FarmGuard_Backend.MedicHistory.Domain.Repositories;
using FarmGuard_Backend.Shared.Infrastructure.Persistance.EFC.Configuration.Extensions;
using FarmGuard_Backend.Shared.Infrastructure.Persistance.EFC.Repositories;

namespace FarmGuard_Backend.MedicHistory.Infrastructure.Persistence.EFC.Repositories;

public class VaccineRepository(AppDbContext context): BaseRepository<Vaccine>(context), IVaccineRepository
{
    public async Task<IEnumerable<Vaccine>> FindByVaccinesByIdAnimal(string idAnimal)
    {
        throw new NotImplementedException();
    }
}