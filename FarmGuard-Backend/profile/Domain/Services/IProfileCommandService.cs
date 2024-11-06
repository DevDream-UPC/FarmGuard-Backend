using FarmGuard_Backend.profile.Domain.Model.Aggregate;
using FarmGuard_Backend.profile.Domain.Model.Commands;

namespace FarmGuard_Backend.profile.Domain.Services;

public interface IProfileCommandService
{
    Task<Profile?> Handle(CreateProfileCommand command);
    Task<Profile?> Handle(UpdateProfileCommand command);
    Task<Profile?> Handle(DeleteProfileByIdCommand command);
}