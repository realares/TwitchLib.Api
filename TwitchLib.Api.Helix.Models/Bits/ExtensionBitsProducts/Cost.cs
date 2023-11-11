using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace TwitchLib.Api.Helix.Models.Bits.ExtensionBitsProducts
{
    /// <summary>
    /// Contains details about the digital product’s cost.
    /// </summary>
    public record Cost
    {
        /// <summary>
        /// The amount exchanged for the digital product.
        /// </summary>
        [JsonPropertyName("amount")]
        public int Amount { get; set; }

        /// <summary>
        /// The type of currency exchanged. Possible values are: bits
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; } = default!;
    }
}
