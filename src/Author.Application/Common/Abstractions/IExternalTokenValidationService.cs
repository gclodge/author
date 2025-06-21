namespace Author.Application.Common.Abstractions;

//< TODO - Consider how we can genericize this to allow for any number of external providers?  Must be a way to keep it clean & generic..

public interface IExternalTokenValidationService
{
    /// <summary>
    /// Validates the incoming, externally-issued, JWT token and returns the user ID if valid
    /// </summary>
    /// <param name="token">base64-encoded JWT token to be validated</param>
    /// <returns>The user's ID (as <see cref="string"/>) if valid, otherwise null</returns>
    public Task<string?> ValidateTokenAsync(string token);
}
