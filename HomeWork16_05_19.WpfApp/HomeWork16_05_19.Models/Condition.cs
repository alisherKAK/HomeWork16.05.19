using Newtonsoft.Json;

namespace HomeWork16_05_19.Models
{
    public class Condition
    {

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("code")]
        public int Code { get; set; }
    }
}
