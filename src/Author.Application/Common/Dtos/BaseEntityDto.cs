namespace Author.Application.Common.Dtos;

/// <summary>
/// An immutable DTO that represents a base entity with a <see cref="Guid"/> primary key within the application.
/// </summary>
public abstract record BaseEntityDto
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }
}
