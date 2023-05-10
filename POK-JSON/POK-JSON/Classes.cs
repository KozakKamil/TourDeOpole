namespace POK_JSON
{
    public class Place
    {
        public int PlaceID { get; set; }
        public string? Image { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string PostalCode { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public bool IsCustom { get; set; }
    }

    public class Category
    {
        public int CategoryID { get; set; }
        public string? Name { get; set; }
    }

    public class PartOfTrip
    {
        public int PartOfTripID { get; set; }
        public int TripID { get; set; }
        public int LocationID { get; set; }
    }

    public class Trip
    {
        public int TripID { get; set; }
        public string? Image { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Time { get; set; }
        public bool IsCustom { get; set; }
    }


}
