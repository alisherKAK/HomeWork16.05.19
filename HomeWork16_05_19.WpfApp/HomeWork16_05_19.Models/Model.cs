using Newtonsoft.Json;

namespace HomeWork16_05_19.Models
{
    public class Model
    {

        [JsonProperty("location")]
        public Location Location { get; set; }

        [JsonProperty("current")]
        public Current Current { get; set; }

        [JsonProperty("forecast")]
        public Forecast Forecast { get; set; }
    }
}
