using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TourDeOpole.Services;
using Xamarin.Forms;

namespace TourDeOpole.ViewModels
{
    public class PlaceDetailsViewModel : BaseViewModel
    {
        public Command GoToShareQRCommand { get; set; }
        public PlaceDetailsViewModel()
        {
            GoToShareQRCommand = new Command(async () => { await GoToShareQR(); });
        }

        private async Task GoToShareQR()
        {
            await NavigationService.GoToShareQR();
        }
    }
}
