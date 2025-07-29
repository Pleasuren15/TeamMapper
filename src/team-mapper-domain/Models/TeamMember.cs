using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using team_mapper_domain.Models.Validations;

namespace team_mapper_domain.Models;

public class TeamMember
{
    [Key]
    [JsonPropertyName(nameof(TeamMemberId))]
    public Guid TeamMemberId { get; set; }

    [Required]
    [JsonPropertyName(nameof(Name))]
    public string Name { get; set; } = string.Empty;

    [ValidateEmail]
    [JsonPropertyName(nameof(Email))]
    public string Email { get; set; } = string.Empty;
}
