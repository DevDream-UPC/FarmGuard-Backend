using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using FarmGuard_Backend.Shared.Infrastructure.Persistance.EFC.Configuration.Extensions.Extensions;
using Microsoft.EntityFrameworkCore;

namespace FarmGuard_Backend.Shared.Infrastructure.Persistance.EFC.Configuration.Extensions;

public class AppDbContext(DbContextOptions options):DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.AddCreatedUpdatedInterceptor();
        base.OnConfiguring(builder);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        /*Aqui mapeas las entidades y defines si se requiere o se
         genere un campo en bd. Ademas de agregar las relaciones*/
        
        //=======================================================
        builder.UseSnakeCaseWithPluralizedTableNamingConvention();
    }
}