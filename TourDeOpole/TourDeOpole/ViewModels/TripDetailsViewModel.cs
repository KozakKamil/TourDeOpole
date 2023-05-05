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
    [QueryProperty(nameof(TripID), nameof(TripID))]
    public class TripDetailsViewModel : BaseViewModel
    {
        public Command GoToShareQRCommand { get; set; }
        public TripDetailsViewModel()
        {
            GoToShareQRCommand = new Command(async() => { await GoToShareQR(); }) ;
        }

        int tripDetailsID;
        public int TripID
        {
            get
            {
                return tripDetailsID;
            }
            set
            {
                tripDetailsID = value;
                LoadTripDetails(value);
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

        private string time;
        public string Time
        {
            get => time;
            set => SetProperty(ref time, value);
        }
        /// <summary>
        /// This function loads the details of a trip with the given tripID.
        /// </summary>
        /// <param name="tripID"></param>
        private async void LoadTripDetails(int tripID)
        {
            try
            {
                var trip = Trip.ListOfTrips.Select(x => x).Where(x => x.TripID == tripID).FirstOrDefault();
                if (trip == null) return;
                Name = trip.Name;
                Description = trip.Description;
                Time=$"Czas trwania: {trip.Time}";
                Image= trip.Image;

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
