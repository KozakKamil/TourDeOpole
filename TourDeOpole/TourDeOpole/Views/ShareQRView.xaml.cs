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
    public partial class ShareQRView : ContentPage
    {
        private readonly ShareQRViewModel viewModel;
        public ShareQRView()
        {
            InitializeComponent();
            viewModel = new ShareQRViewModel();
            BindingContext = viewModel;
        }

        //Tutaj piszemy tylko UI, metody do viewModelu

    }
}