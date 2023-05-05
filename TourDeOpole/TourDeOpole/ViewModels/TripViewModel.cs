﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    }
}
