using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace TwitchLib.Api.Helix.Models.Users.GetUserBlockList
{
    public record GetUserBlockListResponse
    {
        [JsonPropertyName("data")]
        public BlockedUser[] Data { get; set; }
    }
}
