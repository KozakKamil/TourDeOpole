using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using TourDeOpole.Models;
using TourDeOpole.Repository;
using TourDeOpole.Services;
using TourDeOpole.Views;
using Xamarin.Forms;
using Xamarin.Forms.Shapes;

namespace TourDeOpole.ViewModels
{
    public class TripViewModel : BaseViewModel
    {
        public Command GoToDetailsCommand { get; set; }
        public Command GoToAddCommand { get; set; }
        public Command GoToScanQRCommand { get; set; }
        public TripViewModel()
        {
            GoToDetailsCommand = new Command<Trip>(GoToDetails);
            GoToAddCommand = new Command(GoToAddTrip);
            GoToScanQRCommand = new Command(GoToScanQR);
            ListOfTrips = new ObservableCollection<Trip>();
            LoadTrips();
        }

        private async void LoadTrips()
        {
            var trips = App.Database.GetTripAsync().Result;
            var databaseEmpty = false;
            if (trips == null || trips.Count == 0)
            {
                trips = await URLService.GetTrip();
                databaseEmpty = true;
            }

            foreach (var trip in trips)
            {
                ListOfTrips.Add(trip);
                if (databaseEmpty)
                    await App.Database.SaveTripAsync(trip);
            }
            databaseEmpty = false;
            Trip.ListOfTrips = ListOfTrips;
        }


        private async void GoToDetails(Trip trip)
        {
            await Shell.Current.GoToAsync($"{nameof(TripDetailsView)}?{nameof(TripDetailsViewModel.TripID)}={trip.TripID}");
        }
        private async void GoToAddTrip()
        {
            await NavigationService.GoToAddTrip();
        }

        private async void GoToScanQR()
        {
            await NavigationService.GoToScanQR();
        }
     
    }
}
