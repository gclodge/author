namespace Author.Domain.Entities;

[Table("Users")]
public sealed class User : BaseAuditableEntity, IUser
{
    //<inheritdoc />
    public string UserId { get; set; } = string.Empty;

    //<inheritdoc />
    public string UserName { get; set; } = string.Empty;

    //<inheritdoc />
    public string ClientId { get; set; } = string.Empty;

    //<inheritdoc />
    public string ClientSecret { get; set; } = string.Empty;

    //<inheritdoc />
    public DateTimeOffset? LastLogin { get; set; }

    //<inheritdoc />
    public List<string> Roles { get; set; } = [];

    //<inheritdoc />
    public List<string> Policies { get; set; } = [];

    //<inheritdoc />
    public List<Guid> Permissions { get; set; } = [];

    /// <summary>
    /// [Navigation Property] All associated <see cref="UserGroup"/> entities.
    /// </summary>
    public ICollection<UserGroup> Groups { get; set; } = [];
}
