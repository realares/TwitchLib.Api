using System.Text.Json.Serialization;
using System;

namespace TwitchLib.Api.Helix.Models.Bits
{
    public class Images
    {
        [JsonPropertyName("dark")]
        public ImageList Dark { get; set; }
        [JsonPropertyName("light")]
        public ImageList Light { get; set; }
    }
}
