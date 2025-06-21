namespace Author.Application.UserGroups.Commands;

[Authorize(Roles = [Roles.Administrator])]
public record CreateUserGroupCommand : IRequest<Guid>
{
    public required UserGroupDto Dto { get; set; }
}

public sealed class CreateUserGroupCommandHandler(
    IAuthorDbContext context)
    : IRequestHandler<CreateUserGroupCommand, Guid>
{
    private readonly IAuthorDbContext _context = context;

    public async Task<Guid> Handle(
        CreateUserGroupCommand request,
        CancellationToken cancellationToken)
    {
        var entity = request.Dto.ToEntity();

        if (_context.Groups.Any(p => p.Name == entity.Name))
            throw new AppException($"UserGroup with 'name' {entity.Name} already exists!");

        _context.Groups.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
