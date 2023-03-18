using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TourDeOpole.Models;

namespace TourDeOpole.Services
{
    public class URLService
    {
        private static string PlacesURL = "https://raw.githubusercontent.com/KozakKamil/TourDeOpole/master/Data/Data.json";
        //private static string CategoryURL = "";
        //private static string TripsURL = "";
        public static async void GetPlaces()
        {
            var json = await URLService.GetDataAsync(PlacesURL);
            DecodePlacesFromJSON(json);
        }

        public async static Task<string> GetDataAsync(string url)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var txt = await response.Content.ReadAsStringAsync();
                   return txt;
                }
                else
                {
                    throw new Exception($"Request failed with status code {response.StatusCode}");
                }
            }
        }

        public static List<Place> DecodePlacesFromJSON(string json)
        {
            var places = new List<Place>();
            var cos = JsonConvert.DeserializeObject<Place>(json);
            return places;
        }
    }
}
