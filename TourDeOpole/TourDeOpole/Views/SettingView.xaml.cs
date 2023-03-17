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
    public partial class SettingView : ContentPage
    {
        private readonly SettingViewModel viewModel;
        public SettingView()
        {
            InitializeComponent();
            viewModel= new SettingViewModel();
            BindingContext = viewModel;
        }

        //Tutaj piszemy tylko UI, metody do viewModelu

    }
}