using System.Text.Json.Serialization;

namespace TwitchLib.Api.Helix.Models.Chat.Badges
{
    public class BadgeEmoteSet
    {
        [JsonPropertyName("set_id")]
        public string SetId { get; set; }
        [JsonPropertyName("versions")]
        public BadgeVersion[] Versions { get; set; }
    }
}
