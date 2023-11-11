using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace TwitchLib.Api.Helix.Models.Bits
{
    /// <summary>
    /// Gets a list of Cheermotes that users can use to cheer Bits in any Bits-enabled channel’s chat room. 
    /// Cheermotes are animated emotes that viewers can assign Bits to.
    /// </summary>
    public record GetCheermotesResponse
    {
        /// <summary>
        /// The list of Cheermotes. The list is in ascending order by the order field’s value.
        /// </summary>
        [JsonPropertyName("data")]
        public Cheermote[] Listings { get; set; } = null!;
    }
}
