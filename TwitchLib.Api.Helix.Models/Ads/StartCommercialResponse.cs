using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace TwitchLib.Api.Helix.Models.Ads
{
    public class StartCommercialResponse
    {
        [JsonPropertyName("length")]
        public int Length { get; set; } 

        [JsonPropertyName("message")]
        public string Message { get; set; } = null!;

        [JsonPropertyName("retry_after")]
        public int RetryAfter { get; set; } 
    }
}
