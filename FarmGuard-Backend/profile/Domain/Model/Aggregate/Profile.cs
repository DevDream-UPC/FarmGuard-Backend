using FarmGuard_Backend.Animals.Domain.Model.Aggregates;
using FarmGuard_Backend.profile.Domain.Model.ValueObjects;

namespace FarmGuard_Backend.profile.Domain.Model.Aggregate;

public class Profile
{
    public Profile()
    {
        UrlPhoto = string.Empty;
        Name = new PersonName();
        Email = new EmailAddress();
    }

    public Profile(string firstName, string lastName, string email, string urlPhoto)
    {
        Name = new PersonName(firstName, lastName);
        Email = new EmailAddress(email);
        UrlPhoto = urlPhoto;
        
    }
    
    public int Id { get; }
    
    public string UrlPhoto { get; private set; }
    
    public PersonName Name { get; private set; }
    
    public EmailAddress Email { get; private set; }

    public string FullName => Name.FullName;
    
    public Inventory Inventory {get; private set;}
    
    public int InventoryId { get; private set; }

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