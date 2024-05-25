using System.Text.Json.Serialization;

namespace TwitchLib.Api.Helix.Models.Channels.GetChannelInformation
{
    public record ChannelInformation
    {
        [JsonPropertyName("broadcaster_id")]
        public string BroadcasterId { get; set; } = default!;

        [JsonPropertyName("broadcaster_login")]
        public string BroadcasterLogin { get; set; } = default!;

        [JsonPropertyName("broadcaster_name")]
        public string BroadcasterName { get; set; } = default!;

        [JsonPropertyName("broadcaster_language")]
        public string BroadcasterLanguage { get; set; } = default!;

        [JsonPropertyName("game_id")]
        public string GameId { get; set; } = default!;

        [JsonPropertyName("game_name")]
        public string GameName { get; set; } = default!;

        [JsonPropertyName("title")]
        public string Title { get; set; } = default!;

        [JsonPropertyName("delay")]
        public int Delay { get; set; } = default!;

        [JsonPropertyName("tags")]
        public string[] Tags{get;  set; } = default!;

    }
}
