namespace Author.Application.UserPermissions.Queries;

[Authorize(Roles = [Roles.Administrator])]
public record GetUserPermissionByIdQuery : IRequest<UserPermissionDto>
{
    public required Guid Id { get; set; }
}

public sealed class GetUserPermissionByIdQueryHandler(
    IAuthorDbContext context)
    : IRequestHandler<GetUserPermissionByIdQuery, UserPermissionDto>
{
    private readonly IAuthorDbContext _context = context;
    public async Task<UserPermissionDto> Handle(
        GetUserPermissionByIdQuery request,
        CancellationToken cancellationToken)
    {
        var entity = await _context.Permissions.FindAsync([request.Id], cancellationToken)
            ?? throw new NotFoundException(nameof(UserPermission), request.Id);

        return entity.ToDto();
    }
}