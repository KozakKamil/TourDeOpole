using System;
using System.Collections.ObjectModel;
using System.Threading;
using TourDeOpole.Models;
using TourDeOpole.Services;
using Xamarin.Essentials;
using Xamarin.Forms;


namespace TourDeOpole.ViewModels
{
    //tutaj wszystkie metody, zwykle komendy 

    public partial class PlaceViewModel : BaseViewModel 
    {
        public string SearchBarText { get; set; }
        public Command GoToDetailsCommand { get; set; }
        public Command GoToAddCommand { get; set; }
        public Command GoToScanQRCommand { get; set; }
        public Command ToggleFavoriteCommand { get; set; }

        public ObservableCollection<Place> myPlace { get; set; }
        public ObservableCollection<Category> Category { get; set; }

        public PlaceViewModel()
        {
            GoToDetailsCommand = new Command(GoToDetails);
            GoToAddCommand = new Command(GoToAddPlace);
            GoToScanQRCommand = new Command(GoToScanQR);
            ToggleFavoriteCommand = new Command(FavoritePlace);
            Category = new ObservableCollection<Category>();
            myPlace = new ObservableCollection<Place>();

            LoadCategory();
            LoadPlace();
        }

        private void FavoritePlace()
        {
            throw new NotImplementedException();
        }

        private async void LoadPlace()
        {
            var places = App.Database.GetPlaceAsync().Result;
            var databaseEmpty = false;
            if (places == null || places.Count == 0)
            {
                places = await URLService.GetPlaces();
                databaseEmpty = true;
            }

            foreach (var place in places)
            {
                myPlace.Add(place);
                if (databaseEmpty)
                    await App.Database.SavePlaceAsync(place);
            }
            databaseEmpty = false;
        }

        private async void LoadCategory()
        {
            var categories = App.Database.GetCategoryeAsync().Result;
            var databaseEmpty = false;
            if (categories == null || categories.Count == 0)
            {
                databaseEmpty = true;
                categories = await URLService.GetCategory();
            }

            foreach (var catgory in categories)
            {
                Category.Add(catgory);
                if (databaseEmpty)
                    await App.Database.SaveCategoryAsync(catgory);
            }
            databaseEmpty = false;
        }

        private async void GoToScanQR()
        {
            await NavigationService.GoToScanQR();
        }


        #region GetLocation
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
                if (pEx != null)
                {
                    Alert.DisplayAlert("Wystąpił błąd", "Niestety nie mamy uprawnień do pobrania Twojej lokalizacji", "Dobrze");
                }
            }
            catch
            {
                Alert.DisplayAlert("Wystąpił błąd", "Niestety nie udało się pobrać Twojej lokalizacji", "Dobrze");
            }
        }

        public double CalculateDistanceBetweenLocation(Location location, Location myLocation)
        {
            return Location.CalculateDistance(location, myLocation, DistanceUnits.Kilometers);
        }
        #endregion 

        #region Navigation
        private async void GoToDetails()
        {
            await NavigationService.GoToPlaceDetails();
        }
        private async void GoToAddPlace()
        {
            //Temporary Adding
            var p = new Place { Image = "TopImage.jpg", Name = "Place 1", Description = "xdxdxd, xdx x xd xdxddd xdxdxd xdx xdxdxd xdx xdx xdxdxd xddddd xdxdxd xdxdxd xdxdxd" };
            myPlace.Add(p);
            await App.Database.SavePlaceAsync(p);
            //await NavigationService.GoToAdd();
        }
        #endregion
    }
}
