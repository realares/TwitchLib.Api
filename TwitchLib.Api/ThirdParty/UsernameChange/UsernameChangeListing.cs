using System;
using System.Text.Json.Serialization;

namespace TwitchLib.Api.ThirdParty.UsernameChange
{
    public class UsernameChangeListing
    {
        [JsonPropertyName("userid")]
        public string UserId { get; set; }
        [JsonPropertyName("username_old")]
        public string UsernameOld { get; set; }
        [JsonPropertyName("username_new")]
        public string UsernameNew { get; set; }
        [JsonPropertyName("found_at")]
        public DateTime FoundAt { get; set; }
    }
}
