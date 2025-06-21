namespace Author.Application.Users.Queries;

[Authorize(Roles = [Roles.Administrator])]
public record GetUserByIdQuery : IRequest<UserDto>
{
    public required Guid Id { get; set; }
}

public sealed class GetUserByIdQueryHandler(
    IAuthorDbContext context)
    : IRequestHandler<GetUserByIdQuery, UserDto>
{
    private readonly IAuthorDbContext _context = context;

    public async Task<UserDto> Handle(
        GetUserByIdQuery request,
        CancellationToken cancellationToken)
    {
        var entity = await _context.Users.FindAsync([request.Id], cancellationToken)
            ?? throw new NotFoundException(nameof(User), request.Id);

        return entity.ToDto();
    }
}