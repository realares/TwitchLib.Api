using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace TwitchLib.Api.Helix.Models.Streams.CreateStreamMarker
{
    public class CreateStreamMarkerRequest
    {
        [JsonPropertyName("user_id")]
        public string UserId { get; set; } = null!;

        [JsonPropertyName("description")]
        public string Description { get; set; } = null!;
    }
}
