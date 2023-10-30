using System.Text.Json.Serialization;

namespace TwitchLib.Api.Helix.Models.Chat.GetUserChatColor
{
    public class GetUserChatColorResponse
    {
        /// <summary>
        /// The list of users and the color code that’s used for their name.
        /// </summary>
        [JsonPropertyName("data")]
        public UserChatColorResponseModel[] Data { get; set; } = null!;
    }
}
