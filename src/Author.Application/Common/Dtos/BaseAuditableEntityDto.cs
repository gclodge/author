namespace Author.Application.Common.Dtos;

public abstract record BaseAuditableEntityDto : BaseEntityDto
{
    [JsonPropertyName("created")]
    public DateTime Created { get; set; }

    [JsonPropertyName("created_by")]
    public string? CreatedBy { get; set; }

    [JsonPropertyName("last_updated")]
    public DateTime? LastUpdated { get; set; }

    [JsonPropertyName("last_updated_by")]
    public string? LastUpdatedBy { get; set; }
}
