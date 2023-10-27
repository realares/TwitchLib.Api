using System.Text.Json.Serialization;

namespace TwitchLib.Api.Core.Models.Undocumented.CSStreams
{
    public class Preview
    {
        [JsonPropertyName("small")]
        public string Small { get; set; }
        [JsonPropertyName("medium")]
        public string Medium { get; set; }
        [JsonPropertyName("large")]
        public string Large { get; set; }
        [JsonPropertyName("template")]
        public string Template { get; set; }
    }
}
