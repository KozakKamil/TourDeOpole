using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using TourDeOpole.Models;
using TourDeOpole.Repository;
using TourDeOpole.Services;
using Xamarin.Forms;
using Xamarin.Forms.Shapes;

namespace TourDeOpole.ViewModels
{
    public class TripViewModel : BaseViewModel
    {
        public string SearchBarText { get; set; }
        public Command GoToDetailsCommand { get; set; }
        public Command GoToAddCommand { get; set; }
        public Command GoToScanQRCommand { get; set; }
        public ObservableCollection<Trip> myTrip { get; set; }
        public TripViewModel()
        {
            GoToDetailsCommand = new Command(GoToDetails);
            GoToAddCommand = new Command(GoToAddTrip);
            GoToScanQRCommand = new Command(GoToScanQR);
            myTrip = new ObservableCollection<Trip>();
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
                myTrip.Add(trip);
                if (databaseEmpty)
                    await App.Database.SaveTripAsync(trip);
            }
            databaseEmpty = false;
        }


        private async void GoToDetails()
        {
            await NavigationService.GoToTripDetails();
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
