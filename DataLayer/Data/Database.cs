using DataLayer.Model;
using Microsoft.AspNetCore.Identity;

namespace DataLayer.Data
{
    public class Database
    {
        private readonly EventiaDbContext _context;
        private readonly UserManager<EventiaUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public Database(EventiaDbContext context, UserManager<EventiaUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this._context = context;
            this._userManager = userManager;
            this._roleManager = roleManager;
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

            var eventiaOrganizers = new List<EventiaUser>
            {
                new ()
                {
                    UserName = "WorldTours",
                    Email = "info@worldtours.com",
                    PhoneNumber = "0220-12345"
                },
                new ()
                {
                    UserName = "Experience",
                    Email = "info@experience.com",
                    PhoneNumber = "0400-12345"
                },
                new ()
                {
                    UserName = "Axelssons",
                    Email = "info@axelsson.com",
                    PhoneNumber = "088-12345",
                }

            };

            foreach (var organizer in eventiaOrganizers)
            {
                await _userManager.CreateAsync(organizer, password: "pAssw0rd!");
            };


            var events = new List<Event>
            {
                new()
                {
                    Titel = "Ghost",
                    organizer = eventiaOrganizers[0],
                    Description =
                        "Ghost klassas idag som ett av världens mest älskade metalband!" +
                        " De är hyllade, prisbelönta och har alltid utmanat och skapat rubriker." +
                        " Nyckeln till den enorma uppmärksamhet de har varit föremål för senaste" +
                        " åren ligger nog i summan av chockeffekten, det starka visuella uttrycket" +
                        " och den fantastiska och nyskapande musiken.",
                    Place = "Avicii Arena",
                    Address = "Globentorget 2, 12177 JOHANNESHOV",
                    Date = new DateTime(2022, 4, 29, 19, 00, 00),
                    Spots_Available = 10000,
                    EventImg = "/img/event_img/ghost.png"
                },
                new ()
                {
                    Titel = "TOOL",
                    organizer = eventiaOrganizers[0],
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
                    Spots_Available = 10000,
                    EventImg = "/img/event_img/tool.jpg"
                },

                new ()
                {
                    Titel = "Frida Hyvönen",
                    organizer = eventiaOrganizers[1],
                    Description =
                        "Med det senaste vida hyllade albumet ”Dream of Independence” i ryggen ger" +
                        " sig Frida Hyvönen ut på en omfattande vårturné som inleds 25 februari i Luleå." +
                        "Frida Hyvönen albumdebuterade 2005 med ”Until Death Comes”. " +
                        "Två ytterligare engelskspråkiga album följde, ”Silence is Wild” (2008) " +
                        "och ”To the Soul” (2012)",
                    Place = "Kungsbacka Teater",
                    Address = "Gymnasiegatan 42, 434 50 KUNGSBACKA",
                    Date = new DateTime(2022, 4, 2, 19, 00, 00),
                    Spots_Available = 780,
                    EventImg = "/img/event_img/frida_h.jpg"
                },
                new()
                {
                    Titel = "Humorkväll med Jonathan Unge & Ahmed Berhan",
                    organizer = eventiaOrganizers[1],
                    Description =
                        "Nu blir det humor på hög nivå inne på salongen på Kungsbacka Teater." +
                        "Jonatan Unge är den anemiska kulturpojken från Djurgården som trots reumatism" +
                        " har så starka funny bones man kan ha. Att lyssna på Jonatan är som att få" +
                        " örtmassage i hjärnan. Du kan höra honom i podcasterna Lilla drevet," +
                        " Della Monde och Februaripodden.",
                    Place = "Kungsbacka Teater",
                    Address = "Gymnasiegatan 42, 434 50 KUNGSBACKA",
                    Date = new DateTime(2022, 9, 9, 19, 30, 00),
                    Spots_Available = 780,
                    EventImg = "/img/event_img/joanthan_unge.jpg"
                },
                new()
                {
                    Titel = "Alla känner Ankan",
                    organizer = eventiaOrganizers[2],
                    Description =
                        "Anders ”Ankan” Johansson utsågs 2020 till årets manliga komiker och samma år gjorde" +
                        " han stor succé i tv-program som ”Bäst i test” och ”På spåret på SVT”. Anders är för" +
                        " många känd som ena halvan i humorduon Anders & Måns som har spelat flera hyllade" +
                        " scenföreställningar tillsammans. Nu är han aktuell med sin nya enmansföreställning" +
                        " ”Alla känner Ankan – En humorshow av och med Anders Johansson.”",
                    Place = "Gävle Teater",
                    Address = "Teaterplan 1, 803 23 GÄVLE",
                    Date = new DateTime(2022, 10, 29, 19, 30, 00),
                    Spots_Available = 900,
                    EventImg = "/img/event_img/ankan.jpg"
                },
                new()
                {
                    Titel = "En afton på Operan",
                    organizer = eventiaOrganizers[2],
                    Description =
                        "Var med och hör framtidens operasångare i början av sin karriär," +
                        " på väg ut i den internationella operavärlden. Tillsammans med dirigent" +
                        " och orkester bjuder de in till en afton fylld med dramatik och känslor." +
                        " Kom och njut, skratta gott och gråt en skvätt när de främsta operascenerna" +
                        " ageras ut i Gävle Teaters vackra salong.",
                    Place = "Gävle Teater",
                    Address = "Teaterplan 1, 803 23 GÄVLE",
                    Date = new DateTime(2022, 6, 11, 16, 00, 00),
                    Spots_Available = 900,
                    EventImg = "/img/event_img/operan.jpeg"
                }
            };

            await _context.AddRangeAsync(events);
            await _context.SaveChangesAsync();

            //EventLists
            var johansEvents = new List<Event> { events[0], events[2] };
            var piasEvents = new List<Event> { events[3], events[0] };
            var annaMartasEvents = new List<Event> { events[0], events[5] };


            var eventiaUser = new List<EventiaUser>
            {
                new()
                {
                    FirstName = "Johan",
                    LastName = "Fahlgren",
                    UserName = "Felhan",
                    Email = "johanfahlgren@gmail.com",
                    JoinedEvent = johansEvents,
                },
                new ()
                {
                    FirstName = "Pia",
                    LastName = "Hagman",
                    UserName = "Pim",
                    Email = "piaHagman@gmail.com",
                    JoinedEvent = piasEvents,
                },
                new ()
                {
                    FirstName = "AnnaMärta",
                    LastName = "Hjalmarson",
                    UserName = "Morten",
                    Email = "annamartahjalmarson@gmail.com",
                    JoinedEvent = annaMartasEvents
                }
            };


            foreach (var user in eventiaUser)
            {
                await _userManager.CreateAsync(user, password: "pAssw0rd!");
            };

            /*Roles*/

            var roles = new List<IdentityRole>
            {
                new() { Name = "administrator"},
                new() { Name = "organizer"},
                new() { Name = "user"}
            };

            foreach (var role in roles)
            {
                await _roleManager.CreateAsync(role);
            }


            /*Add roles to users*/

            await _userManager.AddToRoleAsync(eventiaUser[0], //Felhan, Administrator
                $"{roles[0]}");

            await _userManager.AddToRoleAsync(eventiaUser[1], //Pim, User
                $"{roles[2]}");

            await _userManager.AddToRoleAsync(eventiaUser[2], //Morton, User
                $"{roles[2]}");

            /*Add roles to organizers*/

            await _userManager.AddToRoleAsync(eventiaOrganizers[0], //World Tours, Organizer
                $"{roles[1]}");

            await _userManager.AddToRoleAsync(eventiaOrganizers[1], //Experience , Organizer
                $"{roles[1]}");

            await _userManager.AddToRoleAsync(eventiaOrganizers[2], //Axelssons , Organizer
                $"{roles[1]}");

        }



    }
}
