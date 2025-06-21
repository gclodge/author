namespace Author.Application.UserPermissions.Commands;

[Authorize(Roles = [Roles.Administrator])]
[Authorize(Policy = Policies.CanEdit)]
public record UpdateUserPermissionCommand : IRequest
{
    public required Guid Id { get; set; }
    public required UserPermissionDto Dto { get; set; }
}

public sealed class UpdateUserPermissionCommandHandler(
    IAuthorDbContext context)
    : IRequestHandler<UpdateUserPermissionCommand>
{
    private readonly IAuthorDbContext _context = context;
    public async Task Handle(
        UpdateUserPermissionCommand request,
        CancellationToken cancellationToken)
    {
        var entity = await _context.Permissions.FindAsync([request.Id], cancellationToken)
            ?? throw new NotFoundException(nameof(UserPermission), request.Id);

        if (_context.Permissions.Any(p => p.Name == request.Dto.Name && p.Id != entity.Id))
            throw new AppException($"UserPermission with 'name' {request.Dto.Name} already exists!");

        entity.Key = request.Dto.Key;
        entity.Name = request.Dto.Name;
        entity.Value = request.Dto.Value;

        await _context.SaveChangesAsync(cancellationToken);
    }
}