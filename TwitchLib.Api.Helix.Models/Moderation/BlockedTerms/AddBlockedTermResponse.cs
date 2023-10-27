﻿using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace TwitchLib.Api.Helix.Models.Moderation.BlockedTerms
{
    public class AddBlockedTermResponse
    {
        [JsonPropertyName("data")]
        public BlockedTerm[] Data { get; set; }
    }
}
