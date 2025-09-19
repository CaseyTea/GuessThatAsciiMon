   
using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace GuessThatAsciiMon.Models
{
    public class PokemonTypeSlot
        {
            [JsonPropertyName("type")]
            public PokemonTypeInfo? Type { get; set; }
        }
    
        public class PokemonTypeInfo
        {
            [JsonPropertyName("name")]
            public string? Name { get; set; }
        }
    
}