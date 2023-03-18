using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TourDeOpole.Services;
using Xamarin.Forms;

namespace TourDeOpole.ViewModels
{
    public class SettingViewModel : BaseViewModel
    {
        public Command ConnectDataBaseCommand { get; set; }
        public Command GetPlacesCommand { get; set; }

        public SettingViewModel()
        {
            GetPlacesCommand = new Command(GetPlaceFromJSON);
        }

        private void GetPlaceFromJSON()
        {
            URLService.GetPlaces();
        }
    }
}
