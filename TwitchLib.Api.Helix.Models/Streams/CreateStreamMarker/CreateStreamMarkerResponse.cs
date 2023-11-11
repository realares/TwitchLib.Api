using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace TwitchLib.Api.Helix.Models.Streams.CreateStreamMarker
{
    public record CreateStreamMarkerResponse
    {
        [JsonPropertyName("data")]
        public CreatedMarker[] Data { get; set; }
    }
}
