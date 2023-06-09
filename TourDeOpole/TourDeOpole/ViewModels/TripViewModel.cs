using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
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
        public ObservableCollection<Trip> ListOfTrips { get; set; } = new ObservableCollection<Trip>();

        public string SearchBarText { get; set; }
        public ICommand GoToDetailsCommand { get; set; }
        public ICommand GoToAddCommand { get; set; }
        public ICommand GoToScanQRCommand { get; set; }

        public TripViewModel()
        {
            GoToDetailsCommand = new Command<Trip>(async (trip) =>
            {
                await Shell.Current.GoToAsync($"{nameof(TripDetailsView)}?{nameof(TripDetailsViewModel.TripID)}={trip.TripID}");
            });
            GoToAddCommand = new Command(async() => 
            {
                await NavigationService.GoToAddTrip();
            });
            GoToScanQRCommand = new Command(async() => 
            {
                await NavigationService.GoToScanQR();
            });
            ListOfTrips = new ObservableCollection<Trip>();
            LoadTrips();
        }
        /// <summary>
        /// Method loads a list of trips from either a local database or a remote URL. 
        /// </summary>
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
                if (!trip.Image.StartsWith("http"))
                    trip.Image = URLService.SetURL(trip.Image);
                ListOfTrips.Add(trip);
                if (databaseEmpty)
                    await App.Database.SaveTripAsync(trip);
            }
            databaseEmpty = false;
            Trip.ListOfTrips = ListOfTrips;
        }
        public void OnSearchTextChanged(TextChangedEventArgs e, string searchParameter)
        {
            PropertyInfo propertyInfo = typeof(Trip).GetProperty(searchParameter);
            if (string.IsNullOrWhiteSpace(e.NewTextValue))
            {
                ListOfTrips = new ObservableCollection<Trip>(Trip.ListOfTrips);
                OnPropertyChanged(nameof(ListOfTrips));
            }
            else
            {
                ListOfTrips = new ObservableCollection<Trip>(Trip.ListOfTrips.Where(x => propertyInfo.GetValue(x, null).ToString().ToUpper().Contains(e.NewTextValue.ToUpper())));
                OnPropertyChanged(nameof(ListOfTrips));
            }
        }
    }
}
