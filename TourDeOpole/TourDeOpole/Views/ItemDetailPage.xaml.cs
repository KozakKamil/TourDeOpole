using System.ComponentModel;
using TourDeOpole.ViewModels;
using Xamarin.Forms;

namespace TourDeOpole.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}