using System.Text.Json.Serialization;

namespace TwitchLib.Api.Core.Models.Undocumented.ChannelPanels
{
    public class Panel
    {
        [JsonPropertyName("_id")]
        public string Id { get; set; }
        [JsonPropertyName("display_order")]
        public int DisplayOrder { get; set; }
        [JsonPropertyName("default")]
        public string Kind { get; set; }
        [JsonPropertyName("html_description")]
        public string HtmlDescription { get; set; }
        [JsonPropertyName("user_id")]
        public string UserId { get; set; }
        [JsonPropertyName("data")]
        public Data Data { get; set; }
        [JsonPropertyName("channel")]
        public string Channel { get; set; }
    }
}
