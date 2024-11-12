using FarmGuard_Backend.profile.Domain.Model.Commands;
using FarmGuard_Backend.profile.Domain.Model.Queries;
using FarmGuard_Backend.profile.Domain.Services;
using FarmGuard_Backend.profile.Infrastructure.Persistence.EFC.Repositories;
using FarmGuard_Backend.profile.Interfaces.Rest.Transform;
using Microsoft.AspNetCore.Mvc;

namespace FarmGuard_Backend.profile.Interfaces.Rest;

[ApiController]
[Route("api/v1/profile")]
public class ProfileController(IProfileCommandService profileCommandService,IProfileQueryService profileQueryService):ControllerBase
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

    [HttpPut("{profileId}")]
    public async Task<IActionResult> UpdateProfile([FromBody]CreateProfileResource resource, int profileId)
    {
        var updateProfileCommand = new UpdateProfileCommand(profileId, resource.FirstName, resource.LastName,
            resource.Email, resource.UrlPhoto);
        var profile = await profileCommandService.Handle(updateProfileCommand);

        var resourceSend = ProfileResourceFromEntityAssembler.ToResourceFromEntity(profile);
        return Ok(resourceSend);
    }

    [HttpGet("{idProfile}")]
    public async Task<IActionResult> GetProfileById(int idProfile)
    {
        var profile = await profileQueryService.Handle(new GetProfileByIdQuery(idProfile));
        if (profile is null) return NotFound();
        var resource = ProfileResourceFromEntityAssembler.ToResourceFromEntity(profile);
        return Ok(resource);
    }
}