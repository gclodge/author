namespace Author.Application.Authentication.Commands;

public record ClientCredentialAuthCommand : IRequest<AuthResultDto?>
{
    [JsonPropertyName("client_id")]
    public string ClientId { get; init; } = string.Empty;

    [JsonPropertyName("client_secret")]
    public string ClientSecret { get; init; } = string.Empty;
}

public sealed class ClientCredentialAuthCommandHandler(
    IAuthenticationService auth,
    IAuthorDbContext context,
    TimeProvider time) 
    : IRequestHandler<ClientCredentialAuthCommand, AuthResultDto?>
{
    private readonly IAuthenticationService _auth = auth;
    private readonly IAuthorDbContext _context = context;
    private readonly TimeProvider _time = time;

    public async Task<AuthResultDto?> Handle(
        ClientCredentialAuthCommand request,
        CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(request.ClientId)) return null;
        if (string.IsNullOrEmpty(request.ClientSecret)) return null;

        var user = await _context.Users
            .FirstOrDefaultAsync(u => u.ClientId == request.ClientId, cancellationToken)
            ?? throw new AuthenticationException($"No user found for ClientId: {request.ClientId}");

        if (user.ClientSecret != request.ClientSecret) return null;

        var token = await _auth.GenerateTokensAsync(user, cancellationToken);

        //< Update last login
        user.LastLogin = _time.GetUtcNow();
        await _context.SaveChangesAsync(cancellationToken);

        return token;
    }
}
