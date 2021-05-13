using Newtonsoft.Json;

namespace OpenWeatherN.Models
{
    public partial class Weather
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
