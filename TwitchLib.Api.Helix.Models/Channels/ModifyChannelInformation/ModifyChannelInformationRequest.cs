using System.Text.Json.Serialization;

namespace TwitchLib.Api.Helix.Models.Channels.ModifyChannelInformation
{
    public class ModifyChannelInformationRequest
    {
        [JsonPropertyName("game_id")]
        public string GameId { get; set; } = null!;

        [JsonPropertyName("title")]
        public string Title { get; set; } = null!;

        [JsonPropertyName("broadcaster_language")]
        public string BroadcasterLanguage { get; set; } = null!;

        [JsonPropertyName("delay")]
        public int? Delay { get; set; }

        [JsonPropertyName("tags")]
        public string[] Tags { get; set; } = null!;
    }
}
