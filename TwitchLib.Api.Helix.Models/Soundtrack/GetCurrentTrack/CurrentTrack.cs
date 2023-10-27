using System;
using System.Text.Json.Serialization;

namespace TwitchLib.Api.Helix.Models.Soundtrack.GetCurrentTrack
{
    public class CurrentTrack
    {
        [JsonPropertyName("track")]
        public Track Track { get; set; }
        [JsonPropertyName("source")]
        public Source Source { get; set; }
    }
}
