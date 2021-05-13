using OpenWeatherN.ViewModel;
using Xunit;

namespace OpenWeatherUnitTest
{
    public class MainviewModelMock
    {

        [Fact]
        public async void Test1()
        {

            MainViewModel viewmodel = new MainViewModel(new WeatherMockService());
            viewmodel.cityName = "Hyderabad";
            var info = await viewmodel.iweatherService.GetweatherReport(viewmodel.cityName);

            Assert.True(info?.TemperatureInfo?.Temp.ToString() != null);


        }

    }
}
