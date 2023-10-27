using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;
using TwitchLib.Api.Core.Enums;

namespace TwitchLib.Api.Helix.Models.ChannelPoints
{
    public class RewardRedemption
    {
        [JsonPropertyName("broadcaster_id")]
        public string BroadcasterId { get; set; }
        [JsonPropertyName("broadcaster_login")]
        public string BroadcasterLogin { get; set; }
        [JsonPropertyName("broadcaster_name")]
        public string BroadcasterName { get; set; }
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("user_id")]
        public string UserId { get; set; }
        [JsonPropertyName("user_login")]
        public string UserLogin { get; set; }
        [JsonPropertyName("user_name")]
        public string UserName { get; set; }
        [JsonPropertyName("user_input")]
        public string UserInput { get; set; }
        [JsonPropertyName("status")]
        public CustomRewardRedemptionStatus Status { get; set; }
        [JsonPropertyName("redeemed_at")]
        public DateTime RedeemedAt { get; set; }
        [JsonPropertyName("reward")]
        public Reward Reward { get; set; }
    }
}
