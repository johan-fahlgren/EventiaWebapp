using DataLayer.Backend;
using DataLayer.Data;
using EventiaWebapp.Services;
using Microsoft.EntityFrameworkCore;


//WEBAPP

//PHASE 1 - configuring of webapp
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<Admin>();
builder.Services.AddScoped<Database>();

//Add EnventHandler as service
builder.Services.AddScoped<EventService>();

//Add database as service
builder.Services.AddDbContext<EventiaDbContext>(options =>
     options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//Add Debugging
builder.Services.AddDatabaseDeveloperPageExceptionFilter();


//PHASE 2 - Middleware pipeline (Configure the HTTP request pipeline).

var app = builder.Build();

app.UseRouting();

app.UseStaticFiles();

/*app.MapControllerRoute(
    name: "JoinEvent",
    pattern: $"Events/Confirmation/",
    defaults: new { controller = "Events", action = "JoinEvent" });

app.MapControllerRoute(
    name: "MyEvents",
    pattern: "MyEvents/",
    defaults: new { controller = "Events", action = "MyEvents" });

app.MapControllerRoute(
    name: "UpComingEvents",
    pattern: "Events/",
    defaults: new { controller = "Events", action = "UpComingEvents" });

app.MapControllerRoute(
    name: "Default",
    pattern: "{controller=Events}/{action=index}"); // = default values.*/

app.MapRazorPages();


using (var scope = app.Services.CreateScope())
{

    var admin = scope.ServiceProvider.GetService<Admin>();
    //Initiate database
    if (app.Environment.IsProduction())
    {
        await admin.CreateDatabase();
    }

    if (app.Environment.IsDevelopment())
    {
        await admin.createDatabaseIfNotExists();
    }

}

//PHASE 3  - Server started
app.Run();





