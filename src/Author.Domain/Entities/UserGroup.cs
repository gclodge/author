namespace Author.Domain.Entities;

[Table("UserGroups")]
public sealed class UserGroup : BaseAuditableEntity, IHasClaims
{
    /// <summary>
    /// The human-readable, unique, identifier of this <see cref="UserGroup"/>
    /// </summary>
    public required string Name { get; set; }

    //<inheritdoc />
    public List<string> Roles { get; set; } = [];

    //<inheritdoc />
    public List<string> Policies { get; set; } = [];

    //<inheritdoc />
    public List<Guid> Permissions { get; set; } = [];

    /// <summary>
    /// [Navigation Property] All associated <see cref="User"/> entities.
    /// </summary>
    public ICollection<User> Users { get; set; } = [];
}
