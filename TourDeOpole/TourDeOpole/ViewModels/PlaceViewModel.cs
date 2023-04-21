using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using TourDeOpole.Models;
using TourDeOpole.Services;
using TourDeOpole.Views;
using Xamarin.Essentials;
using Xamarin.Forms;


namespace TourDeOpole.ViewModels
{
    //tutaj wszystkie metody, zwykle komendy 

    public partial class PlaceViewModel : BaseViewModel
    {

        public Command GoToDetailsCommand { get; set; }
        public Command GoToAddCommand { get; set; }
        public Command GoToScanQRCommand { get; set; }

        public ObservableCollection<Place> myPlace { get; set; }
        public ObservableCollection<Category> Category { get; set; }
        public PlaceViewModel()
        {
            GoToDetailsCommand = new Command<Place>(GoToDetails);
            GoToAddCommand = new Command(GoToAddPlace);
            GoToScanQRCommand = new Command(GoToScanQR);
            Category = new ObservableCollection<Category>();
            myPlace = new ObservableCollection<Place>();

            LoadCategory();
        }

        public async void LoadPlace()
        {
            myPlace.Clear();
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
            Place.ListOfPlaces = myPlace;
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

        #region Navigation
        private async void GoToScanQR()
        {
            await NavigationService.GoToScanQR();
        }
        private async void GoToDetails(Place place)
        {
            await Shell.Current.GoToAsync($"{nameof(PlaceDetailsView)}?{nameof(PlaceDetailsViewModel.PlaceID)}={place.PlaceID}");
        }
        private async void GoToAddPlace()
        {
            await NavigationService.GoToAdd();
        }
        #endregion
    }
}
