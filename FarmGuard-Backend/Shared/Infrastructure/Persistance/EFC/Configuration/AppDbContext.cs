using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using FarmGuard_Backend.Animals.Domain.Model.Aggregates;
using FarmGuard_Backend.MedicHistory.Domain.Model.Entities;
using FarmGuard_Backend.Notifications.Domain.Model.Aggregates;
using FarmGuard_Backend.Shared.Infrastructure.Persistance.EFC.Configuration.Extensions.Extensions;
using Microsoft.EntityFrameworkCore;

namespace FarmGuard_Backend.Shared.Infrastructure.Persistance.EFC.Configuration.Extensions;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Notification> Notifications { get; set; }

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
        //Ejemplo de como mapear una valueobject en dbcontext
        builder.Entity<Animal>().OwnsOne(t => t.SerialNumber, n =>
        {
            n.WithOwner().HasForeignKey("id");
            n.Property(a => a.Number).HasColumnName("id_animal");
        });
        builder.Entity<Animal>().Property(p => p.Name).IsRequired();
        builder.Entity<Animal>().Property(p => p.Specie).IsRequired();
        builder.Entity<Animal>().Property(p => p.UrlPhoto).IsRequired();
        builder.Entity<Animal>().Property(p => p.UrlIot).IsRequired();
        builder.Entity<Animal>().Property(p => p.Location).IsRequired();
        builder.Entity<Animal>().Property(p => p.Temperature).IsRequired().HasColumnType("decimal(18,2)");
        builder.Entity<Animal>().Property(p => p.HearRate).IsRequired().HasColumnType("decimal(18,2)");
        
        /*MedicalHistory Bounded Context*/
        builder.Entity<Vaccine>().HasKey(v => v.Id);
        builder.Entity<Vaccine>().Property(v => v.Id)
            .IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Vaccine>().Property(v => v.Name).IsRequired();
        builder.Entity<Vaccine>().Property(v => v.Description).IsRequired();
        builder.Entity<Vaccine>().Property(v => v.Date).IsRequired();
        
        /*Relaciones*/
        builder.Entity<Animal>()
            .HasMany(a => a.Vaccines)
            .WithOne(v => v.Animal)
            .HasForeignKey(v => v.AnimalId)
            .HasPrincipalKey(a => a.Id);

        /*Notifications Bounded Context*/
        builder.Entity<Notification>().HasKey(n => n.Id);
        builder.Entity<Notification>().Property(n => n.Id)
            .IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Notification>().Property(n => n.Title).IsRequired();
        builder.Entity<Notification>().Property(n => n.AnimalId).IsRequired();
        builder.Entity<Notification>().Property(n => n.Description).IsRequired();
        builder.Entity<Notification>().Property(n => n.State).IsRequired();
            /*
        builder.Entity<Animal>().OwnsOne(t => t.SerialNumber, n =>
        {
            n.WithOwner().HasForeignKey("id");
            n.Property(a => a.Number).HasColumnName("id_animal");
        });*/
        //=======================================================
        builder.UseSnakeCaseWithPluralizedTableNamingConvention();
    }
}