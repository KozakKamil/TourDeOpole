using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TourDeOpole.Models;

namespace TourDeOpole.Services
{
    internal class JSONService
    {
        public async static Task<Location> GetDataAsync(string url)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<Location>(json);
                    return data;
                }
                else
                {
                    throw new Exception($"Request failed with status code {response.StatusCode}");
                }
            }
        }
    }
}
