﻿using System.Text.Json.Serialization;

namespace TwitchLib.Api.Helix.Models.Teams
{
    public record GetTeamsResponse
    {
        [JsonPropertyName("data")]
        public Team[] Teams { get; set; }
    }
}