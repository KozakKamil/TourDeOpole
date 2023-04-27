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
            viewModel= new AddTripViewModel();
            BindingContext= viewModel;
        }

        private int Count = 0;

        private async void OnButtonClickedRemove(object sender, EventArgs e)
        {
           try {
                AddTripViewLayout.Children.RemoveAt(Count - 1);
                Count--;
            } catch (IndexOutOfRangeException ex)
           {

                await DisplayAlert("nazwa", "wiadomosc", "ok");
                throw new IndexOutOfRangeException("brak elementow do usuniecia", ex);
           }
        }
                
            private async void OnButtonClickedAdd(object sender, EventArgs e)
        {
            Frame frame = new Frame();
            frame.Margin =new Thickness (0, 20, 0, 30);
            frame.CornerRadius = 10;
            frame.Padding = 0;
            frame.BorderColor = Color.LightGray;
            
            Picker dynamicPicker = new Picker();
            dynamicPicker.Margin = new Thickness(15, 15, 0, 0);
            await DisplayAlert("Sukces!", "Dodano nowa trase", "ok");
            frame.Content = dynamicPicker;
            AddTripViewLayout.Children.Add(frame);
            Count++;
        
        }

        //Tutaj piszemy tylko UI, metody do viewModelu
    }
}