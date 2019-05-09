using Newtonsoft.Json;

namespace HomeWork16_05_19.Models
{
    public class Forecastday
    {

        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("date_epoch")]
        public int DateEpoch { get; set; }

        [JsonProperty("day")]
        public Day Day { get; set; }

        [JsonProperty("astro")]
        public Astro Astro { get; set; }
    }
}
