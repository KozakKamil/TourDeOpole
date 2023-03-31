using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SQLite;
using TourDeOpole.Models;
using TourDeOpole.Services;

namespace TourDeOpole.Repository
{
    public class Database
    {
        private readonly SQLiteAsyncConnection _connection;

        public Database(string dbPath)
        {
            _connection = new SQLiteAsyncConnection(dbPath);
            //Odkomentuj jeśli chcesz wyczyścić bazę danych
            //_connection.DropTableAsync<Place>().Wait();
            //_connection.DropTableAsync<Category>().Wait();
            //_connection.DropTableAsync<Trip>().Wait();
            _connection.CreateTablesAsync<Place,Category,HasCategory,Trip,PartOfTrip>().Wait();
        }

        #region Place
        public Task<List<Place>> GetPlaceAsync()
        {
            return _connection.Table<Place>().ToListAsync();
        }

        public Task<int> SavePlaceAsync(Place place)
        {
            return _connection.InsertAsync(place);
        }

        public Task DeletePlace(Place place)
        {
            return _connection.DeleteAsync(place);
        }
        #endregion        
        
        #region Category
        public Task<List<Category>> GetCategoryeAsync()
        {
            return _connection.Table<Category>().ToListAsync();
        }

        public Task<int> SaveCategoryAsync(Category category)
        {
            return _connection.InsertAsync(category);
        }

        public Task DeleteCategory(Category category)
        {
            return _connection.DeleteAsync(category);
        }
        #endregion

        #region HasCategory
        public Task<List<HasCategory>> GetHasCategoryAsync()
        {
            return _connection.Table<HasCategory>().ToListAsync();
        }

        public Task<int> SaveHasCategoryAsync(HasCategory hasCategory)
        {
            return _connection.InsertAsync(hasCategory);
        }

        public Task DeleteHasCategory(HasCategory hascategory)
        {
            return _connection.DeleteAsync(hascategory);
        }
        #endregion

        #region Trip
        public Task<List<Trip>> GetTripAsync()
        {
            return _connection.Table<Trip>().ToListAsync();
        }

        public Task<int> SaveTripAsync(Trip trip)
        {
            return _connection.InsertAsync(trip);
        }

        public Task DeleteTrip(Trip trip)
        {
            return _connection.DeleteAsync(trip);
        }
        #endregion

        #region PartOfTrip
        public Task<List<PartOfTrip>> GetTripPartOfAsync()
        {
            return _connection.Table<PartOfTrip>().ToListAsync();
        }

        public Task<int> SaveTripAsync(PartOfTrip part)
        {
            return _connection.InsertAsync(part);
        }

        public Task DeleteTrip(PartOfTrip part)
        {
            return _connection.DeleteAsync(part);
        }
        #endregion

    }
}
