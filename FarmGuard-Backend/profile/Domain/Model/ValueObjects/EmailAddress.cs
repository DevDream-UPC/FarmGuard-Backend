namespace FarmGuard_Backend.profile.Domain.Model.ValueObjects;

public record EmailAddress(string EAddress)
{
    public EmailAddress() : this(string.Empty)
    {
    }
    
    
}