using System.Text.Json.Serialization;

namespace TwitchLib.Api.Helix.Models.Chat.Emotes.GetGlobalEmotes
{
    public record GetGlobalEmotesResponse
    {
        [JsonPropertyName("data")]
        public GlobalEmote[] GlobalEmotes { get; set; }
    }
}