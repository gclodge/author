namespace Author.Application.Users.Commands;

[Authorize(Roles = [Roles.Administrator])]
public record UpdateUserCommand : IRequest
{
    public required Guid Id { get; set; }

    public UserDto? Dto { get; set; }
}

public sealed class UpdateUserCommandHandler(
    IAuthorDbContext context,
    ICacheService cache)
    : IRequestHandler<UpdateUserCommand>
{
    private readonly IAuthorDbContext _context = context;
    private readonly ICacheService _cache = cache;

    public async Task Handle(
        UpdateUserCommand request,
        CancellationToken cancellationToken)
    {
        if (request.Dto is null) throw new AppException(nameof(request.Dto));

        var entity = await _context.Users.FindAsync([request.Id], cancellationToken)
            ?? throw new NotFoundException(nameof(User), request.Id);

        entity.AddDomainEvent(new UserUpdatedEvent(entity, request.Dto));

        entity.UserId = request.Dto.UserId;
        entity.UserName = request.Dto.UserName;
        entity.ClientId = request.Dto.ClientId;
        entity.ClientSecret = request.Dto.ClientSecret;
        entity.Roles = request.Dto.Roles;
        entity.Policies = request.Dto.Policies;

        await _context.SaveChangesAsync(cancellationToken);

        await _cache.RemoveAsync($"user_claims:{entity.Id}", cancellationToken);
    }
}