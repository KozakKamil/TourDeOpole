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

    //tutaj tylko to co dotyczy UI 
    public partial class MainView : ContentPage
    {
        public MainView()
        {
            InitializeComponent();
            BindingContext = new MainViewModel();
        }
    }
}