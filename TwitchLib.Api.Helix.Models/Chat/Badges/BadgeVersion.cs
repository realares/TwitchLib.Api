using System.Text.Json.Serialization;

namespace TwitchLib.Api.Helix.Models.Chat.Badges
{
    public class BadgeVersion
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("image_url_1x")]
        public string ImageUrl1x { get; set; }
        [JsonPropertyName("image_url_2x")]
        public string ImageUrl2x { get; set; }
        [JsonPropertyName("image_url_4x")]
        public string ImageUrl4x { get; set; }
    }
}
