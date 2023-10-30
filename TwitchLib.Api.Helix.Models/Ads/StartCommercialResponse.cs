using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace TwitchLib.Api.Helix.Models.Ads
{
    /// <summary>
    /// The response for starting a commercial on a specified channel.
    /// </summary>
    public class StartCommercialResponse
    {
        /// <summary>
        /// The length of the commercial you requested. 
        /// If you request a commercial that’s longer than 180 seconds, the API uses 180 seconds.
        /// </summary>
        [JsonPropertyName("length")]
        public int Length { get; set; }

        /// <summary>
        /// A message that indicates whether Twitch was able to serve an ad.
        /// </summary>
        [JsonPropertyName("message")]
        public string Message { get; set; } = null!;

        /// <summary>
        ///  	The number of seconds you must wait before running another commercial.
        /// </summary>
        [JsonPropertyName("retry_after")]
        public int RetryAfter { get; set; } 
    }
}
