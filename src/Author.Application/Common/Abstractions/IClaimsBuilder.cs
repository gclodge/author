using System.Security.Claims;

namespace Author.Application.Common.Abstractions;

/// <summary>
/// Interface for building claims for a user from various sources
/// </summary>
public interface IClaimsBuilder
{
    /// <summary>
    /// Builds a collection of <see cref="Claim"/>s for the specified <see cref="Guid"/> user ID.    
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<IEnumerable<Claim>> BuildClaimsForUserAsync(Guid userId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Builds a collection of <see cref="Claim"/>s for the specified <see cref="User"/> entity.
    /// </summary>
    /// <param name="user"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<IEnumerable<Claim>> BuildClaimsForUserAsync(User user, CancellationToken cancellationToken = default);

    /// <summary>
    /// Builds a collection of <see cref="Claim"/>s for the specified <see cref="Guid"/> group ID.
    /// </summary>
    /// <param name="groupId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<IEnumerable<Claim>> BuildClaimsForGroupAsync(Guid groupId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Builds a collection of <see cref="Claim"/>s for the specified <see cref="UserGroup"/> entity.
    /// </summary>
    /// <param name="group"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<IEnumerable<Claim>> BuildClaimsForGroupAsync(UserGroup group, CancellationToken cancellationToken = default);
}
