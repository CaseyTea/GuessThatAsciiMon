
using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace GuessThatAsciiMon.Models
{
    public class Pokemon
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("types")]
        public List<PokemonTypeSlot>? Types { get; set; }

        [JsonPropertyName("weight")]
        public int Weight { get; set; }

        [JsonPropertyName("sprites")]
        public PokemonSprites? Sprites { get; set; }
    }

    
}