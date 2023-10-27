using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace TwitchLib.Api.Helix.Models.Bits.ExtensionBitsProducts
{
    public class Cost
    {
        [JsonPropertyName("amount")]
        public int Amount { get; set; }
        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}
