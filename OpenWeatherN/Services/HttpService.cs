using Newtonsoft.Json;
using OpenWeatherN.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeatherN.Services
{
    public class HttpService
    {
        const string BaseUrl = "https://api.openweathermap.org/data/2.5/";
        const string dataType = "weather?";
        
        HttpClient client;

        public HttpService()
        {
            client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
        }
        public async Task<string> GetData(string param)
        {
            try
            {
                var apikey = AppConstants.Instance.ApiKey;
                string url = $"{BaseUrl}{dataType}q={param}&appid={apikey}";
                var httpResponse = await client.GetAsync(url);
                if (httpResponse.IsSuccessStatusCode)
                {
                    return await httpResponse.Content.ReadAsStringAsync();
                }
                
            }
            catch (HttpRequestException ex)
            {
                Debug.WriteLine(ex.StackTrace);
                return "";
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }
            return "";
        }

        
    }
}
