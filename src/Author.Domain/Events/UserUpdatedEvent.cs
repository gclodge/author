namespace Author.Domain.Events;

public record UserPropertyChange
{
    public required string PropertyName { get; set; }
    public object? OldValue { get; set; }
    public object? NewValue { get; set; }
}

public class UserUpdatedEvent(IUser from, IUser to) : BaseEvent
{
    public IReadOnlyList<UserPropertyChange> Changes { get; } = GetChanges(from, to);

    private static List<UserPropertyChange> GetChanges(IUser from, IUser to)
    {
        var changes = new List<UserPropertyChange>();
        var properties = typeof(IUser).GetProperties();

        foreach (var prop in properties)
        {
            var oldValue = prop.GetValue(from);
            var newValue = prop.GetValue(to);
            if (!Equals(oldValue, newValue))
            {
                changes.Add(new UserPropertyChange
                {
                    PropertyName = prop.Name,
                    OldValue = oldValue,
                    NewValue = newValue
                });
            }
        }
        return changes;
    }
}