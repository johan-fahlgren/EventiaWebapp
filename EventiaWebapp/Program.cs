// DATABASE
DataLayer.Backend.Admin.PredTestDatabase();


//WEBAPP

//PHASE 1 - configuring of webapp
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();


//PHASE 2 - Middleware pipeline (Configure the HTTP request pipeline).

var app = builder.Build();

app.UseRouting();

app.MapControllerRoute(
    name: "overview",
    pattern: $"events/confirmation/{id:int}",
    defaults: new { controller = "Events", action = "Confirmation" });

app.MapControllerRoute(
    name: "overview",
    pattern: $"events/join/{id:int}",
    defaults: new { controller = "Events", action = "Join" });

app.MapControllerRoute(
    name: "booked",
    pattern: "events/booked",
    defaults: new { controller = "Events", action = "Booked" });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Events}/{action=index}"); // = default values.

app.MapRazorPages();

//PHASE 3  - Server started
app.Run();
}


