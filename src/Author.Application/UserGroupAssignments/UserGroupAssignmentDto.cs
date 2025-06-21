namespace Author.Application.UserGroupAssignments;

public record UserGroupAssignmentDto : BaseEntityDto
{
    /// <summary>
    /// The <see cref="Guid"/> primary key of the <see cref="User"/> being assigned.
    /// </summary>
    public required Guid UserId { get; set; }

    /// <summary>
    /// The <see cref="Guid"/> primary key of the <see cref="UserGroup"/> being assigned to.
    /// </summary>
    public required Guid UserGroupId { get; set; }
}

public static class UserGroupAssignmentDtoExtensions
{
    public static UserGroupAssignmentDto ToDto(this UserGroupAssignment entity)
    {
        return new UserGroupAssignmentDto
        {
            UserId = entity.UserId,
            UserGroupId = entity.UserGroupId
        };
    }
    public static UserGroupAssignment ToEntity(this UserGroupAssignmentDto dto)
    {
        return new UserGroupAssignment
        {
            Id = dto.Id,
            UserId = dto.UserId,
            UserGroupId = dto.UserGroupId
        };
    }
}