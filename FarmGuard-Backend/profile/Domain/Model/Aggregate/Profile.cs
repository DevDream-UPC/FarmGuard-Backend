using FarmGuard_Backend.Animals.Domain.Model.Aggregates;
using FarmGuard_Backend.IAM.Domain.Model.Aggregates;
using FarmGuard_Backend.profile.Domain.Model.ValueObjects;

namespace FarmGuard_Backend.profile.Domain.Model.Aggregate;

/// <summary>
/// Profile Aggregate Root 
/// </summary>
/// <remarks>
/// This class represents the Profile aggregate root.
/// It contains the properties and methods to manage the profile information.
/// </remarks>
public partial class Profile
{
    public Profile()
    {
        UrlPhoto = string.Empty;
        Name = new PersonName();
        Email = new EmailAddress();
    }

    public Profile(string firstName, string lastName, string email, string urlPhoto,int userId)
    {
        Name = new PersonName(firstName, lastName);
        Email = new EmailAddress(email);
        UrlPhoto = urlPhoto;
        UserId = userId;
        
    }
    
    public int Id { get; }
    
    public string UrlPhoto { get; private set; }
    
    public PersonName Name { get; private set; }
    
    public EmailAddress Email { get; private set; }

    public string FullName => Name.FullName;
    
    public Inventory Inventory {get; private set;}
    public int InventoryId { get; private set; }
    
    public int UserId { get; private set; }
    
    
    public User User { get; private set; }

    public void AssignInventory(int idInventory)
    {
        InventoryId = idInventory;
    }

    public void UpdateName(string firstName, string lastName)
    {
        Name = new PersonName(firstName, lastName);
    }

    public void UpdateEmail(string email)
    {
        Email = new EmailAddress(email);
    }

    public void UpdateUrlPhoto(string urlPhoto)
    {
        UrlPhoto = urlPhoto;
    }

}