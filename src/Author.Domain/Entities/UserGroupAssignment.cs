namespace Author.Domain.Entities;

[Table("UserGroupAssignments")]
public sealed class UserGroupAssignment : BaseEntity
{
    /// <summary>
    /// The <see cref="Guid"/> primary key of the <see cref="Entities.User"/> being assigned.
    /// </summary>
    public required Guid UserId { get; set; }

    /// <summary>
    /// The <see cref="Guid"/> primary key of the <see cref="Entities.UserGroup"/> being assigned to.
    /// </summary>
    public required Guid UserGroupId { get; set; }

    /// <summary>
    /// [Navigation Property] The <see cref="Entities.User"/> being assigned.
    /// </summary>
    public User User { get; set; } = null!;

    /// <summary>
    /// [Navigation Property] The <see cref="Entities.UserGroup"/> being assigned to.
    /// </summary>
    public UserGroup UserGroup { get; set; } = null!;
}
