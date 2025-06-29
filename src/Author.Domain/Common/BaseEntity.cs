﻿namespace Author.Domain.Common;

/// <summary>
/// Represents a base entity with a <see cref="Guid"/> primary key within the application.
/// </summary>
public abstract class BaseEntity
{
    /// <summary>
    /// [Primary Key] The <see cref="Guid"/> primary key associated with the entity
    /// </summary>
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    private readonly List<BaseEvent> _domainEvents = [];

    [NotMapped]
    public IReadOnlyCollection<BaseEvent> DomainEvents => _domainEvents.AsReadOnly();

    public void AddDomainEvent(BaseEvent domainEvent) => _domainEvents.Add(domainEvent);

    public void RemoveDomainEvent(BaseEvent domainEvent) => _domainEvents.Remove(domainEvent);

    public void ClearDomainEvents() => _domainEvents.Clear();
}
