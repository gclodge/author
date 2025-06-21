namespace Author.Domain.Abstractions;

public interface IHasClaims
{
    /// <summary>
    /// A collection of the individual, unique 'roles' assigned to this <see cref="IHasClaims"/> entity.
    /// </summary>
    public List<string> Roles { get; }

    /// <summary>
    /// A collection of the individual, unique 'policies' assigned to this <see cref="IHasClaims"/> entity.
    /// </summary>
    public List<string> Policies { get; }

    /// <summary>
    /// A collection of the <see cref="Guid"/> PK of all <see cref="UserPermission"/> entities that are assigned to this <see cref="UserGroup"/>.
    /// </summary>
    public List<Guid> Permissions { get; }
}
