using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using team_mapper_domain.Models.Enum;

namespace team_mapper_domain.Models;

public class Task
{
    [JsonPropertyName(nameof(Id))]
    public Guid Id { get; set; }

    [Required]
    [JsonPropertyName(nameof(Description))]
    public string Description { get; set; } = string.Empty;

    [Required]
    [JsonPropertyName(nameof(EndDate))]
    public DateTime EndDate { get; set; }

    [Required]
    [JsonPropertyName(nameof(TaskPriority))]
    public TaskPriority TaskPriority { get; set; }

    [Required]
    [JsonPropertyName(nameof(TaskCategory))]
    public TaskCategory TaskCategory { get; set; }

    [Required]
    [JsonPropertyName(nameof(IsComplete))]
    public bool IsComplete { get; set; } = false;
}
