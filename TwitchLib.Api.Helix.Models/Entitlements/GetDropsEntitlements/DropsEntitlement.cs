using System.Text.Json.Serialization;
using System;
using TwitchLib.Api.Core.Enums;

namespace TwitchLib.Api.Helix.Models.Entitlements.GetDropsEntitlements
{
    public record DropsEntitlement
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("benefit_id")]
        public string BenefitId { get; set; }
        [JsonPropertyName("timestamp")]
        public DateTime Timestamp { get; set; }
        [JsonPropertyName("user_id")]
        public string UserId { get; set; }
        [JsonPropertyName("game_id")]
        public string GameId { get; set; }
        [JsonPropertyName("fulfillment_status")]
        public FulfillmentStatus FulfillmentStatus { get; set; }
        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}
