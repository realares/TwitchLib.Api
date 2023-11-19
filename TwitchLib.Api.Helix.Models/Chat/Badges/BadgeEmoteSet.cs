using System.Text.Json.Serialization;

namespace TwitchLib.Api.Helix.Models.Chat.Badges
{
    public record BadgeEmoteSet
    {
        [JsonPropertyName("set_id")]
        public string SetId { get; set; } = null!;

        [JsonPropertyName("versions")]
        public BadgeVersion[] Versions { get; set; } = null!;
    }
}
