using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TourDeOpole.Models
{
    public class Place
    {
        [PrimaryKey, AutoIncrement]
        public int PlaceID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public bool IsCustom { get; set; }
    }
}
