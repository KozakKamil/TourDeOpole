using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourDeOpole.Services;
using TourDeOpole.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TourDeOpole.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    //tutaj tylko to co dotyczy UI 
    public partial class MainView : ContentPage
    {
        MainViewModel _viewModel;
        public MainView()
        {
            InitializeComponent();
            _viewModel= new MainViewModel();
            BindingContext = _viewModel;
            Appearing += (sender, e) =>
            {
                _viewModel.getLocation();
            };
        }

        private async void LoadData()
        {
            var data = await JSONService.GetDataAsync("https://raw.githubusercontent.com/KozakKamil/TourDeOpole/master/Data/Data.json");
            BindingContext = data;
        }
        private async void OnGetDataButtonClicked(object sender, EventArgs e)
        {
            var data = await JSONService.GetDataAsync("https://raw.githubusercontent.com/KozakKamil/TourDeOpole/master/Data/Data.json");
            locationLabel.Text = $"Lokalizacja: {data.Name}, {data.Description}";
        }
    }
}