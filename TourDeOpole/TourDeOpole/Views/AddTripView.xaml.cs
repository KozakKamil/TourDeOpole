using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourDeOpole.Models;
using TourDeOpole.Services;
using TourDeOpole.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TourDeOpole.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddTripView : ContentPage
    {
        private readonly AddTripViewModel viewModel;
        public AddTripView()
        {
            InitializeComponent();
            viewModel = new AddTripViewModel();
            BindingContext = viewModel;
        }

        private int Count = 0;

        private async void OnButtonClickedRemove(object sender, EventArgs e)
        {
            try
            {
                AddTripViewLayout.Children.RemoveAt(Count - 1);
                Count--;
            }
            catch (IndexOutOfRangeException ex)
            {

                await DisplayAlert("nazwa", "wiadomosc", "ok");
                throw new IndexOutOfRangeException("brak elementow do usuniecia", ex);
            }
        }

        private async void OnButtonClickedAdd(object sender, EventArgs e)
        {
            var dynamicPicker = new Picker()
            {
                Margin = new Thickness(5, 5, 0, 0),
            };

            AddTripViewLayout.Children.Add(new Frame()
            {
                Margin = new Thickness(0, 10, 0, 10),
                CornerRadius = 10,
                Padding = 0,
                BorderColor = Color.LightGray,
                Content = dynamicPicker
            });
            Count++;
            await DisplayAlert("Sukces!", "Dodano nowa trase", "ok");

        }

        //Tutaj piszemy tylko UI, metody do viewModelu
    }
}