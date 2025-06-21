namespace Author.Application.UserGroups.Commands;

[Authorize(Roles = [Roles.Administrator])]
[Authorize(Policy = Policies.CanDelete)]
public record DeleteUserGroupCommand : IRequest
{
    public required Guid Id { get; set; }
}

public sealed class DeleteUserGroupCommandHandler(
    IAuthorDbContext context,
    ILogger<DeleteUserGroupCommandHandler> logger)
    : IRequestHandler<DeleteUserGroupCommand>
{
    private readonly IAuthorDbContext _context = context;
    private readonly ILogger<DeleteUserGroupCommandHandler> _logger = logger;

    public async Task Handle(
        DeleteUserGroupCommand request,
        CancellationToken cancellationToken)
    {
        var entity = await _context.Groups.FindAsync([request.Id], cancellationToken)
            ?? throw new NotFoundException(nameof(UserGroup), request.Id);

        _logger.LogInformation("Deleting UserGroup: {DTO}", entity.ToDto().ToString());

        _context.Groups.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);
    }
}