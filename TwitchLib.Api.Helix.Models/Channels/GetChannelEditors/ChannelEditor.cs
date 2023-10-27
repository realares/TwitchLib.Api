using System;
using System.Text.Json.Serialization;

namespace TwitchLib.Api.Helix.Models.Channels.GetChannelEditors
{
    public class ChannelEditor
    {
        [JsonPropertyName("user_id")]
        public string UserId { get; set; }
        [JsonPropertyName("user_name")]
        public string UserName { get; set; }
        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }
    }
}
