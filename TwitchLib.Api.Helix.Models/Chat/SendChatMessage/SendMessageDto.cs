using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TwitchLib.Api.Helix.Models.Chat.SendChatMessage
{
    public record SendMessageDto
    {
        [JsonPropertyName("broadcaster_id")]
        public string Broadcaster_id { get; set; } = null!;

        [JsonPropertyName("sender_id")]
        public string Sender_id { get; set; } = null!;

        [JsonPropertyName("message")]
        public string Message { get; set; } = null!;

        [JsonPropertyName("reply_parent_message_id")]
        public string? Reply_parent_message_id { get; set; } = null!;

    }
}
