using System.Text.Json.Serialization;

namespace AppMobileChuckNorris.Models
{
    public class HarryPotterCharacter
    {
        [JsonPropertyName("fullName")]
        public string FullName { get; set; } = string.Empty;

        [JsonPropertyName("nickname")]
        public string Nickname { get; set; } = string.Empty;

        [JsonPropertyName("hogwartsHouse")]
        public string HogwartsHouse { get; set; } = string.Empty;

        [JsonPropertyName("interpretedBy")]
        public string InterpretedBy { get; set; } = string.Empty;

        [JsonPropertyName("image")]
        public string Image { get; set; } = string.Empty;

        [JsonPropertyName("birthdate")]
        public string Birthdate { get; set; } = string.Empty;
    }
}