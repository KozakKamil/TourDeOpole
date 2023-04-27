using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourDeOpole.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TourDeOpole.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TripView : ContentPage
    {
        TripViewModel viewModel;
        public TripView()
        {
            InitializeComponent();
            viewModel= new TripViewModel();
            BindingContext = viewModel;
            Appearing += (sender, e) =>
            {
                viewModel.GetLocation();
            };
        }
    }
}