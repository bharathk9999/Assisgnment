using Newtonsoft.Json;
using System.Collections.Generic;

namespace OpenWeatherN.Models
{
    public partial class WeatherInfo
    {

        [JsonProperty("weather")]
        public List<Weather> Weather { get; set; }

        [JsonProperty("main")]
        public TemperatureInfo TemperatureInfo { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

}
