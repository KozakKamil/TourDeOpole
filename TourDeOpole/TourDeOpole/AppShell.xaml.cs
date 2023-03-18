using System;
using System.Collections.Generic;
using TourDeOpole.Services;
using TourDeOpole.ViewModels;
using TourDeOpole.Views;
using Xamarin.Forms;

namespace TourDeOpole
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        NavigationService navigationService;
        public AppShell()
        {
            InitializeComponent();
            navigationService= new NavigationService();
        }
    }
}
