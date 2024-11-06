using FarmGuard_Backend.profile.Domain.Model.Commands;
using FarmGuard_Backend.profile.Domain.Services;
using FarmGuard_Backend.profile.Infrastructure.Persistence.EFC.Repositories;
using FarmGuard_Backend.profile.Interfaces.Rest.Transform;
using Microsoft.AspNetCore.Mvc;

namespace FarmGuard_Backend.profile.Interfaces.Rest;

[ApiController]
[Route("api/v1/profile")]
public class ProfileController(IProfileCommandService profileCommandService):ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateProfile([FromBody] CreateProfileResource resource)
    {
        try
        {
            var createProfileCommand = CreateProfileCommandFromResourceAssembler.ToResourceFromEntity(resource);
            var profile = await profileCommandService.Handle(createProfileCommand);

            if (profile is null) return BadRequest();

            var profileResource = ProfileResourceFromEntityAssembler.ToResourceFromEntity(profile);
            
            return Ok(profileResource);

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [HttpDelete("{profileId}")]
    public async Task<IActionResult> DeleteProfile([FromRoute] int profileId)
    {
        try
        {
            var deleteProfileByIdCommand = new DeleteProfileByIdCommand(profileId);
            var profile = await profileCommandService.Handle(deleteProfileByIdCommand);
            return Ok(profile);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}