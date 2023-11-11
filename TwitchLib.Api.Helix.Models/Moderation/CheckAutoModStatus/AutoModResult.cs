﻿using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace TwitchLib.Api.Helix.Models.Moderation.CheckAutoModStatus
{
    public record AutoModResult
    {
        [JsonPropertyName("msg_id")]
        public string MsgId { get; set; }
        [JsonPropertyName("is_permitted")]
        public bool IsPermitted { get; set; }
    }
}
