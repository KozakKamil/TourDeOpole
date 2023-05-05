using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TourDeOpole.Models;
using TourDeOpole.Services;
using Xamarin.Forms;

namespace TourDeOpole.ViewModels
{
    [QueryProperty(nameof(PlaceID), nameof(PlaceID))]
    public class PlaceDetailsViewModel : BaseViewModel
    {
        public ICommand GoToShareQRCommand { get; set; }
        public ICommand AddPlaceCommand { get; set; }
        public ICommand GoBackCommand { get; set; }
        public PlaceDetailsViewModel()
        {
            GoToShareQRCommand = new Command(async () =>
            {
                await NavigationService.GoToShareQR();
            });
            AddPlaceCommand = new Command(async () =>
            {
                await LocationService.GetLocation();
                var place = new Place
                {
                    PlaceID = Place.ListOfPlaces.Max(x => x.PlaceID) + 1,
                    Name = Name,
                    Description = Description,
                    Image = Image,
                };

                if (LocationService.Location != null)
                {
                    place.Latitude = LocationService.Location.Latitude;
                    place.Longitude = LocationService.Location.Longitude;
                }

                await App.Database.SavePlaceAsync(place);
                await NavigationService.GoBack();
            });
            GoBackCommand = new Command(async () =>
            {
                await NavigationService.GoBack();
            });
        }

        private int placeID;
        public int PlaceID
        {
            get
            {
                return placeID;
            }
            set
            {
                placeID = value;
                LoadPlaceDetails(value);
            }
        }

        private string image;
        public string Image
        {
            get => image;
            set => SetProperty(ref image, value);
        }
        private string name;
        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        private string description;
        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        private async void LoadPlaceDetails(int placeID)
        {
            try
            {
                var place = Place.ListOfPlaces.Select(x => x).Where(x => x.PlaceID == placeID).FirstOrDefault();
                if (place == null) return;
                ConfigPlace(place);
            }
            catch
            {
                await App.Current.MainPage.DisplayAlert("Błąd", "Coś poszło nie tak, nie udało się wczytać szczegółów", "Dobrze");
            }
        }

        private Place ConfigPlace(Place place)
        {
            Name = place.Name;
            Description = place.Description;
            Image = place.Image;
            return place;
        }
    }
}
