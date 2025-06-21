namespace Author.Application.Common.Models;

public class DatabaseSettings
{
    public const string SectionName = "Database";

    /// <summary>
    /// The fully-composed connection string to the backing database.
    /// </summary>
    public string ConnectionString { get; set; } = string.Empty;
}
