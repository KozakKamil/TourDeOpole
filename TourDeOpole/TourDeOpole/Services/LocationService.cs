using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace TourDeOpole.Services
{
    internal class LocationService
    {
        public static Location Location { get; set; }
        public static Placemark Placemark { get; set; }
        public static async Task GetLocation()
        {
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.High, TimeSpan.FromSeconds(10));
                var cts = new CancellationTokenSource();
                Location = await Geolocation.GetLocationAsync(request, cts.Token);
                if (Location != null)
                {
                    var placemarks = await Geocoding.GetPlacemarksAsync(Location.Latitude, Location.Longitude);
                    Placemark = placemarks?.FirstOrDefault();
                }
            }
            catch (PermissionException pEx)
            {
                if (pEx != null)
                {
                    //Alert.DisplayAlert("Wystąpił błąd", "Niestety nie mamy uprawnień do pobrania Twojej lokalizacji", "Dobrze");
                }
            }
            catch
            {
                //Alert.DisplayAlert("Wystąpił błąd", "Niestety nie udało się pobrać Twojej lokalizacji", "Dobrze");
            }
        }
        public double CalculateDistanceBetweenLocation(Location location, Location myLocation)
        {
            return Location.CalculateDistance(location, myLocation, DistanceUnits.Kilometers);
        }
    }
}
