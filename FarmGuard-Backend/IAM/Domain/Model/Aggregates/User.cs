using System.Text.Json.Serialization;
using FarmGuard_Backend.profile.Domain.Model.Aggregate;

namespace FarmGuard_Backend.IAM.Domain.Model.Aggregates;

/**
 * <summary>
 *     The user aggregate
 * </summary>
 * <remarks>
 *     This class is used to represent a user
 * </remarks>
 */
public class User(string username, string passwordHash,int idProfile)
{
    public User() : this(string.Empty, string.Empty,-1 )
    {
    }

    public int Id { get; }
    public string Username { get; private set; } = username;
    
    public int IdProfile { get; private set; } = idProfile;
    
    public Profile Profile { get; private set; }

    [JsonIgnore] public string PasswordHash { get; private set; } = passwordHash;

    /**
     * <summary>
     *     Update the username
     * </summary>
     * <param name="username">The new username</param>
     * <returns>The updated user</returns>
     */
    public User UpdateUsername(string username)
    {
        Username = username;
        return this;
    }

    /**
     * <summary>
     *     Update the password hash
     * </summary>
     * <param name="passwordHash">The new password hash</param>
     * <returns>The updated user</returns>
     */
    public User UpdatePasswordHash(string passwordHash)
    {
        PasswordHash = passwordHash;
        return this;
    }

    public void ChangeProfileId(int profileId)
    {
        IdProfile = profileId;
    }
}