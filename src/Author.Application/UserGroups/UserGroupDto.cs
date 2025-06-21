namespace Author.Application.UserGroups;

public record UserGroupDto : BaseEntityDto, IHasClaims
{
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [JsonPropertyName("roles")]
    public List<string> Roles { get; set; } = [];

    [JsonPropertyName("policies")]
    public List<string> Policies { get; set; } = [];

    [JsonPropertyName("permissions")]
    public List<Guid> Permissions { get; set; } = [];
}

public static class UserGroupDtoExtensions
{
    public static UserGroupDto ToDto(this UserGroup entity)
    {
        return new UserGroupDto
        {
            Id = entity.Id,
            Name = entity.Name,
            Roles = entity.Roles,
            Policies = entity.Policies,
            Permissions = entity.Permissions
        };
    }
    public static UserGroup ToEntity(this UserGroupDto dto)
    {
        return new UserGroup
        {
            Name = dto.Name,
            Roles = dto.Roles,
            Policies = dto.Policies,
            Permissions = dto.Permissions
        };
    }
}