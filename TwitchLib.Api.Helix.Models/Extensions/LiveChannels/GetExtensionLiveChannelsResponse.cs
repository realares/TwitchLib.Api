using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace TwitchLib.Api.Helix.Models.Extensions.LiveChannels
{
    public record GetExtensionLiveChannelsResponse
    {
        [JsonPropertyName("data")]
        public LiveChannel[] Data { get; set; }
    }
}
