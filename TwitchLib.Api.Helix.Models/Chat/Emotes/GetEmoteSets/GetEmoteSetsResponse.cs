using System.Text.Json.Serialization;

namespace TwitchLib.Api.Helix.Models.Chat.Emotes.GetEmoteSets
{
    public record GetEmoteSetsResponse
    {
        [JsonPropertyName("data")]
        public EmoteSet[] EmoteSets { get; set; }
    }
}