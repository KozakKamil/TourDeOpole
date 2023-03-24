using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace TourDeOpole.ViewModels
{
    public class ShareQRViewModel : BaseViewModel
    {
        public ShareQRViewModel()
        {
            LoadText("trase");
            GenerateQR("M&M");
        }

        public string QRValue { get; set; }

        public string Text { get; set; }

        public void GenerateQR(string value)
        {
            QRValue = value;
        }

        public void LoadText(string name)
        {
            Text = $"Udostępnij swoją {name} znajomym! ";
            OnPropertyChanged("Text");
        }
    }
}
