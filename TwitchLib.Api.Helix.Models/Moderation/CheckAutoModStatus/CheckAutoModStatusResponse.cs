﻿using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace TwitchLib.Api.Helix.Models.Moderation.CheckAutoModStatus
{
    public class CheckAutoModStatusResponse
    {
        [JsonPropertyName("data")]
        public AutoModResult[] Data { get; set; }
    }
}
