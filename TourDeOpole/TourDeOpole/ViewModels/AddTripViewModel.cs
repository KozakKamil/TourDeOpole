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
    public class AddTripViewModel : BaseViewModel
    {
        public Command AddTripCommand { get; set; }
        public Command GoBackCommand { get; set; }
        public AddTripViewModel()
        {
            //GoToShareQRCommand = new Command(async () => { await GoToShareQR(); });
            AddTripCommand = new Command(async () => { await Add(); });
            GoBackCommand = new Command(async () => { await GoBack(); });
        }

        private int tripID;
        public int TripID
        {
            get
            {
                return tripID;
            }
            set
            {
                tripID = value;
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
        private async void LoadTripDetails(int tripID)
        {
            try
            {
                var trip = Trip.ListOfTrips.Select(x => x).Where(x => x.TripID == tripID).FirstOrDefault();
                if (trip == null) return;
                ConfigTrip(trip);
            }
            catch
            {
                await App.Current.MainPage.DisplayAlert("Błąd", "Coś poszło nie tak, nie udało się wczytać szczegółów", "Dobrze");
            }
        }
        private Trip ConfigTrip(Trip trip)
        {
            Name = trip.Name;
            Description = trip.Description;
            Image = trip.Image;
            return trip;
        }
        private async Task Add()
        {
            //dodanie do ListOfTrips

        }

        private async Task GoBack()
        {
            await NavigationService.GoBack();
        }
    
    }
}
