﻿using System.Text.Json.Serialization;

namespace TwitchLib.Api.Helix.Models.EventSub
{
    public record CreateEventSubSubscriptionResponse
    {
        [JsonPropertyName("data")]
        public EventSubSubscription[] Subscriptions { get; set; } = default!;

        [JsonPropertyName("total")]
        public int Total { get; set; }

        [JsonPropertyName("total_cost")]
        public int TotalCost { get; set; }

        [JsonPropertyName("max_total_cost")]
        public int MaxTotalCost { get; set; }
    }
}