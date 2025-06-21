namespace Author.Application.UserGroups.Queries;

[Authorize(Roles = [Roles.Administrator])]
public record GetUserGroupsQuery
    : PagingOptions, IRequest<PaginatedList<UserGroupDto>>
{
    public string? SearchString { get; set; }
}

public sealed class GetUserGroupsQueryHandler(
    IAuthorDbContext context)
    : IRequestHandler<GetUserGroupsQuery, PaginatedList<UserGroupDto>>
{
    private readonly IAuthorDbContext _context = context;

    public async Task<PaginatedList<UserGroupDto>> Handle(
        GetUserGroupsQuery request,
        CancellationToken cancellationToken)
    {
        return await _context.Groups.AsNoTracking()
            .Where(p => string.IsNullOrWhiteSpace(request.SearchString) || p.Name.Contains(request.SearchString))
            .OrderByDescending(x => x.Name)
            .Select(x => x.ToDto())
            .ToPaginatedListAsync(request.PageNumber, request.PageSize);
    }
}