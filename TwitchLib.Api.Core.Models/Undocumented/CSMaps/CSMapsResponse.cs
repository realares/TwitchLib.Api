﻿using System.Text.Json.Serialization;

namespace TwitchLib.Api.Core.Models.Undocumented.CSMaps
{
    public class CSMapsResponse
    {
        [JsonPropertyName("_total")]
        public int Total { get; set; }
        [JsonPropertyName("maps")]
        public Map[] Maps { get; set; }
    }
}
