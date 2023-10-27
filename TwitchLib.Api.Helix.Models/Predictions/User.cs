using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace TwitchLib.Api.Helix.Models.Predictions
{
    public class User
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("login")]
        public string Login { get; set; }
        [JsonPropertyName("channel_points_used")]
        public int ChannelPointsUsed { get; set; }
        [JsonPropertyName("channel_points_won")]
        public int ChannelPointsWon { get; set; }
    }
}
