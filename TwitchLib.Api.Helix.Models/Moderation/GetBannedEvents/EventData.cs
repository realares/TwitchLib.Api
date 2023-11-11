using System.Text.Json.Serialization;
using System;

namespace TwitchLib.Api.Helix.Models.Moderation.GetBannedEvents
{
    public record EventData
    {
        [JsonPropertyName("broadcaster_id")]
        public string BroadcasterId { get; set; }
        [JsonPropertyName("broadcaster_login")]
        public string BroadcasterLogin { get; set; }
        [JsonPropertyName("broadcaster_name")]
        public string BroadcasterName { get; set; }
        [JsonPropertyName("user_id")]
        public string UserId { get; set; }
        [JsonPropertyName("user_login")]
        public string UserLogin { get; set; }
        [JsonPropertyName("user_name")]
        public string UserName { get; set; }
        [JsonPropertyName("expires_at")]
        public DateTime? ExpiresAt { get; set; }
        [JsonPropertyName("reason")]
        public string Reason { get; set; }
        [JsonPropertyName("moderator_id")]
        public string ModeratorId { get; set; }
        [JsonPropertyName("moderator_login")]
        public string ModeratorLogin { get; set; }
        [JsonPropertyName("moderator_name")]
        public string ModeratorName { get; set; }
    }
}
