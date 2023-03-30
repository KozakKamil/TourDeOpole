using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using Newtonsoft.Json;

public class Place
{
    public int PlaceID { get; set; }
    public string Image { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public bool IsCustom { get; set; }
}

public class Category
{
    public int CategoryID { get; set; }
    public string Name { get; set; }
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
    public string Image { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Time { get; set; }
    public bool IsCustom { get; set; }
}



public class Program
{
    public ObservableCollection<Place> myPlace { get; set; }
    private ObservableCollection<Category> myCategory { get; set; }
    private ObservableCollection<PartOfTrip> myPartOfTrip { get; set; }
    private ObservableCollection<Trip> myTrip { get; set; }
    public static void Main(string[] args)
    {
        var program = new Program();
        var jsonPlaces = JsonConvert.SerializeObject(program.myPlace, Formatting.Indented);
        var jsonCategory = JsonConvert.SerializeObject(program.myCategory, Formatting.Indented);
        var jsonTrip = JsonConvert.SerializeObject(program.myTrip, Formatting.Indented);
        var jsonPartOfTrip = JsonConvert.SerializeObject(program.myPartOfTrip, Formatting.Indented);

        var desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

        var filePathPlaces = Path.Combine(desktopPath, "jsonPlace.json");
        var filePathCategory = Path.Combine(desktopPath, "jsonCategory.json");
        var filePathTrip = Path.Combine(desktopPath, "jsonTrip.json");
        var filePathPartOfTrip = Path.Combine(desktopPath, "jsonPartOfTrip.json");

        File.WriteAllText(filePathPlaces, jsonPlaces);
        File.WriteAllText(filePathCategory, jsonCategory);
        File.WriteAllText(filePathTrip, jsonTrip);
        File.WriteAllText(filePathPartOfTrip, jsonPartOfTrip);
    }


    public Program()
    {

        myPlace = new ObservableCollection<Place>()
            {
                new Place {PlaceID = 1, Image = "image_top_background.png", Name = "Name", Description="Placeholder",Latitude=53.1980172,Longitude=18.3698428, IsCustom=false },
                new Place {PlaceID = 2, Image = "image_top_background.png", Name = "Name", Description="Placeholder",Latitude=53.1980172,Longitude=18.3698428, IsCustom=false },
                new Place {PlaceID = 3, Image = "image_top_background.png", Name = "Name", Description="Placeholder",Latitude=53.1980172,Longitude=18.3698428, IsCustom=false },
                new Place {PlaceID = 4, Image = "image_top_background.png", Name = "Name", Description="Placeholder",Latitude=53.1980172,Longitude=18.3698428, IsCustom=false },
                new Place {PlaceID = 5, Image = "image_top_background.png", Name = "Name", Description="Placeholder",Latitude=53.1980172,Longitude=18.3698428, IsCustom=false },
                new Place {PlaceID = 6, Image = "image_top_background.png", Name = "Name", Description="Placeholder",Latitude=53.1980172,Longitude=18.3698428, IsCustom=false },
                new Place {PlaceID = 7, Image = "image_top_background.png", Name = "Name", Description="Placeholder",Latitude=53.1980172,Longitude=18.3698428, IsCustom=false },
                new Place {PlaceID = 8, Image = "image_top_background.png", Name = "Name", Description="Placeholder",Latitude=53.1980172,Longitude=18.3698428, IsCustom=false },
                new Place {PlaceID = 9, Image = "image_top_background.png", Name = "Name", Description="Placeholder",Latitude=53.1980172,Longitude=18.3698428, IsCustom=false },
                new Place {PlaceID = 10, Image = "image_top_background.png", Name = "Name", Description="Placeholder",Latitude=53.1980172,Longitude=18.3698428, IsCustom=false },
                new Place {PlaceID = 11, Image = "image_top_background.png", Name = "Name", Description="Placeholder",Latitude=53.1980172,Longitude=18.3698428, IsCustom=false },
                new Place {PlaceID = 12, Image = "image_top_background.png", Name = "Name", Description="Placeholder",Latitude=53.1980172,Longitude=18.3698428, IsCustom=false },
                new Place {PlaceID = 13, Image = "image_top_background.png", Name = "Name", Description="Placeholder",Latitude=53.1980172,Longitude=18.3698428, IsCustom=false },
                new Place {PlaceID = 14, Image = "image_top_background.png", Name = "Name", Description="Placeholder",Latitude=53.1980172,Longitude=18.3698428, IsCustom=false },
                new Place {PlaceID = 15, Image = "image_top_background.png", Name = "Name", Description="Placeholder",Latitude=53.1980172,Longitude=18.3698428, IsCustom=false },
            };

        myCategory = new ObservableCollection<Category>()
        {
            new Category{CategoryID = 1, Name = "Muzea"},
            new Category{CategoryID = 2, Name = "Restauracje"},
            new Category{CategoryID = 3, Name = "Sztuka"},
            new Category{CategoryID = 4, Name = "Parki"},
            new Category{CategoryID = 5, Name = "Atrakce"},
            new Category{CategoryID = 6, Name = "Pomniki"},
            new Category{CategoryID = 7, Name = "Budynki historyczne"},
            new Category{CategoryID = 8, Name = "Miejsca historyczne"},
        };
        myTrip = new ObservableCollection<Trip>()
        {
            new Trip { TripID = 1, Image="image_top_background.png", Name="Trip1", Time="1h30min", Description="Placeholder",IsCustom=false},
            new Trip { TripID = 2, Image="image_top_background.png", Name="Trip2", Time="1h30min", Description="Placeholder",IsCustom=false},
            new Trip { TripID = 3, Image="image_top_background.png", Name="Trip3", Time="1h30min", Description="Placeholder",IsCustom=false},
            new Trip { TripID = 4, Image="image_top_background.png", Name="Trip4", Time="1h30min", Description="Placeholder",IsCustom=false}
        };
        myPartOfTrip = new ObservableCollection<PartOfTrip>()
        {
            new PartOfTrip {PartOfTripID=1, LocationID=1,TripID=1},
            new PartOfTrip {PartOfTripID=2, LocationID=2,TripID=1},
            new PartOfTrip {PartOfTripID=3, LocationID=3,TripID=1},
            new PartOfTrip {PartOfTripID=4, LocationID=4,TripID=1},
            new PartOfTrip {PartOfTripID=5, LocationID=5,TripID=1},
            new PartOfTrip {PartOfTripID=6, LocationID=6,TripID=2},
            new PartOfTrip {PartOfTripID=7, LocationID=7,TripID=2},
            new PartOfTrip {PartOfTripID=8, LocationID=8,TripID=2},
            new PartOfTrip {PartOfTripID=9, LocationID=9,TripID=3},
            new PartOfTrip {PartOfTripID=10, LocationID=10,TripID=3},
            new PartOfTrip {PartOfTripID=11, LocationID=11,TripID=3},
        };
    }
}
