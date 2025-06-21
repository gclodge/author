using System.Security.Claims;

namespace Author.Domain.Abstractions;

/// <summary>
/// This inerface represents an object that must expose a method to generate a <see cref="Claim"/> for itself.
/// </summary>
public interface IClaim
{
    /// <summary>
    /// This method should be used to generate a <see cref="Claim"/> for the object that implements this interface.
    /// </summary>
    /// <returns></returns>
    public Claim ToClaim();
}
