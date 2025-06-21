namespace Author.Application.UserGroups.Queries;

[Authorize(Roles = [Roles.Administrator])]
public record GetUserGroupByIdQuery : IRequest<UserGroupDto>
{
    public required Guid Id { get; set; }
}

public sealed class GetUserGroupByIdQueryHandler(
    IAuthorDbContext context)
    : IRequestHandler<GetUserGroupByIdQuery, UserGroupDto>
{
    private readonly IAuthorDbContext _context = context;

    public async Task<UserGroupDto> Handle(
        GetUserGroupByIdQuery request,
        CancellationToken cancellationToken)
    {
        var entity = await _context.Groups.FindAsync([request.Id], cancellationToken)
            ?? throw new NotFoundException(nameof(UserGroup), request.Id);

        return entity.ToDto();
    }
}