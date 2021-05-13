﻿using Newtonsoft.Json;
using OpenWeatherN.Models;
using OpenWeatherN.Services;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace OpenWeatherUnitTest
{
    class WeatherMockService : IWeatherService
    {
        public async Task<WeatherInfo> GetweatherReport(string cityName)
        {
            try
            {
                HttpService httpService = new HttpService();
                string data = await httpService.GetData(cityName);
                if (data != string.Empty)
                {
                    return JsonConvert.DeserializeObject<WeatherInfo>(data);
                }
                return new WeatherInfo();

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
                return new WeatherInfo();
            }
        }
    }
}
