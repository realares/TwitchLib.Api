﻿using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace TwitchLib.Api.Helix.Models.ChannelPoints.UpdateCustomReward
{
    public record UpdateCustomRewardResponse
    {
        [JsonPropertyName("data")]
        public CustomReward[] Data { get; set; }
    }
}
