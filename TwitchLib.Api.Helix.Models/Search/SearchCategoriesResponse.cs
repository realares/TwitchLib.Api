using System.Text.Json.Serialization;
using TwitchLib.Api.Helix.Models.Common;
using TwitchLib.Api.Helix.Models.Games;

namespace TwitchLib.Api.Helix.Models.Search
{
    public record SearchCategoriesResponse
    {
        [JsonPropertyName("data")]
        public Game[] Games { get; set; }
        [JsonPropertyName("pagination")]
        public Pagination Pagination { get; set; }
    }
}
