using DataLayer.Data;

namespace DataLayer.Backend
{
    public class Admin
    {
        private readonly Database _database;

        public Admin(Database database)
        {
            this._database = database;
        }

        public async Task CreateDatabase()
        {
            await _database.CreateDatabaseIfNotExists();
        }

        public async Task RecreateAndSeedTestDatabase()
        {
            await _database.RecreateDatabase();
            await _database.SeedTestDataBase();
        }

        public async Task createDatabaseIfNotExists()
        {
            await _database.CreateAndSeedIfDatabaseDontExists();
        }


    }
}
