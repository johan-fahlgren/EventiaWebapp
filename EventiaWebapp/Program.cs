// DATABASE
DataLayer.Backend.Admin.PrepTestDatabase();


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
    name: "JoinEvent",
    pattern: $"events/confirmation/",
    defaults: new { controller = "EventsC", action = "JoinEvent" });

app.MapControllerRoute(
    name: "Login",
    pattern: $"events/LogIn/",
    defaults: new { controller = "EventsC", action = "LogIn" });

app.MapControllerRoute(
    name: "MyEvents",
    pattern: "events/booked",
    defaults: new { controller = "EventsC", action = "MyEvents" });

app.MapControllerRoute(
    name: "Events",
    pattern: "events/booked",
    defaults: new { controller = "EventsC", action = "Events" });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Events}/{action=index}"); // = default values.

app.MapRazorPages();

//PHASE 3  - Server started
app.Run();



