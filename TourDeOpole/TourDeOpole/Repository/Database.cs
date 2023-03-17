using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using TourDeOpole.Services;

namespace TourDeOpole.Repository
{
    public class Database
    {
        private readonly SQLiteAsyncConnection _connection;

        public Database(string dbPath)
        {
            _connection = new SQLiteAsyncConnection(dbPath);
            _connection.CreateTableAsync<DatabaseService>().Wait();
        }

        public Task<List<DatabaseService>> GetItemsAsync()
        {
            return _connection.Table<DatabaseService>().ToListAsync();
        }

        public Task<int> SaveDatebaseAsync(DatabaseService service)
        {
            return _connection.InsertAsync(service);
        }
    }
}
