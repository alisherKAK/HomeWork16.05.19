using Newtonsoft.Json;
using System.Collections.Generic;

namespace HomeWork16_05_19.Models
{
    public class Forecast
    {

        [JsonProperty("forecastday")]
        public IList<Forecastday> Forecastday { get; set; }
    }
}
