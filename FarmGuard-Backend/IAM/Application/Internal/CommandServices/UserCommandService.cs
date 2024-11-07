using FarmGuard_Backend.IAM.Application.Internal.OutboundServices;
using FarmGuard_Backend.IAM.Domain.Model.Aggregates;
using FarmGuard_Backend.IAM.Domain.Model.Commands;
using FarmGuard_Backend.IAM.Domain.Repositories;
using FarmGuard_Backend.IAM.Domain.Services;
using FarmGuard_Backend.Shared.Domain.Repositories;

namespace FarmGuard_Backend.IAM.Application.Internal.CommandServices;

/**
 * <summary>
 *     The user command service
 * </summary>
 * <remarks>
 *     This class is used to handle user commands
 * </remarks>
 */
public class UserCommandService(
    IUserRepository userRepository,
    ITokenService tokenService,
    IHashingService hashingService,
    IUnitOfWork unitOfWork,
    ExternalProfileService externalProfileService)
    : IUserCommandService
{
    /**
     * <summary>
     *     Handle sign in command
     * </summary>
     * <param name="command">The sign in command</param>
     * <returns>The authenticated user and the JWT token</returns>
     */
    public async Task<(User user, string token)> Handle(SignInCommand command)
    {
        var user = await userRepository.FindByUsernameAsync(command.Username);

        if (user == null || !hashingService.VerifyPassword(command.Password, user.PasswordHash))
            throw new Exception("Invalid username or password");

        var token = tokenService.GenerateToken(user);

        return (user, token);
    }

    /**
     * <summary>
     *     Handle sign up command
     * </summary>
     * <param name="command">The sign up command</param>
     * <returns>A confirmation message on successful creation.</returns>
     */
    public async Task Handle(SignUpCommand command)
    {
        try
        {
            if (userRepository.ExistsByUsername(command.Username))
                throw new Exception($"Username {command.Username} is already taken");
        
            var hashedPassword = hashingService.HashPassword(command.Password);
            var user = new User(command.Username, hashedPassword,0);
        
            await userRepository.AddAsync(user);
            await unitOfWork.CompleteAsync();
        
            var profileId = await externalProfileService.CreateProfileWithUser(command.FirstName, command.LastName,
                command.Email, command.UrlPhoto,user.Id );
            if(profileId == 0) throw new Exception($"Could not create profile {command.FirstName} {command.LastName}");
        
            user.ChangeProfileId(profileId);

            userRepository.Update(user);
            await unitOfWork.CompleteAsync();
            
        }
        catch (Exception e)
        {
            throw new Exception($"An error occurred while creating user: {e.Message}");
        }
    }

    public async Task<int> GetInventoryId(int idProfile)
    {
        var inventoryId = await externalProfileService.GetInventoryId(idProfile);
        return inventoryId;
    }
}