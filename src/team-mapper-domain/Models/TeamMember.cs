using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace team_mapper_domain.Models;

public class TeamMember
{
    [JsonPropertyName(nameof(Identifier))]
    public Guid Identifier { get; set; }

    [Required]
    [JsonPropertyName(nameof(Name))]
    public string Name { get; set; } = string.Empty;

    public IList<Task> Tasks { get; set; } = new List<Task>();
}
