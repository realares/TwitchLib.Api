using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace TwitchLib.Api.Helix.Models.Extensions.ReleasedExtensions
{
    public record IconUrls
    {
        [JsonPropertyName("100x100")]
        public string Size100x100 { get; set; }
        [JsonPropertyName("24x24")]
        public string Size24x24 { get; set; }
        [JsonPropertyName("300x200")]
        public string Size300x200 { get; set; }
    }
}
