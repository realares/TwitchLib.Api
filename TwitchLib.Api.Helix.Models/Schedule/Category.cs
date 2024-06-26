﻿using System.Text.Json.Serialization;

namespace TwitchLib.Api.Helix.Models.Schedule
{
    public record Category
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}