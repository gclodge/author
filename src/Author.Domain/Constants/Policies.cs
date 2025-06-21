namespace Author.Domain.Constants;

public abstract class Policies
{
    public const string CanEdit = nameof(CanEdit);
    public const string CanDelete = nameof(CanDelete);

    public static List<string> GetAdmin()
        => [CanEdit, CanDelete];
}