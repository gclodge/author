namespace Author.Domain.Constants;

public abstract class Roles
{
    public const string Administrator = nameof(Administrator);
    public const string ReadOnly = nameof(ReadOnly);
    public const string User = nameof(User);

    public static List<string> GetAdmin() => [Administrator];
    public static List<string> GetReadOnly() => [ReadOnly];
}
