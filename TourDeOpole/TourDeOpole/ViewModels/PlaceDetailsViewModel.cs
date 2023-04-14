using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourDeOpole.Models;
using TourDeOpole.Services;
using Xamarin.Forms;

namespace TourDeOpole.ViewModels
{
    [QueryProperty(nameof(PlaceID), nameof(PlaceID))]
    public class PlaceDetailsViewModel : BaseViewModel
    {
        public Command GoToShareQRCommand { get; set; }
        public PlaceDetailsViewModel()
        {
            GoToShareQRCommand = new Command(async () => { await GoToShareQR(); });
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
                var trip = Place.ListOfPlaces.Select(x => x).Where(x => x.PlaceID == placeID).FirstOrDefault();
                if (trip == null) return;
                Name = trip.Name;
                Description = trip.Description;
                Image = trip.Image;

            }
            catch
            {
                await App.Current.MainPage.DisplayAlert("Błąd", "Coś poszło nie tak, nie udało się wczytać szczegółów", "Dobrze");
            }
        }

        private async Task GoToShareQR()
        {
            await NavigationService.GoToShareQR();
        }
    }
}
