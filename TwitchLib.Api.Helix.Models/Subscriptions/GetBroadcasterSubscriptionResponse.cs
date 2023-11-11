using System.Text.Json.Serialization;
using TwitchLib.Api.Helix.Models.Common;

namespace TwitchLib.Api.Helix.Models.Subscriptions
{
    public record GetBroadcasterSubscriptionsResponse
    {
        [JsonPropertyName("data")]
        public Subscription[] Data { get; set; } = default!;

        [JsonPropertyName("pagination")]
        public Pagination Pagination { get; set; } = default!;

        [JsonPropertyName("total")]
        public int Total { get; set; } = default!;

        [JsonPropertyName("points")]
        public int Points { get; set; } = default!;
    }
}