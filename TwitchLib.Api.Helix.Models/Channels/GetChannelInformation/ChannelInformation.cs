using System.Text.Json.Serialization;

namespace TwitchLib.Api.Helix.Models.Channels.GetChannelInformation
{
    public class ChannelInformation
    {
        [JsonPropertyName("broadcaster_id")]
        public string BroadcasterId { get; set; }
        [JsonPropertyName("broadcaster_login")]
        public string BroadcasterLogin { get; set; }
        [JsonPropertyName("broadcaster_name")]
        public string BroadcasterName { get; set; }
        [JsonPropertyName("broadcaster_language")]
        public string BroadcasterLanguage { get; set; }
        [JsonPropertyName("game_id")]
        public string GameId { get; set; }
        [JsonPropertyName("game_name")]
        public string GameName { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("delay")]
        public int Delay { get; set; }
        [JsonPropertyName("tags")]
        public string[] Tags{get; protected set;}
    }
}
