using System.Text.Json.Serialization;

namespace TwitchLib.Api.Core.Models.Undocumented.ClipChat
{
    public class ReChatMessageAttributes
    {
        [JsonPropertyName("command")]
        public string Command { get; set; }
        [JsonPropertyName("room")]
        public string Room { get; set; }
        [JsonPropertyName("timestamp")]
        public string Timestamp { get; set; }
        [JsonPropertyName("video-offset")]
        public long VideoOffset { get; set; }
        [JsonPropertyName("deleted")]
        public bool Deleted { get; set; }
        [JsonPropertyName("message")]
        public string Message { get; set; }
        [JsonPropertyName("from")]
        public string From { get; set; }
        [JsonPropertyName("tags")]
        public ReChatMessageAttributesTags Tags { get; set; }
        [JsonPropertyName("color")]
        public string Color { get; set; }
    }
}
