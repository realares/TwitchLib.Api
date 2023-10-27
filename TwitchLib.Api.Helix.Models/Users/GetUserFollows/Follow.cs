using System;
using System.Text.Json.Serialization;

namespace TwitchLib.Api.Helix.Models.Users.GetUserFollows
{
    public class Follow
    {
        [JsonPropertyName("from_id")]
        public string FromUserId { get; set; }

        [JsonPropertyName("from_login")]
        public string FromLogin { get; set; }

        [JsonPropertyName("from_name")]
        public string FromUserName { get; set; }

        [JsonPropertyName("to_id")]
        public string ToUserId { get; set; }

        [JsonPropertyName("to_login")]
        public string ToLogin { get; set; }

        [JsonPropertyName("to_name")]
        public string ToUserName { get; set; }

        [JsonPropertyName("followed_at")]
        public DateTime FollowedAt { get; set; }
    }
}
