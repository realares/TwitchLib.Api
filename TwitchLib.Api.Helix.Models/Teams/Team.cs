using System.Text.Json.Serialization;

namespace TwitchLib.Api.Helix.Models.Teams
{
    public record Team : TeamBase
    {
        [JsonPropertyName("users")]
        public TeamMember[] Users { get; set; }
    }
}