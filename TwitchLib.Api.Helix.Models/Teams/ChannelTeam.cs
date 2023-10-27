﻿using System.Text.Json.Serialization;

namespace TwitchLib.Api.Helix.Models.Teams
{
    public class ChannelTeam : TeamBase
    {
        [JsonPropertyName("broadcaster_id")]
        public string BroadcasterId { get; set; }
        [JsonPropertyName("broadcaster_name")]
        public string BroadcasterName { get; set; }
        [JsonPropertyName("broadcaster_login")]
        public string BroadcasterLogin { get; set; }
    }
}