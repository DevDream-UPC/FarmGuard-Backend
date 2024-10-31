using FarmGuard_Backend.MedicHistory.Domain.Model.Entities;
using FarmGuard_Backend.Shared.Domain.Repositories;

namespace FarmGuard_Backend.MedicHistory.Domain.Repositories;

public interface IVaccineRepository:IBaseRepository<Vaccine>
{
    Task<IEnumerable<Vaccine>> FindByVaccinesByIdAnimal(int idAnimal);
}