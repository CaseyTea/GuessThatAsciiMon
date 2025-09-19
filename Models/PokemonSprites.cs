   
   
using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace GuessThatAsciiMon.Models
{


    public class PokemonSprites
    {
        [JsonPropertyName("front_default")]
        public string FrontDefaultUrl { get; set; }
    }

}