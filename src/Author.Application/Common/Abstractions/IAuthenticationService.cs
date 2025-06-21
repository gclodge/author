using Author.Application.Authentication;

namespace Author.Application.Common.Abstractions;

public interface IAuthenticationService
{
    /// <summary>
    /// Generates authentication tokens for the specified <see cref="User">.
    /// </summary>
    /// <param name="user"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<AuthResultDto> GenerateTokensAsync(User user, CancellationToken cancellationToken);

    /// <summary>
    /// Validates the provided refresh token, and returns a new access token if valid (null otherwise).
    /// </summary>
    /// <param name="token"></param>
    /// <returns></returns>
    Task<string?> ValidateRefreshTokenAsync(string token);
}