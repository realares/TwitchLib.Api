﻿using System.Text.Json.Serialization;
using TwitchLib.Api.Helix.Models.Common;

namespace TwitchLib.Api.Helix.Models.Entitlements.GetDropsEntitlements
{
    public class GetDropsEntitlementsResponse
    {
        [JsonPropertyName("data")]
        public DropsEntitlement[] DropEntitlements { get; set; }
        [JsonPropertyName("pagination")]
        public Pagination Pagination { get; set; }
    }
}
