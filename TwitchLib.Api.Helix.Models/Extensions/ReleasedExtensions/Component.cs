using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace TwitchLib.Api.Helix.Models.Extensions.ReleasedExtensions
{
    public record Component
    {
        [JsonPropertyName("viewer_url")]
        public string ViewerUrl { get; set; }
        [JsonPropertyName("aspect_width")]
        public int AspectWidth { get; set; }
        [JsonPropertyName("aspect_height")]
        public int AspectHeight { get; set; }
        [JsonPropertyName("aspect_ratio_x")]
        public int AspectRatioX { get; set; }
        [JsonPropertyName("aspect_ratio_y")]
        public int AspectRatioY { get; set; }
        [JsonPropertyName("autoscale")]
        public bool Autoscale { get; set; }
        [JsonPropertyName("scale_pixels")]
        public int ScalePixels { get; set; }
        [JsonPropertyName("target_height")]
        public int TargetHeight { get; set; }
        [JsonPropertyName("size")]
        public int Size { get; set; }
        [JsonPropertyName("zoom")]
        public bool Zoom { get; set; }
        [JsonPropertyName("zoom_pixels")]
        public int ZoomPixels { get; set; }
        [JsonPropertyName("can_link_external_content")]
        public string CanLinkExternalContent { get; set; }
    }
}
