using System.Text.Json.Serialization;

namespace TwitchLib.Api.Helix.Models.Analytics
{
    public class GameAnalytics
    {
        [JsonPropertyName("game_id")]
        public string GameId { get; set; }
        [JsonPropertyName("URL")]
        public string Url { get; set; }
        [JsonPropertyName("type")]
        public string Type { get; set; }
        [JsonPropertyName("date_range")]
        public Common.DateRange DateRange { get; set; }
    }
}
