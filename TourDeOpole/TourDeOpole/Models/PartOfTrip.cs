using System;
using System.Collections.Generic;
using System.Text;

namespace TourDeOpole.Models
{
    public class PartOfTrip
    {
        public int PartOfTripID { get; set; }
        public int TripID { get; set; }
        public Trip Trip { get; set; }
        public int LocationID { get; set; }
        public Place Location { get; set; }

    }
}
