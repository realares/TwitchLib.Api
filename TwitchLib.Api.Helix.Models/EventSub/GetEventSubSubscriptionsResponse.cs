using System.Collections.Generic;
using System.Text.Json.Serialization;
using TwitchLib.Api.Helix.Models.Common;

namespace TwitchLib.Api.Helix.Models.EventSub
{

    public record GetEventSubSubscriptionsResponse
    {
        /// <summary>
        /// The total number of subscriptions you’ve created.
        /// </summary>
        [JsonPropertyName("total")]
        public int Total { get; set; }

        /// <summary>
        /// An array of subscription objects. The list is empty if you don’t have any subscriptions.
        /// </summary>
        [JsonPropertyName("data")]
        public List<EventSubSubscription> Subscriptions { get; set; } = null!;

        /// <summary>
        /// The sum of all of your subscription costs.
        /// </summary>
        [JsonPropertyName("total_cost")]
        public int TotalCost { get; set; }

        /// <summary>
        /// The maximum total cost that you’re allowed to incur for all subscriptions you create.
        /// </summary>
        [JsonPropertyName("max_total_cost")]
        public int MaxTotalCost { get; set; }

        /// <summary>
        /// An object that contains the cursor used to get the next page of subscriptions.
        /// </summary>
        [JsonPropertyName("pagination")]
        public Pagination Pagination { get; set; } = null!;
    }
}