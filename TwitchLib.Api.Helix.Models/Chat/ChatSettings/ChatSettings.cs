using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace TwitchLib.Api.Helix.Models.Chat.ChatSettings
{
    public class ChatSettings
    {
        [JsonPropertyName("slow_mode")]
        public bool SlowMode;
        [JsonPropertyName("slow_mode_wait_time")]
        public int? SlowModeWaitTime;
        [JsonPropertyName("follower_mode")]
        public bool FollowerMode;
        [JsonPropertyName("follower_mode_duration")]
        public int? FollowerModeDuration;
        [JsonPropertyName("subscriber_mode")]
        public bool SubscriberMode;
        [JsonPropertyName("emote_mode")]
        public bool EmoteMode;
        [JsonPropertyName("unique_chat_mode")]
        public bool UniqueChatMode;
        [JsonPropertyName("non_moderator_chat_delay")]
        public bool NonModeratorChatDelay;
        [JsonPropertyName("non_moderator_chat_delay_duration")]
        public int? NonModeratorChatDelayDuration;
    }
}
