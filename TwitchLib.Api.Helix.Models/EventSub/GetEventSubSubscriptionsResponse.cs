using System.Text.Json.Serialization;
using TwitchLib.Api.Helix.Models.Common;

namespace TwitchLib.Api.Helix.Models.EventSub
{
    public record GetEventSubSubscriptionsResponse
    {
        [JsonPropertyName("total")]
        public int Total { get; set; } 


        [JsonPropertyName("data")]
        public EventSubSubscription[] Subscriptions { get; set; } = null!;


        [JsonPropertyName("total_cost")]
        public int TotalCost { get; set; } 


        [JsonPropertyName("max_total_cost")]
        public int MaxTotalCost { get; set; } 


        [JsonPropertyName("pagination")]
        public Pagination Pagination { get; set; } = null!;
    }
}