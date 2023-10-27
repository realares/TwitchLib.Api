using System.Text.Json.Serialization;
using System.Text.Json.Serialization;

namespace TwitchLib.Api.Helix.Models.Chat.Emotes
{
    public record EmoteSet : Emote
    {
        [JsonPropertyName("emote_type")]
        public string EmoteType { get; set; } = null!;

        [JsonPropertyName("emote_set_id")]
        public string EmoteSetId { get; set; } = null!;

        [JsonPropertyName("owner_id")]
        public string OwnerId { get; set; } = null!;
    }
}