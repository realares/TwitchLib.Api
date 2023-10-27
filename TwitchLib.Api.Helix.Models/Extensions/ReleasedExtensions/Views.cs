using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace TwitchLib.Api.Helix.Models.Extensions.ReleasedExtensions
{
    public class Views
    {
        [JsonPropertyName("mobile")]
        public Mobile Mobile { get; set; }
        [JsonPropertyName("panel")]
        public Panel Panel { get; set; }
        [JsonPropertyName("video_overlay")]
        public VideoOverlay VideoOverlay { get; set; }
        [JsonPropertyName("component")]
        public Component Component { get; set; }
    }
}
