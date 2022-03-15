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
    defaults: new { controller = "Events", action = "JoinEvent" });

app.MapControllerRoute(
    name: "Login",
    pattern: $"events/login/",
    defaults: new { controller = "Events", action = "LogIn" });

app.MapControllerRoute(
    name: "MyEvents",
    pattern: "myevents/",
    defaults: new { controller = "Events", action = "MyEvents" });

app.MapControllerRoute(
    name: "UpComingEvents",
    pattern: "events/",
    defaults: new { controller = "Events", action = "UpComingEvents" });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Events}/{action=index}"); // = default values.

app.MapRazorPages();

//PHASE 3  - Server started
app.Run();



