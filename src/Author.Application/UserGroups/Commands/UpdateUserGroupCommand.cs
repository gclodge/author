namespace Author.Application.UserGroups.Commands;

[Authorize(Roles = [Roles.Administrator])]
[Authorize(Policy = Policies.CanEdit)]
public record UpdateUserGroupCommand : IRequest
{
    public required Guid Id { get; set; }
    public required UserGroupDto Dto { get; set; }
}

public sealed class UpdateUserGroupCommandHandler(
    IAuthorDbContext context,
    ILogger<UpdateUserGroupCommandHandler> logger)
    : IRequestHandler<UpdateUserGroupCommand>
{
    private readonly IAuthorDbContext _context = context;
    private readonly ILogger<UpdateUserGroupCommandHandler> _logger = logger;

    public async Task Handle(
        UpdateUserGroupCommand request,
        CancellationToken cancellationToken)
    {
        var entity = await _context.Groups.FindAsync([request.Id], cancellationToken)
            ?? throw new NotFoundException(nameof(UserGroup), request.Id);

        entity.Name = request.Dto.Name;
        entity.Roles = request.Dto.Roles;
        entity.Policies = request.Dto.Policies;
        entity.Permissions = request.Dto.Permissions;

        _logger.LogInformation("Updating UserGroup: {DTO}", entity.ToDto().ToString());

        await _context.SaveChangesAsync(cancellationToken);
    }
}