using System.Text.Json.Serialization;
using System.Text.Json.Serialization;

namespace TwitchLib.Api.Helix.Models.Chat.Emotes
{
    public record ChannelEmote : Emote
    {
        [JsonPropertyName("tier")]
        public string Tier { get; set; } = null!;


        [JsonPropertyName("emote_type")]
        public string EmoteType { get; set; } = null!;


        [JsonPropertyName("emote_set_id")]
        public string EmoteSetId { get; set; } = null!;
    }
}