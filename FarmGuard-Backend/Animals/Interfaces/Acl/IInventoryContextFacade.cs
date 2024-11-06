namespace FarmGuard_Backend.Animals.Interfaces.Acl;

public interface IInventoryContextFacade
{
    Task<int> CreateInventory(string name,int idProfile);
}