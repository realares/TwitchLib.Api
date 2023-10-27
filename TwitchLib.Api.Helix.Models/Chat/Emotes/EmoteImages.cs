using System.Text.Json.Serialization;

namespace TwitchLib.Api.Helix.Models.Chat.Emotes
{
    public class EmoteImages
    {
        [JsonPropertyName("url_1x")]
        public string Url1X { get; set; } = null!;

        [JsonPropertyName("url_2x")]
        public string Url2X { get; set; } = null!;

        [JsonPropertyName("url_4x")]
        public string Url4X { get; set; } = null!;
    }
}