using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace TwitchLib.Api.Helix.Models.Bits
{
    public class GetCheermotesResponse
    {
        /// <summary>
        /// The list of Cheermotes. The list is in ascending order by the order field’s value.
        /// </summary>
        [JsonPropertyName("data")]
        public Cheermote[] Listings { get; set; } = null!;
    }
}
