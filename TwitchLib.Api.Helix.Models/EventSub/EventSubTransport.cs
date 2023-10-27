using System.Text.Json.Serialization;

namespace TwitchLib.Api.Helix.Models.EventSub
{
    public record EventSubTransport
    {
        public EventSubTransport(string method, string callback)
        {
            Method = method;
            Callback = callback;
        }

        [JsonPropertyName("method")]
        public string Method { get; set; } = null!;


        [JsonPropertyName("callback")]
        public string Callback { get; set; } = null!;
    }
}