using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace TwitchLib.Api.Helix.Models.Extensions.Transactions
{
    public record ProductData
    {
        [JsonPropertyName("domain")]
        public string Domain { get; set; }
        [JsonPropertyName("sku")]
        public string SKU { get; set; }
        [JsonPropertyName("cost")]
        public Cost Cost { get; set; }
        [JsonPropertyName("inDevelopment")]
        public bool InDevelopment { get; set; }
        [JsonPropertyName("displayName")]
        public string DisplayName { get; set; }
        [JsonPropertyName("expiration")]
        public string Expiration { get; set; }
        [JsonPropertyName("broadcast")]
        public bool Broadcast { get; set; }
    }

    public record Cost
    {
        [JsonPropertyName("amount")]
        public int Amount { get; set; }
        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}
