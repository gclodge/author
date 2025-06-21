using Author.Application.Users;

namespace Author.Application.Authentication.Queries;

[Authorize]
public record WhoAmIQuery : IRequest<UserDto>
{ }

public sealed class WhoAmIQueryHandler(
    IAuthorDbContext context,
    TimeProvider time,
    ICurrentUser user) 
    : IRequestHandler<WhoAmIQuery, UserDto>
{
    private readonly IAuthorDbContext _context = context;
    private readonly TimeProvider _time = time;
    private readonly ICurrentUser _user = user;

    public async Task<UserDto> Handle(
        WhoAmIQuery request,
        CancellationToken cancellationToken)
    {
        string userId = _user.Id ?? throw new AuthenticationException("Who goes there?");

        var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == userId, cancellationToken);

        if (user != null)
        {
            return user.ToDto();
        }

        var newUser = new User
        {
            UserId = userId,
            UserName = userId,
            LastLogin = _time.GetUtcNow()
        };

        _context.Users.Add(newUser);

        await _context.SaveChangesAsync(cancellationToken);

        return newUser.ToDto();
    }
}
