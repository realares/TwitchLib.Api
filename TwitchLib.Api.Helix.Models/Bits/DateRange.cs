using System.Text.Json.Serialization;
using System;

namespace TwitchLib.Api.Helix.Models.Bits
{
    /// <summary>
    /// The reporting window’s start and end dates, in RFC3339 format. 
    /// The dates are calculated by using the started_at and period query parameters. 
    /// If you don’t specify the started_at query parameter, the fields contain empty strings.
    /// </summary>
    public class DateRange
    {
        /// <summary>
        /// The reporting window’s start date.
        /// </summary>
        [JsonPropertyName("started_at")]
        public DateTimeOffset StartedAt { get; set; }

        /// <summary>
        /// The reporting window’s end date.
        /// </summary>
        [JsonPropertyName("ended_at")]
        public DateTimeOffset EndedAt { get; set; }
    }
}
