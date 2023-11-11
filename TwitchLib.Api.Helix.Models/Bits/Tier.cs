using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace TwitchLib.Api.Helix.Models.Bits
{
    public record Tier
    {
        [JsonPropertyName("min_bits")]
        public int MinBits { get; set; }


        [JsonPropertyName("id")]
        public string Id { get; set; } = null!;


        [JsonPropertyName("color")]
        public string Color { get; set; } = null!;


        [JsonPropertyName("images")]
        public Images Images { get; set; } = null!;


        [JsonPropertyName("can_cheer")]
        public bool CanCheer { get; set; }


        [JsonPropertyName("show_in_bits_card")]
        public bool ShowInBitsCard { get; set; }
    }
}
