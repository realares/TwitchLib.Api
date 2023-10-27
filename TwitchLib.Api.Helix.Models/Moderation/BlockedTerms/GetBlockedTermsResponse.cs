using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;
using TwitchLib.Api.Helix.Models.Common;

namespace TwitchLib.Api.Helix.Models.Moderation.BlockedTerms
{
    public class GetBlockedTermsResponse
    {
        [JsonPropertyName("data")]
        public BlockedTerm[] Data { get; set; }
        [JsonPropertyName("pagination")]
        public Pagination Pagination { get; set; }
    }
}
