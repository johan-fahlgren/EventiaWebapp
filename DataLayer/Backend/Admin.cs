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
            await _database.AdminSeed();
        }

        public async Task createDatabaseIfNotExists()
        {
            await _database.CreateAndSeedIfDatabaseDontExists();
        }

        public async Task AdminSeed()
        {
            await _database.AdminSeed();
        }


    }
}
