using System.Text.Json.Serialization;
using System;

namespace TwitchLib.Api.Helix.Models.Channels.GetChannelFollowers
{
    public class ChannelFollower
    {
        /// <summary>
        /// An ID that uniquely identifies the user that’s following the broadcaster.
        /// </summary>
        [JsonPropertyName("user_id")]
        public string UserId { get; set; }
        
        /// <summary>
        /// The user’s login name.
        /// </summary>
        [JsonPropertyName("user_login")]
        public string UserLogin { get; set; }
        
        /// <summary>
        /// The user’s display name.
        /// </summary>
        [JsonPropertyName("user_name")]
        public string UserName { get; set; }
        
        /// <summary>
        /// The UTC timestamp when the user started following the broadcaster.
        /// </summary>
        [JsonPropertyName("followed_at")]
        public DateTimeOffset FollowedAt { get; protected set;  }
    }
}