using System;
using System.Text.Json.Serialization;

namespace TwitchLib.Api.Helix.Models.Soundtrack.GetCurrentTrack
{
    public record GetCurrentTrackResponse
    {
        [JsonPropertyName("data")]
        public CurrentTrack[] Data { get; set; }
    }
}
