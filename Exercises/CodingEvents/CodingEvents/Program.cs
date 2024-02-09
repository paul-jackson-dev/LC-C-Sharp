using CodingEvents.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// set up database and add DbContext services
var connectionString = "server=localhost;user=username;password=password;database=coding-events-c-sharp";
var serverVersion = new MySqlServerVersion(new Version(8, 0, 33));
builder.Services.AddDbContext<EventDbContext>(dbContextOptions => dbContextOptions.UseMySql(connectionString, serverVersion)); // add this service to connect to our SQL server to update everytime we add to DbContext

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
