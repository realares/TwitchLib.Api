using System.Text.Json.Serialization;

namespace TwitchLib.Api.Helix.Models.Subscriptions
{
    public record GetUserSubscriptionsResponse
    {
        [JsonPropertyName("data")]
        public Subscription[] Data { get; set; }
    }
}