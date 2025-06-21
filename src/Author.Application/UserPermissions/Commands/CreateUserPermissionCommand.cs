namespace Author.Application.UserPermissions.Commands;

[Authorize(Roles = [Roles.Administrator])]
public record CreateUserPermissionCommand : IRequest<Guid>
{
    public required UserPermissionDto Dto { get; set; }
}

public sealed class CreateUserPermissionCommandHandler(
    IAuthorDbContext context)
    : IRequestHandler<CreateUserPermissionCommand, Guid>
{
    private readonly IAuthorDbContext _context = context;
    public async Task<Guid> Handle(
        CreateUserPermissionCommand request,
        CancellationToken cancellationToken)
    {
        var entity = request.Dto.ToEntity();

        if (_context.Permissions.Any(p => p.Name == entity.Name))
            throw new AppException($"UserPermission with 'name' {entity.Name} already exists!");

        _context.Permissions.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
