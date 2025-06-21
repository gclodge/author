namespace Author.Application.UserPermissions.Commands;

[Authorize(Roles = [Roles.Administrator])]
[Authorize(Policy = Policies.CanDelete)]
public record DeleteUserPermissionCommand : IRequest
{
    public required Guid Id { get; set; }
}

public sealed class DeleteUserPermissionCommandHandler(
    IAuthorDbContext context,
    ILogger<DeleteUserPermissionCommandHandler> logger)
    : IRequestHandler<DeleteUserPermissionCommand>
{
    private readonly IAuthorDbContext _context = context;
    private readonly ILogger<DeleteUserPermissionCommandHandler> _logger = logger;
    public async Task Handle(
        DeleteUserPermissionCommand request,
        CancellationToken cancellationToken)
    {
        var entity = await _context.Permissions.FindAsync([request.Id], cancellationToken)
            ?? throw new NotFoundException(nameof(UserPermission), request.Id);

        _logger.LogInformation("Deleting UserPermission: {DTO}", entity.ToDto().ToString());

        _context.Permissions.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);
    }
}