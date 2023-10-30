using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;

namespace TwitchLib.Api.Helix.Models.Bits
{
    public class ImageList
    {
        [JsonPropertyName("animated")]
        public Dictionary<string, string> Animated { get; set; } = null!;


        [JsonPropertyName("static")]
        public Dictionary<string, string> Static { get; set; } = null!;
    }
}
