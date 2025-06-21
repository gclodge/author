namespace Author.Application.Common.Models;

public record PagingOptions
{
    public const int DefaultPageSize = 10;

    /// <summary>
    /// The current (1-based) page index as an <see cref="int"/>
    /// </summary>
    [JsonPropertyName("page_number")]
    public int PageNumber { get; init; } = 1;

    /// <summary>
    /// The maximum number of elements within the <see cref="PaginatedList{T}"/> to be returned
    /// </summary>
    [JsonPropertyName("page_size")]
    public int PageSize { get; init; } = DefaultPageSize;

    public string ToQuery() => GetQueryString(this);

    /// <summary>
    /// Get the fully-composed query string to be added to the route with the given <see cref="PagingOptions"/> parameters
    /// </summary>
    /// <param name="options"></param>
    /// <returns></returns>
    public static string GetQueryString(PagingOptions options)
        => GetQueryString(options.PageNumber, options.PageSize);

    /// <summary>
    /// Get the fully-composed query string to be added to the route with the given page number and size
    /// </summary>
    /// <param name="pageNumber">The desired (1-based) page number</param>
    /// <param name="pageSize">The total number of elements in each page</param>
    /// <returns></returns>
    public static string GetQueryString(int pageNumber, int pageSize)
        => $"PageNumber={pageNumber}&PageSize={pageSize}";

    /// <summary>
    /// Get the query for the first page with the given page size
    /// </summary>
    /// <param name="pageSize">The number of elements to be returned per-page"/></param>
    /// <returns></returns>
    public static string GetFirstQuery(int pageSize)
        => GetQueryString(1, pageSize);
}