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
    public partial class PlaceView : ContentPage
    {
        PlaceViewModel viewModel;
        public PlaceView()
        {
            InitializeComponent();
            viewModel = new PlaceViewModel();
            BindingContext = viewModel;
            Appearing += (sender, e) =>
            {
                viewModel.GetLocation();
                viewModel.LoadPlace();
            };
        }

        private void LocationSearchBarTextChanged(object sender, TextChangedEventArgs e)
        {
            string searchParameter = "Name";
            viewModel.OnSearchTextChanged(e, searchParameter);
        }
    }
}