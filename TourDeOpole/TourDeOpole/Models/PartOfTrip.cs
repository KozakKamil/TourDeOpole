using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TourDeOpole.Models
{
    public class PartOfTrip
    {
        [PrimaryKey,AutoIncrement]
        public int PartOfTripID { get; set; }

        public int TripID { get; set; }
        [Ignore]
        public Trip Trip { get; set; }

        public int LocationID { get; set; }
        [Ignore]
        public Place Location { get; set; }

    }
}
