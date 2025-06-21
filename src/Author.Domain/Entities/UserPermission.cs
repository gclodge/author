using System.Security.Claims;

namespace Author.Domain.Entities;

[Table("UserPermissions")]
public sealed class UserPermission : BaseEntity, IClaim
{
    /// <summary>
    /// The human-readable name of this <see cref="UserPermission"/>
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// The <see cref="string"/> key of this <see cref="UserPermission"/> to be used in the generated <see cref="Claim"/>
    /// </summary>
    public required string Key { get; set; }

    /// <summary>
    /// The serialized, textual value of this <see cref="UserPermission"/>
    /// </summary>
    public required string Value { get; set; }

    //<inheritdoc />
    public Claim ToClaim()
    {
        return new Claim(Key, Value);
    }
}
