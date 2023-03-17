using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using TourDeOpole.Services;
using TourDeOpole.Views;
using System.Threading.Tasks;
using System.Windows.Input;
using TourDeOpole.Services;
using TourDeOpole.Models;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace TourDeOpole.ViewModels
{
    //tutaj wszystkie metody, zwykle komendy 

    public partial class MainViewModel : BaseViewModel
    {
        public Command GoToDetailsCommand { get; set; }
        public MainViewModel()
        {
            GoToDetailsCommand = new Command(GoToDetails);
        }
        private async void GoToDetails()
        {
            await NavigationService.GoToPlaceDetails();
        }
        private string _locationText;
        public string LocationText
        {
            get { return _locationText; }
            set { SetProperty(ref _locationText, value); }
        }


        public ICommand GetDataCommand { get; private set; }

        public MainViewModel()
        {
            GetDataCommand = new Command(async () => await OnGetDataButtonClicked());
        }
        public async void getLocation()
        {
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.High, TimeSpan.FromSeconds(10));
                var cts = new CancellationTokenSource();
                var mylocation = await Geolocation.GetLocationAsync(request, cts.Token);
                var location = new Location(50.664286, 17.936186);
                if (location != null)
                {
                    //DisplayAlert("Tytuł", $"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}", "OK");
                }

                //DisplayAlert("Tytuł", $"Dystans {CalculateDistanceBetweenLocation(location, mylocation)}", "Super");
            }
            catch (PermissionException pEx)
            {
                if(pEx != null)
                {
                    DisplayAlert("Wystąpił błąd", "Niestety nie mamy uprawnień do pobrania Twojej lokalizacji", "Dobrze");
                }
            }
            catch
            {
                DisplayAlert("Wystąpił błąd", "Niestety nie udało się pobrać Twojej lokalizacji", "Dobrze");
            }
        }

        public async void DisplayAlert(string title, string message, string cancel)
        {
            await App.Current.MainPage.DisplayAlert(title, message, cancel);
        }

        public double CalculateDistanceBetweenLocation(Location location, Location myLocation)
        {
            return Location.CalculateDistance(location, myLocation, DistanceUnits.Kilometers);
        }

        private async Task OnGetDataButtonClicked()
        {
            var json = await JSONService.GetDataAsync("https://raw.githubusercontent.com/KozakKamil/TourDeOpole/master/Data/Data.json");
            //var locations = JsonConvert.DeserializeObject<List<Places>>(json);

            //var sb = new StringBuilder();
            //foreach (var location in locations)
            //{
            //    sb.AppendLine($"Name: {location.Name}, Description: {location.Description}");
            //}

            LocationText = json.ToString();
        }
    }
}
