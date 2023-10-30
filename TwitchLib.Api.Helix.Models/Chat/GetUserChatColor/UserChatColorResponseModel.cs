
using System.Text.Json.Serialization;

namespace TwitchLib.Api.Helix.Models.Chat.GetUserChatColor
{
    public class UserChatColorResponseModel
    {
        /// <summary>
        /// The ID of the user.
        /// </summary>
        [JsonPropertyName("user_id")]
        public string UserId { get; set; } = null!;

        /// <summary>
        /// The user’s login name.
        /// </summary>
        [JsonPropertyName("user_login")]
        public string UserLogin { get; set; } = null!;

        /// <summary>
        /// The user’s display name.
        /// </summary>
        [JsonPropertyName("user_name")]
        public string UserName { get; set; } = null!;

        /// <summary>
        /// The Hex color code that the user uses in chat for their name. If the user hasn’t specified a color in their settings, the string is empty.
        /// </summary>
        [JsonPropertyName("color")]
        public string Color { get; set; } = null!;
    }
}
