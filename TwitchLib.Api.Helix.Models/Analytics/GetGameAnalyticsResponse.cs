using System.Text.Json.Serialization;

namespace TwitchLib.Api.Helix.Models.Analytics
{
    public class GetGameAnalyticsResponse
    {
        [JsonPropertyName("data")]
        public GameAnalytics[] Data { get; set; }

        [JsonPropertyName("pagination")]
        public Common.Pagination Pagination { get; set; }
    }
}
