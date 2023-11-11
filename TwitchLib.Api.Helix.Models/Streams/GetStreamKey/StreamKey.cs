using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace TwitchLib.Api.Helix.Models.Streams.GetStreamKey
{
    public record StreamKey
    {
        [JsonPropertyName("stream_key")]
        public string Key { get; set; }
    }
}
