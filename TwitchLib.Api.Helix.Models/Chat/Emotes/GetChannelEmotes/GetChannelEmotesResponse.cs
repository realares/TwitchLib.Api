﻿using System.Text.Json.Serialization;

namespace TwitchLib.Api.Helix.Models.Chat.Emotes.GetChannelEmotes
{
    public record GetChannelEmotesResponse
    {
        [JsonPropertyName("data")]
        public ChannelEmote[] ChannelEmotes { get; set; }
    }
}