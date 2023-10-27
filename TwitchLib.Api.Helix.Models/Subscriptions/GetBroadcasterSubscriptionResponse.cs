using System.Text.Json.Serialization;
using TwitchLib.Api.Helix.Models.Common;

namespace TwitchLib.Api.Helix.Models.Subscriptions
{
    public class GetBroadcasterSubscriptionsResponse
    {
        [JsonPropertyName("data")]
        public Subscription[] Data { get; set; }
        [JsonPropertyName("pagination")]
        public Pagination Pagination { get; set; }
        [JsonPropertyName("total")]
        public int Total { get; set; }
        [JsonPropertyName("points")]
        public int Points { get; set; }
    }
}