using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace TwitchLib.Api.Helix.Models.EventSub
{
    public record EventSubSubscription
    {
        /// <summary>
        /// An ID that identifies the subscription.
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; } = null!;

        /// <summary>
        /// The subscription’s status. Possible values: enable, webhook_callback_verification_pending, webhook_callback_verification_failed, notification_failures_exceeded, authorization_revoked, user_removed
        /// </summary>
        [JsonPropertyName("status")]
        public string Status { get; set; } = null!;

        /// <summary>
        /// The subscription’s type.
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; } = null!;

        /// <summary>
        /// The version of the subscription type.
        /// </summary>
        [JsonPropertyName("version")]
        public string Version { get; set; } = null!;

        /// <summary>
        /// The subscription’s parameter values.
        /// </summary>
        [JsonPropertyName("condition")]
        public Dictionary<string, string> Condition { get; set; } = null!;

        /// <summary>
        /// The RFC 3339 timestamp indicating when the subscription was created.
        /// </summary>
        [JsonPropertyName("created_at")]
        public string CreatedAt { get; set; } = null!;

        /// <summary>
        /// The transport details used to send you notifications.
        /// </summary>
        [JsonPropertyName("transport")]
        public EventSubTransport Transport { get; set; } = null!;

        /// <summary>
        /// The amount that the subscription counts against your limit.
        /// </summary>
        [JsonPropertyName("cost")]
        public int Cost { get; set; }
    }
}
