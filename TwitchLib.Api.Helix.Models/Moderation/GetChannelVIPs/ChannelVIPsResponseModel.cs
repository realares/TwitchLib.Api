using System.Text.Json.Serialization;

namespace TwitchLib.Api.Helix.Models.Moderation.GetChannelVIPs
{
    public record ChannelVIPsResponseModel
    {
        /// <summary>
        /// An ID that uniquely identifies the VIP user.
        /// </summary>
        [JsonPropertyName("user_id")]
        public string UserId { get; set; }
        /// <summary>
        /// The user’s display name.
        /// </summary>
        [JsonPropertyName("user_name")]
        public string UserName { get; set; }
        /// <summary>
        /// The user’s login name.
        /// </summary>
        [JsonPropertyName("user_login")]
        public string UserLogin { get; set; }
    }
}
