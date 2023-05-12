using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace TourDeOpole.Models
{
    public class Place
    {
        [PrimaryKey, AutoIncrement]
        public int PlaceID { get; set; }
        public string Image { get; set; }   
        public string Name { get; set; }
        public string Description { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public bool IsCustom { get; set; }
        public bool IsFavourite { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string PostalCode { get; set; }
        public string ImageSource => IsFavourite? "favoriteCheck.png" : "favorite.png";


        [Ignore]
        public static ObservableCollection<Place> ListOfPlaces { get; set; }
    }
}
