using System.Text.Json.Serialization;

namespace TwitchLib.Api.Helix.Models.Subscriptions
{
    public record CheckUserSubscriptionResponse
    {
        [JsonPropertyName("data")]
        public Subscription[] Data { get; set; }
    }
}