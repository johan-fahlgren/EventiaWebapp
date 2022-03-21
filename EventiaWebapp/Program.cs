using DataLayer.Backend;
using DataLayer.Data;
using Microsoft.EntityFrameworkCore;

//WEBAPP

//PHASE 1 - configuring of webapp
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<Admin>();

//Add EnventHandler ass service
builder.Services.AddScoped<EventHandler>();

//Add database as service
builder.Services.AddDbContext<EventiaDbContext>(options =>
     options.UseSqlServer("DefaultConnection"));

//Add Debugging
builder.Services.AddDatabaseDeveloperPageExceptionFilter();


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


using (var scope = app.Services.CreateScope())
{
    //Initiate database
    var admin = scope.ServiceProvider.GetService<Admin>();
    admin.PrepTestDatabase();


    var ctx =
        scope.ServiceProvider.GetRequiredService<EventiaDbContext>();
}

//PHASE 3  - Server started
app.Run();





