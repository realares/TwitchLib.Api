using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace TwitchLib.Api.Helix.Models.Bits
{
    public class Cheermote
    {
        [JsonPropertyName("prefix")]
        public string Prefix { get; set; }
        [JsonPropertyName("tiers")]
        public Tier[] Tiers { get; set; }
        [JsonPropertyName("type")]
        public string Type { get; set; }
        [JsonPropertyName("order")]
        public int Order { get; set; }
        [JsonPropertyName("last_updated")]
        public DateTime LastUpdated { get; set; }
        [JsonPropertyName("is_charitable")]
        public bool IsCharitable { get; set; }
    }
}
