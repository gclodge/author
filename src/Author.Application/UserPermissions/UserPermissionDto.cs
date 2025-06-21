namespace Author.Application.UserPermissions;

public record UserPermissionDto : BaseEntityDto
{
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [JsonPropertyName("key")]
    public required string Key { get; set; }

    [JsonPropertyName("value")]
    public required string Value { get; set; }
}

public static class UserPermissionDtoExtensions
{
    public static UserPermissionDto ToDto(this UserPermission entity)
    {
        return new UserPermissionDto
        {
            Id = entity.Id,
            Name = entity.Name,
            Key = entity.Key,
            Value = entity.Value
        };
    }
    public static UserPermission ToEntity(this UserPermissionDto dto)
    {
        return new UserPermission
        {
            Name = dto.Name,
            Key = dto.Key,
            Value = dto.Value
        };
    }
}