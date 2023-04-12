using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using Newtonsoft.Json;

public class Place
{
    public int PlaceID { get; set; }
    public string? Image { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
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



public class Program
{
    public static ObservableCollection<Place>? myPlace { get; set; }
    private static ObservableCollection<Category>? myCategory { get; set; }
    private static ObservableCollection<PartOfTrip>? myPartOfTrip { get; set; }

    private static readonly string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

    public static void Main(string[] args)
    {
        Console.WriteLine("What JSON file do you want to generate?");
        Console.WriteLine("1. Generate places");
        Console.WriteLine("2. Generate categories");
        Console.WriteLine("3. Generate trips");
        Console.WriteLine("4. Generate categories");
        var result = Console.ReadLine();
        switch (result)
        {
            case "1":
                InitializePlaces(); break;
                case "2":
                    InitializeCategories(); break;
                case "3":
                    InitializeTrips(); break;
                case "4":
                    InitializePartsOfTrips(); break;

            default:
                Console.WriteLine("Niepoprawna wartość!");
                break;
        }
    }

    private static void InitializePlaces()
    {
        var myPlace = new ObservableCollection<Place>()
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
        var jsonPlaces = JsonConvert.SerializeObject(myPlace, Formatting.Indented);
        var filePathPlaces = Path.Combine(desktopPath, "jsonPlace.json");
        File.WriteAllText(filePathPlaces, jsonPlaces);
    }

    private static void InitializeCategories()
    {
        var myCategory = new ObservableCollection<Category>()
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

        var jsonCategory = JsonConvert.SerializeObject(myCategory, Formatting.Indented);
        var filePathCategory = Path.Combine(desktopPath, "jsonCategory.json");
        File.WriteAllText(filePathCategory, jsonCategory);



    }

    private static void InitializeTrips()
    {
        var myTrip = new ObservableCollection<Trip>()
        {
            new Trip { TripID = 1, Image="image_top_background.png", Name="Trip1", Time="1h30min", Description="Placeholder",IsCustom=false},
            new Trip { TripID = 2, Image="image_top_background.png", Name="Trip2", Time="1h30min", Description="Placeholder",IsCustom=false},
            new Trip { TripID = 3, Image="image_top_background.png", Name="Trip3", Time="1h30min", Description="Placeholder",IsCustom=false},
            new Trip { TripID = 4, Image="image_top_background.png", Name="Trip4", Time="1h30min", Description="Placeholder",IsCustom=false}
        };
        var jsonTrip = JsonConvert.SerializeObject(myTrip, Formatting.Indented);
        var filePathTrip = Path.Combine(desktopPath, "jsonTrip.json");
        File.WriteAllText(filePathTrip, jsonTrip);



    }

    private static void InitializePartsOfTrips()
    {
        var myPartOfTrip = new ObservableCollection<PartOfTrip>()
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
        var jsonPartOfTrip = JsonConvert.SerializeObject(myPartOfTrip, Formatting.Indented);
        var filePathPartOfTrip = Path.Combine(desktopPath, "jsonPartOfTrip.json");
        File.WriteAllText(filePathPartOfTrip, jsonPartOfTrip);
    }
}
