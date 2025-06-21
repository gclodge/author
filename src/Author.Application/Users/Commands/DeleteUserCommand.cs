namespace Author.Application.Users.Commands;

[Authorize(Roles = [Roles.Administrator])]
public record DeleteUserCommand : IRequest
{
    public required Guid Id { get; set; }
}

public sealed class DeleteUserCommandHandler(
    IAuthorDbContext context,
    ICacheService cache,
    ILogger<DeleteUserCommandHandler> logger)
    : IRequestHandler<DeleteUserCommand>
{
    private readonly IAuthorDbContext _context = context;
    private readonly ICacheService _cache = cache;
    private readonly ILogger<DeleteUserCommandHandler> _logger = logger;

    public async Task Handle(
        DeleteUserCommand request,
        CancellationToken cancellationToken)
    {
        var entity = await _context.Users.FindAsync([request.Id], cancellationToken)
            ?? throw new NotFoundException(nameof(User), request.Id);

        _logger.LogInformation("Deleting User: {DTO}", entity.ToDto().ToString());
        
        entity.AddDomainEvent(new UserDeletedEvent(entity));

        _context.Users.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);

        await _cache.RemoveAsync($"user_claims:{entity.Id}", cancellationToken);
    }
}
