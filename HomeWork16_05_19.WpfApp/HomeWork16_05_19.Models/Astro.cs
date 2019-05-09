using Newtonsoft.Json;

namespace HomeWork16_05_19.Models
{
    public class Astro
    {

        [JsonProperty("sunrise")]
        public string Sunrise { get; set; }

        [JsonProperty("sunset")]
        public string Sunset { get; set; }

        [JsonProperty("moonrise")]
        public string Moonrise { get; set; }

        [JsonProperty("moonset")]
        public string Moonset { get; set; }
    }
}
