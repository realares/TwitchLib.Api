using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace TwitchLib.Api.Helix.Models.Extensions.ReleasedExtensions
{
    public record Panel
    {
        [JsonPropertyName("viewer_url")]
        public string ViewerUrl { get; set; }
        [JsonPropertyName("height")]
        public int Height { get; set; }
        [JsonPropertyName("can_link_external_content")]
        public bool CanLinkExternalContent { get; set; }
    }
}
