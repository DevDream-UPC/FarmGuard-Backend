using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using FarmGuard_Backend.Animals.Domain.Model.Aggregates;
using FarmGuard_Backend.IAM.Domain.Model.Aggregates;
using FarmGuard_Backend.MedicHistory.Domain.Model.Entities;
using FarmGuard_Backend.Notifications.Domain.Model.Aggregates;
using FarmGuard_Backend.profile.Domain.Model.Aggregate;
using FarmGuard_Backend.Shared.Infrastructure.Persistance.EFC.Configuration.Extensions.Extensions;
using Microsoft.EntityFrameworkCore;

namespace FarmGuard_Backend.Shared.Infrastructure.Persistance.EFC.Configuration;

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
        
        builder.Entity<Inventory>().HasKey(i=>i.Id);
        builder.Entity<Inventory>().Property(i => i.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Inventory>().Property(i => i.Name).IsRequired();
        
        
        
        /*MedicalHistory Bounded Context*/
        builder.Entity<Vaccine>().HasKey(v => v.Id);
        builder.Entity<Vaccine>().Property(v => v.Id)
            .IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Vaccine>().Property(v => v.Name).IsRequired();
        builder.Entity<Vaccine>().Property(v => v.Description).IsRequired();
        builder.Entity<Vaccine>().Property(v => v.Date).IsRequired();
        
        /*Profile Bounded Context*/
        builder.Entity<Profile>().HasKey(p=>p.Id);
        builder.Entity<Profile>().Property(p=>p.Id)
            .IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Profile>().Property(p => p.UrlPhoto).IsRequired();
        builder.Entity<Profile>().OwnsOne(p => p.Email, email =>
        {
            email.WithOwner().HasForeignKey("id");
            email.Property(a => a.EAddress).IsRequired();

        });
        builder.Entity<Profile>().OwnsOne(p => p.Name, personName =>
        {
            personName.WithOwner().HasForeignKey("id");
            personName.Property(pn => pn.FirstName).IsRequired();
            personName.Property(pn => pn.LastName).IsRequired();

        });
        
        /*Relaciones*/
        builder.Entity<Animal>()
            .HasMany(a => a.Vaccines)
            .WithOne(v => v.Animal)
            .HasForeignKey(v => v.AnimalId)
            .HasPrincipalKey(a => a.Id);

        builder.Entity<Inventory>()
            .HasMany(i => i.Animals)
            .WithOne(a => a.Inventory)
            .HasForeignKey(a => a.InventoryId)
            .HasPrincipalKey(i => i.Id);

        builder.Entity<Profile>()
            .HasOne(p => p.Inventory)
            .WithOne(i =>i.Profile)
            .HasForeignKey<Profile>(p => p.InventoryId)
            .OnDelete(DeleteBehavior.Cascade);;
            

        builder.Entity<Inventory>()
            .HasOne(i => i.Profile)
            .WithOne(p => p.Inventory)
            .HasForeignKey<Inventory>(i=>i.ProfileId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Inventory>()
            .HasMany(i => i.Notifications)
            .WithOne(n => n.Inventory)
            .HasForeignKey(n => n.InventoryId)
            .HasPrincipalKey(i => i.Id);

        builder.Entity<User>()
            .HasOne(u => u.Profile)
            .WithOne(p => p.User)
            .HasForeignKey<User>(u => u.IdProfile);

        builder.Entity<Profile>()
            .HasOne(p => p.User)
            .WithOne(u => u.Profile)
            .HasForeignKey<Profile>(p => p.UserId);
            
            

        /*Notifications Bounded Context*/
        builder.Entity<Notification>().HasKey(n => n.Id);
        builder.Entity<Notification>().Property(n => n.Id)
            .IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Notification>().Property(n => n.Title).IsRequired();
        builder.Entity<Notification>().Property(n => n.Description).IsRequired();
        builder.Entity<Notification>().Property(n => n.State).IsRequired();
        
        // IAM Context
        
        builder.Entity<User>().HasKey(u => u.Id);
        builder.Entity<User>().Property(u => u.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<User>().Property(u => u.Username).IsRequired();
        builder.Entity<User>().Property(u => u.PasswordHash).IsRequired();
        builder.Entity<User>().Property(u => u.IdProfile).IsRequired();
        
        //=======================================================
        builder.UseSnakeCaseWithPluralizedTableNamingConvention();
    }
}