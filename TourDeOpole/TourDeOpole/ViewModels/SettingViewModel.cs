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
        //TEMP
        public string tempVar { get; set; } 
        public String tempVar2 { get; set; } 
        public ImageSource tempVar3 { get; set; } 
        //TEMP

        public SettingViewModel()
        {

            //TEMP
            tempVar = "https://raw.githubusercontent.com/KozakKamil/TourDeOpole/master/TourDeOpole/TourDeOpole.Android/Resources/drawable/FavoriteCheck.png";
            tempVar2 = "https://raw.githubusercontent.com/KozakKamil/TourDeOpole/master/TourDeOpole/TourDeOpole.Android/Resources/drawable/FavoriteCheck.png";
            tempVar3 = "https://raw.githubusercontent.com/KozakKamil/TourDeOpole/master/TourDeOpole/TourDeOpole.Android/Resources/drawable/FavoriteCheck.png";
            //TEMP

        }

    }
}
