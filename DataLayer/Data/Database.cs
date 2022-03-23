using EventiaWebapp.Models;

namespace DataLayer.Data
{
    public class Database
    {
        private readonly EventiaDbContext _context;

        public Database(EventiaDbContext context)
        {
            this._context = context;
        }


        public async Task RecreateDatabase()
        {
            await _context.Database.EnsureDeletedAsync();
            await _context.Database.EnsureCreatedAsync();

        }

        public async Task CreateDatabaseIfNotExists()
        {
            await _context.Database.EnsureCreatedAsync();
        }

        public async Task CreateAndSeedIfDatabaseDontExists()
        {
            bool didCreateDatabase =
                await _context.Database.EnsureCreatedAsync();
            if (didCreateDatabase)
            {
                await SeedTestDataBase();
            }
        }




        public async Task SeedTestDataBase()
        {

            var organizers = new List<Organizer>
            {
                new () {Name= "World Tours.inc", Email = "info@worldtours.com", Phone_Number = "0220-12345"},
                new () {Name = "Experience", Email = "info@experience.com", Phone_Number = "0400-12345"},
                new () {Name = "Axelssons & c/o", Email = "info@axelsson.com", Phone_Number = "088-12345"}

            };

            await _context.AddRangeAsync(organizers);


            var events = new List<Event>
            {
                new()
                {
                    Titel = "Ghost",
                    Organizer = organizers[0],
                    Description =
                        "Ghost klassas idag som ett av världens mest älskade metalband!" +
                        " De är hyllade, prisbelönta och har alltid utmanat och skapat rubriker." +
                        " Nyckeln till den enorma uppmärksamhet de har varit föremål för senaste" +
                        " åren ligger nog i summan av chockeffekten, det starka visuella uttrycket" +
                        " och den fantastiska och nyskapande musiken.",
                    Place = "Avicii Arena",
                    Address = "Globentorget 2, 12177 JOHANNESHOV",
                    Date = new DateTime(2022, 4, 29, 19, 00, 00),
                    Spots_Available = 10000
                },
                new()
                {
                    Titel = "TOOL",
                    Organizer = organizers[0],
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
                    Spots_Available = 10000
                },

                new()
                {
                    Titel = "Frida Hyvönen",
                    Organizer = organizers[1],
                    Description =
                        "Med det senaste vida hyllade albumet ”Dream of Independence” i ryggen ger" +
                        " sig Frida Hyvönen ut på en omfattande vårturné som inleds 25 februari i Luleå." +
                        "Frida Hyvönen albumdebuterade 2005 med ”Until Death Comes”. " +
                        "Två ytterligare engelskspråkiga album följde, ”Silence is Wild” (2008) " +
                        "och ”To the Soul” (2012)",
                    Place = "Kungsbacka Teater",
                    Address = "Gymnasiegatan 42, 434 50 KUNGSBACKA",
                    Date = new DateTime(2022, 4, 2, 19, 00, 00),
                    Spots_Available = 780
                },
                new()
                {
                    Titel = "Humorkväll med Jonathan Unge & Ahmed Berhan",
                    Organizer = organizers[1],
                    Description =
                        "Nu blir det humor på hög nivå inne på salongen på Kungsbacka Teater." +
                        "Jonatan Unge är den anemiska kulturpojken från Djurgården som trots reumatism" +
                        " har så starka funny bones man kan ha. Att lyssna på Jonatan är som att få" +
                        " örtmassage i hjärnan. Du kan höra honom i podcasterna Lilla drevet," +
                        " Della Monde och Februaripodden.",
                    Place = "Kungsbacka Teater",
                    Address = "Gymnasiegatan 42, 434 50 KUNGSBACKA",
                    Date = new DateTime(2022, 9, 9, 19, 30, 00),
                    Spots_Available = 780
                },
                new()
                {
                    Titel = "Alla känner Ankan",
                    Organizer = organizers[2],
                    Description =
                        "Anders ”Ankan” Johansson utsågs 2020 till årets manliga komiker och samma år gjorde" +
                        " han stor succé i tv-program som ”Bäst i test” och ”På spåret på SVT”. Anders är för" +
                        " många känd som ena halvan i humorduon Anders & Måns som har spelat flera hyllade" +
                        " scenföreställningar tillsammans. Nu är han aktuell med sin nya enmansföreställning" +
                        " ”Alla känner Ankan – En humorshow av och med Anders Johansson.”",
                    Place = "Gävle Teater",
                    Address = "Teaterplan 1, 803 23 GÄVLE",
                    Date = new DateTime(2022, 10, 29, 19, 30, 00),
                    Spots_Available = 900
                },
                new()
                {
                    Titel = "En afton på Operan",
                    Organizer = organizers[2],
                    Description =
                        "Var med och hör framtidens operasångare i början av sin karriär," +
                        " på väg ut i den internationella operavärlden. Tillsammans med dirigent" +
                        " och orkester bjuder de in till en afton fylld med dramatik och känslor." +
                        " Kom och njut, skratta gott och gråt en skvätt när de främsta operascenerna" +
                        " ageras ut i Gävle Teaters vackra salong.",
                    Place = "Gävle Teater",
                    Address = "Teaterplan 1, 803 23 GÄVLE",
                    Date = new DateTime(2022, 6, 11, 16, 00, 00),
                    Spots_Available = 900
                }
            };

            await _context.AddRangeAsync(events);

            //EventLists
            var johansEvents = new List<Event> { events[0], events[2] };
            var piasEvents = new List<Event> { events[3], events[0] };
            var annaMartasEvents = new List<Event> { events[0], events[5] };


            var attendees = new List<Attendee>
            {
                new()
                {
                    Name = "Johan", Email = "Johan@mail.com",
                    Phone_Number = "076-1234567", Events = johansEvents,
                },
                new ()
                {
                    Name = "Pia", Email = "pia@mail.com",
                    Phone_Number = "070-1234567", Events = piasEvents,
                },
                new ()
                {
                    Name = "AnnaMärta", Email = "AnnaMärta@mail.com",
                    Phone_Number = "073-1234567", Events = annaMartasEvents
                }
            };

            await _context.AddRangeAsync(attendees);
            await _context.SaveChangesAsync();

        }



    }
}
