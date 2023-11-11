using System.Text.Json.Serialization;

namespace TwitchLib.Api.Helix.Models.Chat.GetChatters
{
    public record Chatter
    {
        /// <summary>
        /// The ID of a user that’s connected to the broadcaster’s chat room.
        /// </summary>
        [JsonPropertyName("user_id")]
        public string UserId { get; set; } = null!;

        /// <summary>
        /// The login name of a user that’s connected to the broadcaster’s chat room.
        /// </summary>
        [JsonPropertyName("user_login")]
        public string UserLogin { get; set; } = null!;

        /// <summary>
        /// The display name of a user that’s connected to the broadcaster’s chat room.
        /// </summary>
        [JsonPropertyName("user_name")]
        public string UserName { get; set; } = null!;
    }
}
