using OpenWeatherN.Models;
using System.Threading.Tasks;

namespace OpenWeatherN.Services
{
    public interface IWeatherService
    {
       Task<WeatherInfo> GetweatherReport(string cityName);
    }
}
