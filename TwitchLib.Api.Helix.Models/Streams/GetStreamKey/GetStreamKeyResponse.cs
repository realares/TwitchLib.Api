using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace TwitchLib.Api.Helix.Models.Streams.GetStreamKey
{
    public record GetStreamKeyResponse
    {
        [JsonPropertyName("data")]
        public StreamKey[] Streams { get; set; }
    }
}
