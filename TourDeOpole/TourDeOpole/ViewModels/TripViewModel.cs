using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using TourDeOpole.Models;
using TourDeOpole.Services;
using Xamarin.Forms;
using Xamarin.Forms.Shapes;

namespace TourDeOpole.ViewModels
{
    public class TripViewModel : BaseViewModel
    {
        public Command GoToDetailsCommand { get; set; }
        public Command GoToAddCommand { get; set; }
        public ObservableCollection<Trip> myTrip { get; set; }
        public TripViewModel()
        {

            GoToDetailsCommand = new Command(GoToDetails);
            GoToAddCommand = new Command(GoToAddTrip);
            myTrip = new ObservableCollection<Trip>()
        {
            new Trip {Image = "TopImage.jpg", Name = "Trip 1", Time = "1h30m" },
            new Trip {Image = "TopImage.jpg", Name = "Trip 2", Time = "1h30m" },
            new Trip {Image = "TopImage.jpg", Name = "Trip 3", Time = "1h30m" }
        };
        }

        private async void GoToDetails()
        {
            await NavigationService.GoToTripDetails();
        }
        private async void GoToAddTrip()
        {
            await NavigationService.GoToAddTrip();
        }

     
    }
}
