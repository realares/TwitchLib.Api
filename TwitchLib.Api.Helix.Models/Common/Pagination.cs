using System.Text.Json.Serialization;

namespace TwitchLib.Api.Helix.Models.Common
{
    public record Pagination
    {
        public Pagination(string cursor)
        {
            Cursor = cursor;
        }

        [JsonPropertyName("cursor")]
        public string Cursor { get; set; } = null!;
    }
}
