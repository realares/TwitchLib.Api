using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace TwitchLib.Api.Helix.Models.Users.GetUserBlockList
{
    public class BlockedUser
    {
        [JsonPropertyName("user_id")]
        public string Id { get; set; }
        [JsonPropertyName("user_login")]
        public string UserLogin { get; set; }
        [JsonPropertyName("display_name")]
        public string DisplayName { get; set; }
    }
}
