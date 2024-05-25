using System.Text.Json.Serialization;

namespace TwitchLib.Api.Helix.Models.Channels.SendChatMessage
{
    public class SendChatMessageResponse
    {
        /// <summary>
        /// The data for the chat message
        /// </summary>
        [JsonPropertyName("data")]
        public ChatMessageInfo[] Data { get; set; } = default!;
    }

}