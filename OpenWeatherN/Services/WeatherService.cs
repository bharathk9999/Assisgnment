using OpenWeatherN.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Diagnostics;

namespace OpenWeatherN.Services
{
    public class WeatherService : IWeatherService
    {

        public async Task<WeatherInfo> GetweatherReport(string cityName)
        {
            try
            {
                HttpService httpService = new HttpService();
                string data = await httpService.GetData(cityName);
                if(data != string.Empty)
                {
                    return JsonConvert.DeserializeObject<WeatherInfo>(data);
                }
                return new WeatherInfo();

            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
                return new WeatherInfo();
            }
        }
    }
}
