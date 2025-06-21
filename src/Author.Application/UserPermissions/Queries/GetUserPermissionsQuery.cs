namespace Author.Application.UserPermissions.Queries;

[Authorize(Roles = [Roles.Administrator])]
public record GetUserPermissionsQuery
    : PagingOptions, IRequest<PaginatedList<UserPermissionDto>>
{
    public string? SearchString { get; set; }
}

public sealed class GetUserPermissionsQueryHandler(
    IAuthorDbContext context)
    : IRequestHandler<GetUserPermissionsQuery, PaginatedList<UserPermissionDto>>
{
    private readonly IAuthorDbContext _context = context;
    public async Task<PaginatedList<UserPermissionDto>> Handle(
        GetUserPermissionsQuery request,
        CancellationToken cancellationToken)
    {
        return await _context.Permissions.AsNoTracking()
            .Where(p => string.IsNullOrWhiteSpace(request.SearchString) || p.Name.Contains(request.SearchString))
            .OrderByDescending(x => x.Name)
            .Select(x => x.ToDto())
            .ToPaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
