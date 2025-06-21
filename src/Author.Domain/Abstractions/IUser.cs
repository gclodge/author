namespace Author.Domain.Abstractions;

public interface IUser : IHasClaims
{
    /// <summary>
    /// The User ID as sent by the managing IdP (generally the user's email address)
    /// </summary>
    public string UserId { get; }

    /// <summary>
    /// The textual identifier (or name) associated with this <see cref="User"/> entity
    /// </summary>
    public string UserName { get; }

    /// <summary>
    /// The <see cref="string"/> client identifier that is shared with the end user
    /// </summary>
    public string ClientId { get; }

    /// <summary>
    /// The <see cref="string"/> 'Client Secret' that accompanies the <see cref="ClientId"/> for authenticating the end user
    /// </summary>
    public string ClientSecret { get; } 

    /// <summary>
    /// The <see cref="DateTimeOffset"/> of the last time this <see cref="User"/> entity logged in
    /// </summary>
    public DateTimeOffset? LastLogin { get; }
}
