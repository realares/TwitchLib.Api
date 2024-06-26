﻿using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace TwitchLib.Api.Helix.Models.Moderation.CheckAutoModStatus.Request
{
    public record MessageRequest
    {
        [JsonPropertyName("data")]
        public Message[] Messages { get; set; }
    }
}
