using System.Text.Json.Serialization;

namespace TwitchLib.Api.Core.Models.Undocumented.Chatters
{
    public class ChattersResponse
    {
        [JsonPropertyName("chatter_count")]
        public int ChatterCount { get; set; }
        [JsonPropertyName("chatters")]
        public Chatters Chatters { get; set; }
    }
}
