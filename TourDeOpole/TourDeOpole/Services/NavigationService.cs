using System;
using System.Collections.Generic;
using System.Text;
using TourDeOpole.Views;
using Xamarin.Forms;

namespace TourDeOpole.Services
{
    public class NavigationService
    {
        public NavigationService() 
        {
            Routing.RegisterRoute(nameof(MainView), typeof(MainView));
        }

        private async void GoToMainView()
        {
            await Shell.Current.GoToAsync("//MainView");
        }
    }
}
