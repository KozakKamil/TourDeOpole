﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TourDeOpole.Models;
using Xamarin.Forms;

namespace TourDeOpole.Services
{
    public class URLService
    {
        private static readonly string ObjectListUrl = "https://raw.githubusercontent.com/KozakKamil/TourDeOpole/master/Data/0.json";
        private static readonly string ImageListUrl = "https://raw.githubusercontent.com/KozakKamil/TourDeOpole/master/Images/Trips/";

        public static string SetURL(string v)
        {
            return ImageListUrl + v;
        }
        public static async Task<List<Place>> GetPlaces()
        {
            var placeUrl = ObjectListUrl.Replace("0", "jsonPlace");
            var json = await GetJson(placeUrl);
            return JsonConvert.DeserializeObject<List<Place>>(json);
        }
        public static async Task<List<Trip>> GetTrip()
        {
            var tripUrl = ObjectListUrl.Replace("0", "jsonTrip");
            var json = await GetJson(tripUrl);
            return JsonConvert.DeserializeObject<List<Trip>>(json);
        }
        public static async Task<List<Category>> GetCategory()
        {
            var categoryUrl = ObjectListUrl.Replace("0", "jsonCategory");
            var json = await GetJson(categoryUrl);
            return JsonConvert.DeserializeObject<List<Category>>(json);
        }

        public static async Task<string> GetJson(string url)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    throw new Exception($"Request failed with status code {response.StatusCode}");
                }
            }
        }

    }
}

