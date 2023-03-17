using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TourDeOpole.Services;
using Xamarin.Forms;

namespace TourDeOpole.ViewModels
{
    public class TripViewModel : BaseViewModel
    {
        public Command GoToDetailsCommand { get; set; }

        public TripViewModel() 
        {
            GoToDetailsCommand = new Command(GoToDetails);
        }

        private async void GoToDetails()
        {
            await NavigationService.GoToTripDetails();
        }

    }
}
