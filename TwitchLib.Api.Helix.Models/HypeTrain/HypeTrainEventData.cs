using System.Text.Json.Serialization;

namespace TwitchLib.Api.Helix.Models.HypeTrain
{
    public record HypeTrainEventData
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("broadcaster_id")]
        public string BroadcasterId { get; set; }
        [JsonPropertyName("started_at")]
        public string StartedAt { get; set; }
        [JsonPropertyName("expires_at")]
        public string ExpiresAt { get; set; }
        [JsonPropertyName("cooldown_end_time")]
        public string CooldownEndTime { get; set; }
        [JsonPropertyName("level")]
        public int Level { get; set; }
        [JsonPropertyName("goal")]
        public int Goal { get; set; }
        [JsonPropertyName("total")]
        public int Total { get; set; }
        [JsonPropertyName("top_contribution")]
        public HypeTrainContribution TopContribution { get; set; }
        [JsonPropertyName("last_contribution")]
        public HypeTrainContribution LastContribution { get; set; }
    }
}