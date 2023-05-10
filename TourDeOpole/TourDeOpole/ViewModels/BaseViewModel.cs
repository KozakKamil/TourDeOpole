using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using TourDeOpole.Models;
using TourDeOpole.Services;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace TourDeOpole.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {

        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        public string myLocCity { get; set; }
        public string myLocAdress { get; set; }



        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region GetLocation

        public async void GetLocation()
        {
            try
            {
                await LocationService.GetLocation();

                var placemark = LocationService.Placemark;

                if (placemark == null)
                    return;

                myLocAdress = $"{placemark.Thoroughfare}  {placemark.SubThoroughfare}"; ;
                myLocCity = $"{placemark.Locality}";

                OnPropertyChanged(nameof(myLocAdress));
                OnPropertyChanged(nameof(myLocCity));
            }
            catch (PermissionException pEx)
            {
                if (pEx != null)
                {
                    //Alert.DisplayAlert("Wystąpił błąd", "Niestety nie mamy uprawnień do pobrania Twojej lokalizacji", "Dobrze");
                }
            }
            catch
            {
               // Alert.DisplayAlert("Wystąpił błąd", "Niestety nie udało się pobrać Twojej lokalizacji", "Dobrze");
            }
        }

        public double CalculateDistanceBetweenLocation(Location location, Location myLocation)
        {
            return Location.CalculateDistance(location, myLocation, DistanceUnits.Kilometers);
        }

        #endregion 

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
