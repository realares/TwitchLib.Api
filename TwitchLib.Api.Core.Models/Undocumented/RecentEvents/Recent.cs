using System.Text.Json.Serialization;

namespace TwitchLib.Api.Core.Models.Undocumented.RecentEvents
{
    public class Recent
    {
        [JsonPropertyName("has_recent_events")]
        public bool HasRecentEvents { get; set; }
        [JsonPropertyName("message_id")]
        public string MessageId { get; set; }
        [JsonPropertyName("timestamp")]
        public string Timestamp { get; set; }
        [JsonPropertyName("channel_id")]
        public string ChannelId { get; set; }
        [JsonPropertyName("allotted_time_ms")]
        public long AllottedTimeMs { get; set; }
        [JsonPropertyName("time_remaining_ms")]
        public long TimeRemainingMs { get; set; }
        [JsonPropertyName("amount")]
        public int Amount { get; set; }
        [JsonPropertyName("bits_used")]
        public int? BitsUsed { get; set; }
        [JsonPropertyName("message")]
        public string Message { get; set; }
        [JsonPropertyName("user_id")]
        public string UserId { get; set; }
        [JsonPropertyName("username")]
        public string Username { get; set; }
        //TODO: consider tags property
    }
}
