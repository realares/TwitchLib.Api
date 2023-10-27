using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace TwitchLib.Api.Helix.Models.Bits.ExtensionBitsProducts
{
    public class ExtensionBitsProduct
    {
        [JsonPropertyName("sku")]
        public string Sku { get; set; }
        [JsonPropertyName("cost")]
        public Cost Cost { get; set; }
        [JsonPropertyName("in_development")]
        public bool InDevelopment { get; set; }
        [JsonPropertyName("display_name")]
        public string DisplayName { get; set; }
        [JsonPropertyName("expiration")]
        public DateTime Expiration { get; set; }
        [JsonPropertyName("is_broadcast")]
        public bool IsBroadcast { get; set; }
    }
}
