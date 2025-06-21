namespace Author.Application.Common.Models;

[method: JsonConstructor]
public sealed class PaginatedList<T>(
    IReadOnlyCollection<T> items,
    int totalCount,
    int pageNumber,
    int totalPages)
{
    [JsonPropertyName("items")]
    public IReadOnlyCollection<T> Items { get; set; } = items;

    [JsonPropertyName("pageNumber")]
    public int PageNumber { get; set; } = pageNumber;
    [JsonPropertyName("totalPages")]
    public int TotalPages { get; set; } = totalPages;
    [JsonPropertyName("totalCount")]
    public int TotalCount { get; set; } = totalCount;

    [JsonIgnore]
    public bool IsEmpty => Items.Count == 0;

    [JsonIgnore]
    public bool HasPreviousPage => PageNumber > 1;

    [JsonIgnore]
    public bool HasNextPage => PageNumber < TotalPages;

    public T this[int index]
    {
        get => Items.ElementAt(index);
    }

    public static PaginatedList<T> Empty(int pageNumber = 1, int pageSize = PagingOptions.DefaultPageSize)
    {
        return new PaginatedList<T>([], 0, pageNumber, 0);
    }

    public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source, int pageNumber, int pageSize)
    {
        var count = await source.CountAsync();
        var items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

        var totalPages = (int)Math.Ceiling(count / (double)pageSize);

        return new PaginatedList<T>(items, count, pageNumber, totalPages);
    }
}

public static class PaginatedListExtensions
{
    public static Task<PaginatedList<TDestination>> ToPaginatedListAsync<TDestination>(this IQueryable<TDestination> queryable, PagingOptions paging) where TDestination : class
        => PaginatedList<TDestination>.CreateAsync(queryable.AsNoTracking(), paging.PageNumber, paging.PageSize);

    public static Task<PaginatedList<TDestination>> ToPaginatedListAsync<TDestination>(this IQueryable<TDestination> queryable, int pageNumber, int pageSize) where TDestination : class
        => PaginatedList<TDestination>.CreateAsync(queryable.AsNoTracking(), pageNumber, pageSize);
}