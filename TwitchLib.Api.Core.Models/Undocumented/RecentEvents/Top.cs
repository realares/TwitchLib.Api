using System.Text.Json.Serialization;

namespace TwitchLib.Api.Core.Models.Undocumented.RecentEvents
{
    public class Top
    {
        [JsonPropertyName("has_top_event")]
        public bool HasTopEvent { get; set; }
        [JsonPropertyName("message_id")]
        public string MessageId { get; set; }
        [JsonPropertyName("amount")]
        public int Amount { get; set; }
        [JsonPropertyName("bits_used")]
        public int? BitsUsed { get; set; }
        [JsonPropertyName("message")]
        public string Message { get; set; }
        [JsonPropertyName("user_id")]
        public string UserId { get; set; }
        [JsonPropertyName("username")]
        public string Username { get; set; }
        //TODO: consider tags param
    }
}
