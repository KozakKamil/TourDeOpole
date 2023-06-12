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

        private string _myLocAdress;
        private string _myLocCity;

        public string MyLocAdress
        {
            get { return _myLocAdress; }
            set
            {
                _myLocAdress = value;
                OnPropertyChanged(nameof(MyLocAdress));
            }
        }

        public string MyLocCity
        {
            get { return _myLocCity; }
            set
            {
                _myLocCity = value;
                OnPropertyChanged(nameof(MyLocCity));
            }
        }
        /// <summary>
        /// Sets a property with a new value and raises the PropertyChanged event if the value has changed.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="backingStore"></param>
        /// <param name="value"></param>
        /// <param name="propertyName"></param>
        /// <param name="onChanged"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Asynchronously gets the current location of the device and updates the corresponding properties of the object.
        /// </summary>
        public async void GetLocation()
        {
       
            try
            {
                var status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();
                if (status != PermissionStatus.Granted)
                {
                    MyLocAdress = "Lokalizacji";
                    MyLocCity = "Brak";
                    return;
                }

                await LocationService.GetLocation();

                var placemark = LocationService.Placemark;

                if (placemark == null)
                {
                    MyLocAdress = "Lokalizacji"; 
                    MyLocCity = "Brak";
                    return;
                }

                MyLocAdress = $"{placemark.Thoroughfare}  {placemark.SubThoroughfare}"; ;
                MyLocCity = $"{placemark.Locality}";
 
                OnPropertyChanged(nameof(MyLocAdress));
                OnPropertyChanged(nameof(MyLocCity));

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

        public double CalculateDistanceBetweenLocation(Place place, Placemark placemark)
        {
            return Location.CalculateDistance(
                            place.Latitude,
                            place.Longitude,
                            placemark.Location.Latitude,
                            placemark.Location.Longitude,
                            DistanceUnits.Kilometers);
        }

        #endregion 

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// Raises the PropertyChanged event with the specified property name.
        /// </summary>
        /// <param name="propertyName"></param>
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
