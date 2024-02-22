using CodingEvents.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);
//var connectionString = builder.Configuration.GetConnectionString("EventDbContextConnection") ?? throw new InvalidOperationException("Connection string 'EventDbContextConnection' not found.");

// Add services to the container.
builder.Services.AddControllersWithViews();

// set up database and add DbContext services
var connectionString = "server=localhost;user=username;password=password;database=coding-events-c-sharp";
var serverVersion = new MySqlServerVersion(new Version(8, 0, 33));
builder.Services.AddDbContext<EventDbContext>(dbContextOptions => dbContextOptions.UseMySql(connectionString, serverVersion)); // add this service to connect to our SQL server to update everytime we add to DbContext

//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<EventDbContext>();

builder.Services.AddRazorPages(); // Adds Register, Login, Logout pages

builder.Services.AddDefaultIdentity<IdentityUser> // configure Identity User requirements
(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 5;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
}).AddEntityFrameworkStores<EventDbContext>();

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
app.MapRazorPages(); // add for auth //app.MapRazorPages(); specifies to the app that the Identity pages should follow the routing laid out in _LoginPartial.cshtml.
app.MapControllers(); // add for auth

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
