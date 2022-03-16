using EventiaWebapp.Models;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Data
{
    public class Database
    {
        private readonly DbContextOptions _options;

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


            var organizers = new List<Organizer>
            {
                new () {Name= "World Tours.inc", Email = "info@worldtours.com", Phone_Number = "0220-12345"},
                new () {Name = "Experience", Email = "info@experience.com", Phone_Number = "0400-12345"},
                new () {Name = "Axelssons & c/o", Email = "info@axelsson.com", Phone_Number = "088-12345"}

            };

            ctx.AddRange(organizers);


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
                    Address = "Globentorget 2, 12177 JOHANNESHOV",
                    Date = new DateTime(2022, 4, 29, 19, 00, 00),
                    Spots_Available = 2000
                },
                new()
                {
                    Titel = "TOOL",
                    Organizer_Id = 1,
                    Description =
                        "TOOL TILLBAKA TILL SVERIGE FÖR FÖRSTA GÅNGEN PÅ FEMTON ÅR!" +
                        "Femton år har gått sedan bandet senast spelade på svensk mark" +
                        " och nästa år kommer de äntligen tillbaka!" +
                        "TOOL debuterade 1993 och efter fyra släppta album tog de en längre paus." +
                        " 2019 återvände de starkare än någonsin med sitt femte och senaste" +
                        " album ”Fear Inoculum”. Den 26 april 2022 gör de en efterlängtad" +
                        " konsert på Avicii Arena i Stockholm!",
                    Place = "Avicii Arena",
                    Address = "Globentorget 2, 12177 JOHANNESHOV",
                    Date = new DateTime(2022, 4, 26, 20, 45, 00),
                    Spots_Available = 2000
                },

                new()
                {
                    Titel = "Frida Hyvönen",
                    Organizer_Id = 2,
                    Description =
                        "Med det senaste vida hyllade albumet ”Dream of Independence” i ryggen ger" +
                        " sig Frida Hyvönen ut på en omfattande vårturné som inleds 25 februari i Luleå." +
                        "Frida Hyvönen albumdebuterade 2005 med ”Until Death Comes”. " +
                        "Två ytterligare engelskspråkiga album följde, ”Silence is Wild” (2008) " +
                        "och ”To the Soul” (2012), 07)",
                    Place = "Kungsbacka Teater",
                    Address = "Gymnasiegatan 42, 434 50 KUNGSBACKA",
                    Date = new DateTime(2022, 4, 2, 19, 00, 00),
                    Spots_Available = 2000
                },
                new()
                {
                    Titel = "Humorkväll med Jonathan Unge & Ahmed Berhan",
                    Organizer_Id = 2,
                    Description =
                        "Nu blir det humor på hög nivå inne på salongen på Kungsbacka Teater." +
                        "Jonatan Unge är den anemiska kulturpojken från Djurgården som trots reumatism" +
                        " har så starka funny bones man kan ha. Att lyssna på Jonatan är som att få" +
                        " örtmassage i hjärnan. Du kan höra honom i podcasterna Lilla drevet," +
                        " Della Monde och Februaripodden.",
                    Place = "Kungsbacka Teater",
                    Address = "Gymnasiegatan 42, 434 50 KUNGSBACKA",
                    Date = new DateTime(2022, 9, 9, 19, 30, 00),
                    Spots_Available = 2000
                },
                new()
                {
                    Titel = "Alla känner Ankan",
                    Organizer_Id = 3,
                    Description =
                        "Med det senaste vida hyllade albumet ”Dream of Independence” i ryggen ger" +
                        " sig Frida Hyvönen ut på en omfattande vårturné som inleds 25 februari i Luleå." +
                        "Frida Hyvönen albumdebuterade 2005 med ”Until Death Comes”. " +
                        "Två ytterligare engelskspråkiga album följde, ”Silence is Wild” (2008) " +
                        "och ”To the Soul” (2012), 07)",
                    Place = "Gävle Teater",
                    Address = "Teaterplan 1, 803 23 GÄVLE",
                    Date = new DateTime(2022, 10, 29, 19, 30, 00),
                    Spots_Available = 2000
                },
                new()
                {
                    Titel = "En afton på Operan",
                    Organizer_Id = 3,
                    Description =
                        "Var med och hör framtidens operasångare i början av sin karriär," +
                        " på väg ut i den internationella operavärlden. Tillsammans med dirigent" +
                        " och orkester bjuder de in till en afton fylld med dramatik och känslor." +
                        " Kom och njut, skratta gott och gråt en skvätt när de främsta operascenerna" +
                        " ageras ut i Gävle Teaters vackra salong.",
                    Place = "Gävle Teater",
                    Address = "Teaterplan 1, 803 23 GÄVLE",
                    Date = new DateTime(2022, 6, 11, 16, 00, 00),
                    Spots_Available = 2000
                }
    };

            ctx.AddRange(events);

            var attendees = new List<Attendee>
            {
                new()
                {
                    Name = "Johan", Email = "Johan@mail.com",
                    Phone_Number = "076-1234567"
                },
                new()
                {
                    Name = "Pia", Email = "pia@mail.com",
                    Phone_Number = "070-1234567"
                },
                new()
                {
                    Name = "AnnaMärta", Email = "AnnaMärta@mail.com",
                    Phone_Number = "073-1234567"
                }
            };

            ctx.AddRange(attendees);
            ctx.SaveChanges();

        }



    }
}
