namespace Author.Application.Users.Queries;

[Authorize(Roles = [Roles.Administrator])]
public record GetUsersQuery
    : PagingOptions, IRequest<PaginatedList<UserDto>>
{
    public string? SearchString { get; set; }
}

public sealed class GetUsersQueryHandler(
    IAuthorDbContext context)
    : IRequestHandler<GetUsersQuery, PaginatedList<UserDto>>
{
    private readonly IAuthorDbContext _context = context;

    public async Task<PaginatedList<UserDto>> Handle(
        GetUsersQuery request,
        CancellationToken cancellationToken)
    {
        return await _context.Users.AsNoTracking()
            .Where(p => string.IsNullOrWhiteSpace(request.SearchString) || p.UserName.Contains(request.SearchString))
            .OrderByDescending(x => x.LastLogin)
            .Select(x => x.ToDto())
            .ToPaginatedListAsync(request.PageNumber, request.PageSize);
    }
}