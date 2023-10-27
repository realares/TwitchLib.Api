using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;
using TwitchLib.Api.Core.Enums;

namespace TwitchLib.Api.Helix.Models.ChannelPoints.UpdateCustomRewardRedemptionStatus
{
    public class UpdateCustomRewardRedemptionStatusRequest
    {
        [JsonConverter(typeof(System.Text.Json.Serialization.JsonStringEnumConverter))]
        [JsonPropertyName("status")]
        public CustomRewardRedemptionStatus Status { get; set; }
    }
}
