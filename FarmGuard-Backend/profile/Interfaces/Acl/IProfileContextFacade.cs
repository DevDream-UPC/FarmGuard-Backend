using FarmGuard_Backend.profile.Domain.Model.Aggregate;

namespace FarmGuard_Backend.profile.Interfaces.Acl;

public interface IProfileContextFacade
{
    Task<int> CreateProfile(string firstName, string lastName, string email, string urlPhoto,int userId );
    
    Task<int> GetProfileById(int id);
}