namespace Author.Application.Users;

public record UserDto : BaseEntityDto, IUser
{
    [JsonPropertyName("user_id")]
    public required string UserId { get; set; }

    [JsonPropertyName("user_name")]
    public required string UserName { get; set; }

    [JsonPropertyName("client_id")]
    public string ClientId { get; set; } = string.Empty;

    [JsonPropertyName("client_secret")]
    public string ClientSecret { get; set; } = string.Empty;

    [JsonPropertyName("last_login")]
    public DateTimeOffset? LastLogin { get; set; }

    [JsonPropertyName("roles")]
    public List<string> Roles { get; set; } = [];

    [JsonPropertyName("policies")]
    public List<string> Policies { get; set; } = [];

    [JsonPropertyName("permissions")]
    public List<Guid> Permissions { get; set; } = [];
}

public static class UserDtoExtensions
{
    public static User ToEntity(this UserDto dto)
    {
        return new User
        {
            UserId = dto.UserId,
            UserName = dto.UserName,
            ClientId = dto.ClientId,
            ClientSecret = dto.ClientSecret,
            Roles = dto.Roles,
            Policies = dto.Policies,
            Permissions = dto.Permissions,
        };
    }

    public static UserDto ToDto(this User entity)
    {
        return new UserDto
        {
            Id = entity.Id,
            UserId = entity.UserId,
            UserName = entity.UserName,
            ClientId = entity.ClientId,
            ClientSecret = entity.ClientSecret, //< TODO - Should we really be including this?
            LastLogin = entity.LastLogin,
            Roles = entity.Roles,
            Policies = entity.Policies,
            Permissions = entity.Permissions
        };
    }
}