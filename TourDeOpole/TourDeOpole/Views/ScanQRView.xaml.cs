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
    public partial class ScanQRView : ContentPage
    {
        private readonly ScanQRViewModel viewModel;
        public ScanQRView()
        {
            InitializeComponent();
            viewModel= new ScanQRViewModel();
            BindingContext = viewModel;
        }

        //Tutaj piszemy tylko UI, metody do viewModelu
    }
}