using System.Security.Claims;

namespace Author.Application.Common.Abstractions;

/// <summary>
/// Represents an authenticated user within the application and their associated claims, roles, and policies.
/// </summary>
public interface ICurrentUser
{
    /// <summary>
    /// If authenticated, the user's unique identifier. Otherwise, null.
    /// </summary>
    string? Id { get; }

    /// <summary>
    /// The user's 'name', which may be a display name or username. This is not guaranteed to be unique.
    /// </summary>
    string? Name { get; }

    /// <summary>
    /// The collection of <see cref="Claim"/> objects as extracted from user's access token.
    /// </summary>
    HashSet<Claim> Claims { get; }

    /// <summary>
    /// The collection of <see cref="string"/> roles as extracted from user's access token.
    /// </summary>
    HashSet<string> Roles { get; }

    /// <summary>
    /// The collection of <see cref="string"/> policies as extracted from user's access token.
    /// </summary>
    HashSet<string> Policies { get; }
}