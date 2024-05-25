using System.Text.Json.Serialization;

namespace TwitchLib.Api.Helix.Models.Channels.SendChatMessage
{
    public class ChatMessageInfo
    {
        /// <summary>
        /// The message id for the message that was sent.
        /// </summary>
        [JsonPropertyName("message_id")]
        public string MessageId { get; set; } = string.Empty;
        /// <summary>
        /// If the message passed all checks and was sent.
        /// </summary>
        [JsonPropertyName("is_sent")]
        public bool IsSent { get; set; }
        /// <summary>
        /// 	The reason the message was dropped, if any.
        /// </summary>
        [JsonPropertyName("drop_reason")]
        public DropReason? DropReason { get; set; }

    }
}