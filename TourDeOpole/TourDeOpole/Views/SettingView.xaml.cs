using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourDeOpole.ViewModels;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TourDeOpole.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingView : ContentPage
    {
        private readonly SettingViewModel viewModel;
        public SettingView()
        {
            InitializeComponent();
            viewModel = new SettingViewModel();
            BindingContext = viewModel;

            ToggleLocationSetState();
            ToggleCameraSetState();
        }

        //Tutaj piszemy tylko UI, metody do viewModelu
        public void ToggleCameraSetState()
        {

            var permissions = Permissions.CheckStatusAsync<Permissions.Camera>().Result;
            if (permissions == PermissionStatus.Granted)
            {
                CameraSwitch.IsToggled = true;
            }
            else
            {
                CameraSwitch.IsToggled = false;
            }


        }

        public void ToggleLocationSetState()
        {
            var permissions = Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>().Result;
            if (permissions == PermissionStatus.Granted)
            {
                LocalisationSwitch.IsToggled = true;
            }
            else
            {
                LocalisationSwitch.IsToggled = false;
            }
        }

        private void ToggleLocationSwitch_Clicked(object sender, EventArgs e)
        {
            viewModel.ToggleLocationSettingAsync(sender, e);
        }

        private void ToggleCameraSwitch_Clicked(object sender, EventArgs e)
        {
            viewModel.ToggleCameraSwitchSettingAsync(sender, e);
        }

        private void RateUsButton_Clicked(object sender, EventArgs e)
        {
            viewModel.RateUs();
        }

        private void AboutButton_Clicked(object sender, EventArgs e)
        {
            viewModel.About();
        }

        private void PrivacyPolicyButton_Clicked(object sender, EventArgs e)
        {
            viewModel.PrivacyPolicy();
        }

    }
}