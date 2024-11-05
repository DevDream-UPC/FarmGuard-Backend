using FarmGuard_Backend.profile.Domain.Model.Aggregate;
using FarmGuard_Backend.profile.Domain.Model.Queries;

namespace FarmGuard_Backend.profile.Domain.Services;

public interface IProfileQueryService
{
    Task<Profile?> Handle(GetProfileByIdQuery query);
    
    Task<Profile?> Handle(GetProfileByEmailAddressQuery query);
}