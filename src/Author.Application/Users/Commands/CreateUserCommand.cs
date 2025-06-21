namespace Author.Application.Users.Commands;

[Authorize(Roles = [Roles.Administrator])]
public record CreateUserCommand : IRequest<Guid>
{
    public required UserDto Dto { get; set; }
}

public sealed class CreateUserCommandHandler(
    IAuthorDbContext context)
    : IRequestHandler<CreateUserCommand, Guid>
{
    private readonly IAuthorDbContext _context = context;

    public async Task<Guid> Handle(
        CreateUserCommand request,
        CancellationToken cancellationToken)
    {
        var entity = request.Dto.ToEntity();

        if (_context.Users.Any(p => p.UserId == entity.UserId))
            throw new AppException($"User with 'user_id' {entity.UserId} already exists!");

        entity.AddDomainEvent(new UserCreatedEvent(entity));

        _context.Users.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}