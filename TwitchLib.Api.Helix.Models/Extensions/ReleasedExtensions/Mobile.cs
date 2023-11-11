using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace TwitchLib.Api.Helix.Models.Extensions.ReleasedExtensions
{
    public record Mobile
    {
        [JsonPropertyName("viewer_url")]
        public string ViewerUrl { get; set; }
    }
}
