using System.Text.Json.Serialization;
using System;

namespace TwitchLib.Api.Helix.Models.Moderation.BanUser
{
    public class BannedUser
    {
        [JsonPropertyName("broadcaster_id")]
        public string BroadcasterId { get; set; }
        [JsonPropertyName("moderator_id")]
        public string ModeratorId { get; set; }
        [JsonPropertyName("user_id")]
        public string UserId { get; set; }
        [JsonPropertyName("end_time")]
        public DateTime? EndTime { get; set; }
    }
}
