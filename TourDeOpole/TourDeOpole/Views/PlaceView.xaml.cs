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
        PlaceViewModel _viewModel;
        public PlaceView()
        {
            InitializeComponent();
            _viewModel = new PlaceViewModel();
            BindingContext = _viewModel;
            Appearing += (sender, e) =>
            {
                _viewModel.getLocation();
            };
        }

        private void LocationSearchBarTextChanged(object sender, TextChangedEventArgs e)
        {
            _viewModel.OnSearchTextChanged(sender ,e);
        }
    }
}