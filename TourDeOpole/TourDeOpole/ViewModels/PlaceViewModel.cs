using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows.Input;
using TourDeOpole.Models;
using TourDeOpole.Services;
using TourDeOpole.Views;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace TourDeOpole.ViewModels
{
    //tutaj wszystkie metody, zwykle komendy 

    public partial class PlaceViewModel : BaseViewModel
    {
        public ICommand GoToDetailsCommand { get; set; }
        public ICommand GoToAddCommand { get; set; }
        public ICommand GoToScanQRCommand { get; set; }
        public ICommand ToggleFavoriteCommand { get; set; }

        public ObservableCollection<Place> FilteredPlaces { get; set; } = new ObservableCollection<Place>();
        public ObservableCollection<Category> Category { get; set; } = new ObservableCollection<Category>();

        public PlaceViewModel()
        {
            GoToDetailsCommand = new Command<Place>(async (place) =>
            {
                await Shell.Current.GoToAsync($"{nameof(PlaceDetailsView)}?{nameof(PlaceDetailsViewModel.PlaceID)}={place.PlaceID}");
            });

            GoToAddCommand = new Command(async () =>
            {
                await NavigationService.GoToAdd();
            });
            GoToScanQRCommand = new Command(async () =>
            {
                await NavigationService.GoToScanQR();
            });
            ToggleFavoriteCommand = new Command<Place>((place) =>
            {
                var index = Place.ListOfPlaces.IndexOf(place);
                place.IsFavourite = !place.IsFavourite;
                Place.ListOfPlaces[index] = place;
                LoadPlace();
            });

            LoadCategory();
            LoadPlace();
        }

        public async void LoadPlace()
        {
            FilteredPlaces.Clear();
            var places = App.Database.GetPlaceAsync().Result;
            var databaseEmpty = false;
            if (places == null || places.Count == 0)
            {
                places = await URLService.GetPlaces();
                databaseEmpty = true;
            }

            foreach (var place in places)
            {
                FilteredPlaces.Add(place);
                if (databaseEmpty)
                    await App.Database.SavePlaceAsync(place);
            }
            Place.ListOfPlaces = FilteredPlaces;

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

        public void OnSearchTextChanged(TextChangedEventArgs e, string searchParameter)
        {
            PropertyInfo propertyInfo = typeof(Place).GetProperty(searchParameter);
            if (string.IsNullOrWhiteSpace(e.NewTextValue))
            {
                FilteredPlaces = new ObservableCollection<Place>(Place.ListOfPlaces);
                OnPropertyChanged(nameof(FilteredPlaces));
            }
            else
            {
                FilteredPlaces = new ObservableCollection<Place>(Place.ListOfPlaces.Where(x => propertyInfo.GetValue(x, null).ToString().ToUpper().Contains(e.NewTextValue.ToUpper())));
                OnPropertyChanged(nameof(FilteredPlaces));
            }
        }
    }
}
