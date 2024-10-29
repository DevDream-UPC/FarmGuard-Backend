using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using FarmGuard_Backend.Animals.Domain.Model.Aggregates;
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
        
        /*Animal Bounded Context*/
        builder.Entity<Animal>().HasKey(p => p.Id);
        builder.Entity<Animal>().Property(p => p.Id)
            .IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Animal>().OwnsOne(t => t.SerialNumber, n =>
        {
            n.WithOwner().HasForeignKey("id");
            n.Property(a => a.Number).HasColumnName("id_animal");
        });
        builder.Entity<Animal>().Property(p => p.Name).IsRequired();
        builder.Entity<Animal>().Property(p=>p.Specie).IsRequired();
        builder.Entity<Animal>().Property(p =>p.UrlPhoto).IsRequired();
        builder.Entity<Animal>().Property(p =>p.UrlIot).IsRequired();
        builder.Entity<Animal>().Property(p=>p.Location).IsRequired();
        builder.Entity<Animal>().Property(p=>p.Temperature).IsRequired().HasColumnType("decimal(18,2)");
        builder.Entity<Animal>().Property(p =>p.HearRate).IsRequired().HasColumnType("decimal(18,2)");
        
        
        //=======================================================
        builder.UseSnakeCaseWithPluralizedTableNamingConvention();
    }
}