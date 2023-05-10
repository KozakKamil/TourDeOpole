using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using Newtonsoft.Json;

namespace POK_JSON
{
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
                    InitializePlaces(); 
                    break;
                case "2":
                    InitializeCategories(); 
                    break;
                case "3":
                    InitializeTrips(); 
                    break;
                case "4":
                    InitializePartsOfTrips(); 
                    break;

                default:
                    Console.WriteLine("Niepoprawna wartość!");
                    break;
            }
        }

        private static void InitializePlaces()
        {
            var myPlace = new ObservableCollection<Place>()
            {
                new Place {
                    PlaceID = 1,
                    Image = "konik.png",
                    Name = "Pomnik Księcia Kazimierza I Opolskiego",
                    Description="W roku 1217, wraz z towarzyszącym mu hufcem, ruszył na V wyprawę krzyżową, dołączając do króla węgierskiego Andrzeja II. Do Opola z Ziemi Świętej przywiózł prawdopodobnie relikwie Świętego Krzyża. Symbolem tej wyprawy, jak twierdzą historycy, jest też krzyż obok piastowskiego orła w herbie Opola.\r\nAle to nie wszystko! W drodze powrotnej z wyprawy krzyżowej w 1218 r. Kazimierz I zatrzymał się na Bałkanach. Stamtąd przywiózł sobie do Opola żonę, piękną Bułgarkę Violę. Ich ślub odbył się prawdopodobnie w 1220 r. Kazimierz miał wtedy 40 lat, a Viola 15. Taka różnica wieku w dawnych czasach nie robiła jednak na nikim wrażenia.\r\nTo on lokował miasto w 1217 r., a w kolejnych latach uczynił siedzibą władz, administracji i hierarchów kościelnych. Za jego rządów zdecydowano o budowie nieistniejącego już warownego zamku na Ostrówku, a miasto obrastało w mury.\r\nZmarł w 1230 r. Jego pomnik odsłonięto w Opolu w maju 2018 r., w ramach hucznych obchodów 800-lecia miasta. Stanął w centrum, tuż przy opolskim Ratuszu, niemal na wprost kościoła oo. Franciszkanów, gdzie pochowani zostali książęta piastowscy, opodal Katedry Opolskiej. Wykonana z brązu rzeźba autorstwa opolskiego artysty Wita Pichurskiego waży blisko 2 tony. Tuż obok niej zakopano kapsułę czasu z życzeniami i przesłaniem dla przyszłych pokoleń.",
                    PostalCode = "45-022",
                    City = "Opole",
                    Street="Rynek",
                    Number="1",
                    Latitude=50.668380372196154,
                    Longitude=17.922453497085737,
                    IsCustom=false
                },
                new Place {
                    PlaceID = 2,
                    Image = "starsi_panowie.png",
                    Name = "Starsi panowie",
                    Description="To oni uznali, że „Piosenka jest dobra na wszystko”. I przekonali do tego Polaków. Spod ich pióra wyszły setki mądrych, dowcipnych, pięknych utworów, w których słowo i myśl są wielką wartością. Wśród nich są np. „Herbatka”, „Wesołe jest życie staruszka” czy „Addio pomidory!”. Wiele z nich było wykonywanych i nagradzanych podczas kolejnych Krajowych Festiwali Piosenki Polskiej w Opolu.\r\nJeremi Przybora (ur. 12 grudnia 1915 r., zm. 4 marca 2004 r.) był poetą, pisarzem, autorem książek i wielu piosenek, a także spikerem radiowym. Jerzy Wasowski (ur. 31 maja 1913, zm. 29 września 1984 r.) – kompozytorem i reżyserem, a także spikerem w radio. Od roku 1958 do 1966 w telewizji nadawany był stworzony przez nich Kabaret Starszych Panów, jedna z najpopularniejszych telewizyjnych audycji w Polsce. Gdy emitowano kolejne jej odcinki, ulice pustoszały.\r\nPomnik obydwu artystów wykonał z brązu opolski rzeźbiarz, prof. Marian Molenda. Został on odsłonięty w 2010 roku. Rzeźbiarz połączył poetę i kompozytora ławeczką, która z jednej strony ma postać klawiszy pianina, a z drugiej – kartek z zapisem słów. Tuż obok nich na Wzgórzu Uniwersyteckim stanęły pomniki innych wielkich, nieżyjących już, związanych z Opolem ludzi kultury, sztuki i polityki: Agnieszki Osieckiej, Wojciecha Młynarskiego, Marka Grechuty, Czesława Niemena, Jonasza Kofty, Jerzego Grotowskiego czy Edmunda Osmańczyka.",
                    PostalCode = "45-020",
                    City = "Opole",
                    Street="Plac Kopernika",
                    Number=String.Empty,
                    Latitude=50.66971701779546,
                    Longitude=17.92621906463774,
                    IsCustom=false },
                new Place {
                    PlaceID = 3, 
                    Image = "opolska-ceres.jpeg", 
                    Name = "Fontanna - Opolska Ceres", 
                    Description="Jedna z największych i najpiękniejszych opolskich fontann. Znajduje się na Placu Ignacego Daszyńskiego, tuż obok opolskiego sądu i Biblioteki Publicznej, niedaleko opolskiego Dworca Głównego PKP i głównego deptaka w mieście - ul. Krakowskiej. Dawniej, w przedwojennym niemieckim Oppeln, nosił on nazwę Frierdichsplatz. W granice miasta został włączony dopiero na początku XIX wieku. Wcześniej były tu podmiejskie pola i ogrody.\r\n\r\nPlac został zaaranżowany w latach 1904 – 1907, a fontannę ukończono w 1907 r. Jest to secesyjna rzeźba, zaprojektowana przez berlińskiego rzeźbiarza Edmunda Gomansky’ego, wykonana z piaskowca. Na jej szczycie znajduje się bogini urodzaju Ceres, która pierwotnie miała być Minerwą - rzymską boginią sztuki i rzemiosła. Ceres trzyma na rękach swoją córkę Prozerpinę, a u jej stóp umieszczono postaci nawiązujące do głównych branż opolskiego przemysłu.\r\n\r\nSą tu dwie kobiety ze snopkami zboża i owocami, symbolizujące rolnictwo; mężczyzna z sieciami, symbolizujący rybołówstwo oraz górnik z kilofem, nawiązujący do przemysłu cementowego, którym Opole stało w XIX i XX w. Bogate złoża margla wokół miasta sprawiły, że w pierwszej dekadzie XX w. było tu aż dziewięć cementowni.",
                    PostalCode = "45-910",
                    City = "Opole",
                    Street="Plac I. Daszyńskiego",
                    Number=String.Empty,
                    Latitude=50.66550548056264,
                    Longitude=17.92804664126436, 
                    IsCustom=false },
                new Place {
                    PlaceID = 4, 
                    Image = "pomnik-bojownikom.png", 
                    Name = "Pomnik Bojownikom o Polskość Śląska Opolskiego", 
                    Description="Popularna „baba na byku” jest jednym z najbardziej lubianych pomników stolicy polskiej piosenki. Ten 400-tonowy obelisk znajduje się w sercu miasta i jest częstym miejscem spotkań Opolan.\r\n\r\nOpolska Nike, symbol wolności, waleczności i polskości w rzeczywistości dosiada żubra (często mylonego także z turem). Monument mierzący aż 15 metrów stanął w Opolu w 1970 roku. Odsłonięto go 9 maja w 25 rocznicę zakończenia II wojny światowej i – jak podkreślano – zwycięstwa nad faszyzmem oraz powrotu Opola do macierzy. Z początku jego cokół zdobił napis \"Bojownikom o Wolność Śląska Opolskiego\". Dziś pomnik dedykowany jest \"Bojownikom o polskość Śląska Opolskiego\", powstańcom śląskim, którzy w trzech kolejnych powstaniach z lat 1919-1921 przelewali krew za odradzającą się wówczas Polskę. Autorem tego monumentalnego obelisku ze stali i betonu jest opolanin Jan Borowczyk. Na liście zamówionych do jego budowy materiałów znalazło się: pół tony cementu, 6 ton kruszywa bazaltowego, 1200 kilogramów prętów zbrojeniowych, 200 kilogramów gwoździ i 15 ton gipsu! Dzięki remontowi przeprowadzonemu w ostatnich latach, Nike odzyskała dawny blask. Oczyszczono ją, uzupełniono ubytki w betonie i pozbawiono powłoki z brązu, którą pomnik pokryto jakiś czas po odsłonięciu. Dzięki temu Nike odzyskała dawny kolor. Odświeżona i pięknie oświetlona, przykuwa dziś uwagę i jest częstym miejscem spotkań, pod którym umawiają się mieszkańcy Opola.",
                    PostalCode = "45-018",
                    City = "Opole",
                    Street="Pl. Wolności",
                    Number=String.Empty,
                    Latitude=50.66655360650358,
                    Longitude=17.92402541349268, 
                    IsCustom=false },
                new Place {
                    PlaceID = 5, 
                    Image = "pomnik-karola-musioła.png", 
                    Name = "Pomnik Karola Musioła", 
                    Description="Urodził się w 1905 r. w Bierdułtowach pod Rybnikiem. Ale to Opole, do którego trafił w 1952 roku, stało się jego miastem i prawdziwym domem. Przez 13 lat był tu przewodniczącym Miejskiej Rady Narodowej, a od dziesięcioleci jest dla Opolan symbolem dobrego gospodarza, który swego miasta doglądał chodząc po ulicach i rozmawiając z ludźmi. M.in. dlatego do dziś mówi się o nim najczęściej „Papa” Musioł, a mieszkańcy wciąż zgłaszają mu sprawy do załatwienia, wrzucając listy do teczki, którą pomnikowy „Papa” ma pod ręką.\r\n\r\nKarol Musioł był inicjatorem organizacji „Dni Opola”, a przede wszystkim znanego wszystkim Krajowego Festiwalu Piosenki Polskiej, który odbywa się w Opolu od 1963 roku. Za jego sprawą ruszyła też budowa opolskiego Amfiteatru Tysiąclecia, w którym odbywają się festiwale, czy Opolskiej Szkoły Muzycznej. Za swoją aktywność wielokrotnie honorowany był odznaczeniami państwowymi. A zupełnie niedawno został wybrany przez mieszkańców miasta Opolaninem 800-lecia.\r\n\r\nZmarł 21 marca 1983 r. Pochowany został na opolskim cmentarzu na półwsi. Jego pomnik autorstwa opolskiego artysty Wita Pichurskiego odsłonięty został w 2008 r. Stanął on w centrum miasta, tuż obok malowniczego Kanału Młynówka, Klubu Towarzystwa Przyjaciół Opola znanego dziś jako „Musiołówka”, naprzeciwko kościoła oo. Franciszkanów. Opodal znajduje się budynek dawnej Rejencji Opolskiej, w której dziś mieści się urząd wojewódzki, a nad tym budynkiem góruje słynna Wieża Piastowska.",
                    PostalCode = "45-020",
                    City = "Opole",
                    Street="Zamkowa",
                    Number="2",
                    Latitude=53.1980172,
                    Longitude=18.3698428, 
                    IsCustom=false },
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
}
