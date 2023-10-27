using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace TwitchLib.Api.Helix.Models.Bits
{
    public class Tier
    {
        [JsonPropertyName("min_bits")]
        public int MinBits { get; set; }
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("color")]
        public string Color { get; set; }
        [JsonPropertyName("images")]
        public Images Images { get; set; }
        [JsonPropertyName("can_cheer")]
        public bool CanCheer { get; set; }
        [JsonPropertyName("show_in_bits_card")]
        public bool ShowInBitsCard { get; set; }
    }
}
