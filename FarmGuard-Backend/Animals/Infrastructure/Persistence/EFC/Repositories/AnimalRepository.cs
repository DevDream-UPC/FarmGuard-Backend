using FarmGuard_Backend.Animals.Domain.Model.Aggregates;
using FarmGuard_Backend.Animals.Domain.Repositories;
using FarmGuard_Backend.Shared.Infrastructure.Persistance.EFC.Configuration;
using FarmGuard_Backend.Shared.Infrastructure.Persistance.EFC.Configuration.Extensions;
using FarmGuard_Backend.Shared.Infrastructure.Persistance.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FarmGuard_Backend.Animals.Infrastructure.Persistence.EFC.Repositories;

public class AnimalRepository(AppDbContext context):BaseRepository<Animal>(context),IAnimalRepository
{
    /*Aqui se realiza la configuracion para
     la busqueda en la base de datos*/
    public async Task<Animal?> FindAnimalBySerialNumberIdAsync(string serialNumber)
    {
       return await Context.Set<Animal>().FirstOrDefaultAsync( A => A.SerialNumber.Number.Equals(serialNumber));
    }

    public async Task<IEnumerable<Animal>> FindAnimalsByIdInventory(int idInventory)
    {
        return await Context.Set<Animal>()
            .Where(a => a.InventoryId == idInventory)
            .ToListAsync();
    }

    /*dbcontext ya tienes las funciones de
     añadir
     update
     delete
     obtenerUnaLista de elementos
     */
}