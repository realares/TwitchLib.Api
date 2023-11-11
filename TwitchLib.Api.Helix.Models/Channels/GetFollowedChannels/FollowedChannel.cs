using System.Text.Json.Serialization;

namespace TwitchLib.Api.Helix.Models.Channels.GetFollowedChannels
{
    public record FollowedChannel
    {
        /// <summary>
        /// An ID that uniquely identifies the broadcaster that this user is following.
        /// </summary>
        [JsonPropertyName("broadcaster_id")]
        public string BroadcasterId { get; set; }
        
        /// <summary>
        /// The broadcaster’s login name.
        /// </summary>
        [JsonPropertyName("broadcaster_login")]
        public string BroadcasterLogin { get; set; }
        
        /// <summary>
        /// The broadcaster’s display name.
        /// </summary>
        [JsonPropertyName("broadcaster_name")]
        public string BroadcasterName { get; set; }
        
        /// <summary>
        /// The UTC timestamp when the user started following the broadcaster.
        /// </summary>
        [JsonPropertyName("followed_at")]
        public string FollowedAt { get; protected set;  }
    }
}