﻿using System.Text.Json.Serialization;

namespace TwitchLib.Api.ThirdParty.ModLookup
{
    public class StatsResponse
    {
        [JsonPropertyName("status")]
        public int Status { get; set; }
        [JsonPropertyName("stats")]
        public Stats Stats { get; set; }
    }
}
