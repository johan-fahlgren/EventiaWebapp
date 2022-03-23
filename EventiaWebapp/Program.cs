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
if (builder.Environment.IsDevelopment())
{
    builder.Services.AddDatabaseDeveloperPageExceptionFilter();
}


//PHASE 2 - Middleware pipeline (Configure the HTTP request pipeline).

var app = builder.Build();

app.UseRouting();

app.UseStaticFiles();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseExceptionHandler("/error");

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





