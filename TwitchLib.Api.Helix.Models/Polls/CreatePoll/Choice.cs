﻿using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace TwitchLib.Api.Helix.Models.Polls.CreatePoll
{
    public record Choice
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }
    }
}
