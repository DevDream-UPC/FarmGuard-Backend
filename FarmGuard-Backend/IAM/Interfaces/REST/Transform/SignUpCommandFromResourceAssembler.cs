using FarmGuard_Backend.IAM.Domain.Model.Commands;
using FarmGuard_Backend.IAM.Interfaces.REST.Resources;

namespace ACME.LearningCenterPlatform.API.IAM.Interfaces.REST.Transform;

public static class SignUpCommandFromResourceAssembler
{
    public static SignUpCommand ToCommandFromResource(SignUpResource resource)
    {
        return new SignUpCommand(resource.Username, resource.Password,resource.FirstName,resource.LastName,resource.Email,resource.UrlPhoto);
    }
}