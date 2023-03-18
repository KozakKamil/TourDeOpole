using System;
using System.Collections.Generic;
using System.Text;

namespace TourDeOpole.Services
{
    public class Alert
    {
        public static async void DisplayAlert(string title, string message, string cancel)
        {
            await App.Current.MainPage.DisplayAlert(title, message, cancel);
        }
    }
}
