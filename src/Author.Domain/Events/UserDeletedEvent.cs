namespace Author.Domain.Events;

public class UserDeletedEvent(User user) : BaseEvent
{
    public User User { get; } = user ?? throw new ArgumentNullException(nameof(user));
}