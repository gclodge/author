namespace Author.Application.Authentication.Commands;

public record RefreshAccessTokenCommand : IRequest<string?>
{
    [JsonPropertyName("refresh_token")]
    public string RefreshToken { get; init; } = string.Empty;
}

public sealed class RefreshAccessTokenCommandHandler(
    IAuthenticationService auth,
    IAuthorDbContext context,
    TimeProvider time)
    : IRequestHandler<RefreshAccessTokenCommand, string?>
{
    private readonly IAuthenticationService _auth = auth;
    private readonly IAuthorDbContext _context = context;
    private readonly TimeProvider _time = time;

    public async Task<string?> Handle(
        RefreshAccessTokenCommand request,
        CancellationToken cancellationToken)
    {
        var userId = await _auth.ValidateRefreshTokenAsync(request.RefreshToken);
        if (userId == null) return null;

        var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == userId, cancellationToken);
        if (user == null) return null;

        var token = await _auth.GenerateTokensAsync(user, cancellationToken);

        //< Update last login
        user.LastLogin = _time.GetUtcNow();
        await _context.SaveChangesAsync(cancellationToken);

        return token.AccessToken;
    }
}
