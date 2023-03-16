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
    public partial class MainView : ContentPage
    {
        MainViewModel _viewModel;
        public MainView()
        {
            InitializeComponent();
            _viewModel = new MainViewModel();
            BindingContext = _viewModel;
            Appearing += (sender, e) =>
            {
                _viewModel.getLocation();
            };
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            collectionView.ItemsSource = await App.Database.GetItemsAsync();
        }
        async void OnButtonClickedDatabase(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(nameEntry.Text))
            {
                await App.Database.SaveDatebaseAsync(new DatabaseService { NameTest = nameEntry.Text });
            }
            nameEntry.Text = string.Empty;

            collectionView.ItemsSource = await App.Database.GetItemsAsync();
        }
    }
}