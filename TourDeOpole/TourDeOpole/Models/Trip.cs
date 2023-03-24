using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TourDeOpole.Models
{
    public class Trip
    {
        [PrimaryKey, AutoIncrement]
        public int TripID { get; set; }
        public string Name { get; set;}
        public string Description { get; set;}
        public double Time { get; set;}
        public bool IsCustom { get; set;}
    }
}
