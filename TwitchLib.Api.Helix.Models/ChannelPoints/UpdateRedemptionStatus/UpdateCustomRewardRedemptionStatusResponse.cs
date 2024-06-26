﻿using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace TwitchLib.Api.Helix.Models.ChannelPoints.UpdateRedemptionStatus
{
    public record UpdateRedemptionStatusResponse
    {
        [JsonPropertyName("data")]
        public RewardRedemption[] Data { get; set; }
    }
}
