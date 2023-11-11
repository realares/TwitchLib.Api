using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace TwitchLib.Api.Helix.Models.Streams.GetStreamMarkers
{
    public record Video
    {
        [JsonPropertyName("video_id")]
        public string VideoId { get; set; }
        [JsonPropertyName("markers")]
        public Marker[] Markers { get; set; }
    }
}
