using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TourDeOpole.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml.Internals;

namespace TourDeOpole.Services
{
    public class NavigationService
    {
        public NavigationService() 
        {
            Routing.RegisterRoute(nameof(MainView), typeof(MainView));
            Routing.RegisterRoute(nameof(PlaceDetailsView), typeof(PlaceDetailsView));
            Routing.RegisterRoute(nameof(TripView), typeof(TripView));
            Routing.RegisterRoute(nameof(TripDetailsView), typeof(TripDetailsView));
            Routing.RegisterRoute(nameof(ScanQRView), typeof(ScanQRView));
            Routing.RegisterRoute(nameof(ShareQRView), typeof(ShareQRView)); 
            Routing.RegisterRoute(nameof(SimpleAddView), typeof(SimpleAddView));
            Routing.RegisterRoute(nameof(AddTripView), typeof(AddTripView));
        }

        public static async Task GoToTripDetails()
        {
            await Shell.Current.GoToAsync(nameof(TripDetailsView));
        }

        public static async Task GoToPlaceDetails()
        {
            await Shell.Current.GoToAsync(nameof(PlaceDetailsView));
        }

        public static async Task GoToShareQR()
        {
            await Shell.Current.GoToAsync(nameof(ShareQRView));
        }

        public static async Task GoToScanQR()
        {
            await Shell.Current.GoToAsync(nameof(ScanQRView));
        }
    }
}
