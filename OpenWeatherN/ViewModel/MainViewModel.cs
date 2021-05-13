using OpenWeatherN.Models;
using System;
using OpenWeatherN.Services;
using System.Diagnostics;

namespace OpenWeatherN.ViewModel
{
    public class MainViewModel
    { 
        public WeatherInfo weatherInfo{ get; set; }

        public string cityName { get; set; }

        public IWeatherService iweatherService;

        public delegate void OnWeatherResult(WeatherArgs e);

        public event OnWeatherResult onWeatherEventHandler;

        public MainViewModel(IWeatherService _iweatherService)
        {
            iweatherService = _iweatherService;
        }

        public  async void getTemperature()
        {
            try
            {
                if (cityName?.Length > 0)
                {
                    weatherInfo = await iweatherService.GetweatherReport(cityName);
                    onWeatherEventHandler?.Invoke(new WeatherArgs(weatherInfo));
                }
                else
                {
                    onWeatherEventHandler?.Invoke(new WeatherArgs(weatherInfo));
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
                onWeatherEventHandler?.Invoke(new WeatherArgs(weatherInfo));
            }
                          
        }        
    }

    public class WeatherArgs : EventArgs
    {

        public WeatherInfo _weatherInfo;

        public WeatherArgs(WeatherInfo weatherInfo)

        {

            this._weatherInfo = weatherInfo;

        }

    }
}
