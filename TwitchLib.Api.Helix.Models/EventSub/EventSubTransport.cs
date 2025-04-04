using System.Text.Json.Serialization;

namespace TwitchLib.Api.Helix.Models.EventSub
{
    /// <summary>
    /// The transport details used to send the notifications.
    /// </summary>
    public record EventSubTransport
    {
        
        /// <summary>
        /// The transport method. Possible values are:
        /// </summary>
        [JsonPropertyName("method")]
        public string Method { get; set; } = null!;

        /// <summary>
        /// The callback URL where the notifications are sent. Included only if method is set to webhook.
        /// </summary>
        [JsonPropertyName("callback")]
        public string Callback { get; set; } = null!;

        /// <summary>
        /// An ID that identifies the WebSocket that notifications are sent to. Included only if method is set to websocket.
        /// </summary>
        [JsonPropertyName("session_id")]
        public string SessionId { get; set; } = null!;

        /// <summary>
        /// The UTC date and time that the WebSocket connection was established. Included only if method is set to websocket.
        /// </summary>
        [JsonPropertyName("connected_at")]
        public string ConnectedAt { get; set; } = null!;

        /// <summary>
        /// The UTC date and time that the WebSocket connection was disconnected. Included only if method is set to websocket.
        /// </summary>
        [JsonPropertyName("disconnected_at")]
        public string DisconnectedAt { get; set; } = null!;
    }
}