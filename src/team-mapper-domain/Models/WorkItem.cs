using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using team_mapper_domain.Models.Enum;

namespace team_mapper_domain.Models;

public class WorkItem
{
    [Key]
    [JsonPropertyName(nameof(WorkItemId))]
    public Guid WorkItemId { get; set; } = Guid.NewGuid();

    [Required]
    [JsonPropertyName(nameof(Description))]
    public string Description { get; set; } = string.Empty;

    [JsonPropertyName(nameof(EndDate))]
    public DateTime EndDate { get; set; } = DateTime.Now.AddDays(7);

    [JsonPropertyName(nameof(TaskPriority))]
    public TaskPriority TaskPriority { get; set; } = TaskPriority.Low;

    [JsonPropertyName(nameof(TaskCategory))]
    public TaskCategory TaskCategory { get; set; } = TaskCategory.Other;

    [JsonPropertyName(nameof(IsComplete))]
    public bool IsComplete { get; set; } = false;
}
