using EventiaWebapp.Models;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Data
{
    public class Database
    {
        private DbContextOptions _options;

        public Database(DbContextOptions options)
        {
            this._options = options;
        }


        public void RecreateDatabase()
        {
            using var ctx = new EventiaDbContext(_options);

            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();

        }

        public void SeedTestDataBase()
        {
            using var ctx = new EventiaDbContext(_options);

            var events = new List<Event>
            {
                new()
                {
                    Titel = "Ghost",
                    Organizer_Id = 1,
                    Description =
                        "Ghost klassas idag som ett av världens mest älskade metalband!" +
                        " De är hyllade, prisbelönta och har alltid utmanat och skapat rubriker." +
                        " Nyckeln till den enorma uppmärksamhet de har varit föremål för senaste" +
                        " åren ligger nog i summan av chockeffekten, det starka visuella uttrycket" +
                        " och den fantastiska och nyskapande musiken.",
                    Place = "Avicii Arena",
                    Address = "121 77 Johanneshov",
                    Date = new DateTime(2022, 4, 29, 19, 00, 00),
                    Spots_Available = 2000
                }
            };

            ctx.AddRange(events);

        }



    }
}
