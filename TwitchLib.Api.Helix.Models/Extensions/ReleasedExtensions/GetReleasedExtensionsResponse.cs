using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace TwitchLib.Api.Helix.Models.Extensions.ReleasedExtensions
{
    public record GetReleasedExtensionsResponse
    {
        [JsonPropertyName("data")]
        public ReleasedExtension[] Data { get; set; }
    }
}
