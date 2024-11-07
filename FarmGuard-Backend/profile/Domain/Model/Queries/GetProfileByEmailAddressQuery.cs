namespace FarmGuard_Backend.profile.Domain.Model.Queries;

/// <summary>
/// Get Profile by Email Query 
/// </summary>
/// <param name="email">
/// The <see cref="string"/> email address of the profile to retrieve
/// </param>
public record GetProfileByEmailAddressQuery(string email);
