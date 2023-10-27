using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TwitchLib.Api.Core.Models.Undocumented.ClipChat
{
    public class ReChatMessageAttributesTags
    {
        [JsonPropertyName("badges")]
        public string Badges { get; set; }
        [JsonPropertyName("color")]
        public string Color { get; set; }
        [JsonPropertyName("display-name")]
        public string DisplayName { get; set; }
        [JsonPropertyName("emotes")]
        public Dictionary<string, int[][]> Emotes { get; set; }
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("mod")]
        public bool Mod { get; set; }
        [JsonPropertyName("room-id")]
        public string RoomId { get; set; }
        [JsonPropertyName("sent-ts")]
        public string SentTs { get; set; }
        [JsonPropertyName("subscriber")]
        public bool Subscriber { get; set; }
        [JsonPropertyName("tmi-sent-ts")]
        public string TmiSentTs { get; set; }
        [JsonPropertyName("turbo")]
        public bool Turbo { get; set; }
        [JsonPropertyName("user-id")]
        public string UserId { get; set; }
        [JsonPropertyName("user-type")]
        public string UserType { get; set; }
    }
}
