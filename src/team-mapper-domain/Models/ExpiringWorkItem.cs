using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace team_mapper_domain.Models;

public class ExpiringWorkItem
{
    [Key]
    [JsonPropertyName(nameof(ExpiringWorkItemId))]
    public Guid ExpiringWorkItemId { get; set; }

    [JsonPropertyName(nameof(EndDate))]
    public DateTime EndDate { get; set; }

    [JsonPropertyName(nameof(IsNotificationSent))]
    public bool IsNotificationSent { get; set; } = false;

    [Required]
    [JsonPropertyName(nameof(WorkItemId))]
    public Guid WorkItemId { get; set; }

    [JsonPropertyName(nameof(WorkItem))]
    public WorkItem? WorkItem { get; set; }
}
