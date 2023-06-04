using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TourDeOpole.Services;
using TourDeOpole.Views;
using Xamarin.Essentials;
using Xamarin.Forms;
using static Xamarin.Essentials.Permissions;

namespace TourDeOpole.ViewModels
{
    public class SettingViewModel : BaseViewModel
    {
        public SettingViewModel()
        {

        }

        public async void ToggleLocationSettingAsync(object sender, EventArgs e)
        {
            bool request = false;
            if ((sender as Switch).IsToggled)
                request = true;

            if (request)
            {
                await RequestAsync<LocationWhenInUse>();
            }else
            {
                    AppInfo.ShowSettingsUI();
            }

        }
        public async void ToggleCameraSwitchSettingAsync(object sender, EventArgs e)
        {
            bool request = false;
            if ((sender as Switch).IsToggled)
                request = true;
            if (request)
            {
                await RequestAsync<Camera>();
            }
            else
            {
                    AppInfo.ShowSettingsUI();
            }

        }

        internal void About()
        {
            try
            {
                var websiteUrl = "https://github.com/KozakKamil/TourDeOpole/blob/master/README.md";
                Launcher.OpenAsync(new Uri(websiteUrl));
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        internal void PrivacyPolicy()
        {
            throw new NotImplementedException();
        }

        internal void RateUs()
        {
            try
            {
                var websiteUrl = "https://github.com/KozakKamil/TourDeOpole";
                Launcher.OpenAsync(new Uri(websiteUrl));
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

    }
}
