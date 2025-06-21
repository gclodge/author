namespace Author.Application.Common.Models;

public class AuthenticationSettings
{
    public const string SectionName = "Authentication";

    public string RsaPrivateKey { get; init; } = string.Empty;
    public string RsaPublicKey { get; init; } = string.Empty;

    public int ExpiryMinutes { get; init; } = 60;
    public int RefreshExpiryDays { get; init; } = 7;
    public string Issuer { get; init; } = string.Empty;
    public string Audience { get; init; } = string.Empty;
}