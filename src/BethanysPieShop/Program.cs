using BethanysPieShop.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Text.Json.Serialization;

// This example uses top level command simplifying the operation
// if services initialization need to be in other file, 
// use the IHostingStartup in teh secondary file. 
// all files with this interfaces will be executed at the start

// If the appliction need to run a background service, 
// register the worker class using:  services.AddHostedService<Worker>();
// the worker class needs to implement the BackgroundService base class

// To enable hosting a web application 
// For .NET MVC or Razor web app yse WebApplcation
// for API applications use var builder = Host.CreateApplicationBuilder();
var builder = WebApplication.CreateBuilder(args);

// DATABASE - Context registration 

// Option 1
//builder.Services.AddDbContext<BethanysPieShopDbContext>(options => {
//    options.UseSqlServer(
//        builder.Configuration["ConnectionStrings:BethanysPieShopDbContextConnection"]);
//});

// Option 2 -  After the scafolded operation will add into trh Program.cs teh lines to handle authentication
var connectionString = builder.Configuration.GetConnectionString("BethanysPieShopDbContextConnection") ?? throw new InvalidOperationException("Connection string 'BethanysPieShopDbContextConnection' not found.");

builder.Services.AddDbContext<BethanysPieShopDbContext>(options =>
    options.UseSqlServer(connectionString)); ;

// Identity(Authentication)
builder.Services.AddDefaultIdentity<IdentityUser>()
    .AddEntityFrameworkStores<BethanysPieShopDbContext>();

//this service also permits specific configuration options
//builder.Services.AddDefaultIdentity<IdentityUser>(options =>
//           {
//               options.Password.RequireDigit = true;
//               options.Password.RequiredLength = 8;
//               options.Password.RequireNonAlphanumeric = true;
//               options.User.RequireUniqueEmail = true;
//           })
//           .AddEntityFrameworkStores<BethanysPieShopDbContext>();



// REPOSITORIES (data layer)
// For Repos, it is traditional to use AddScopped
//builder.Services.AddScoped<ICategoryRepository, MockCategoryRepository>();
//builder.Services.AddScoped<IPieRepository, MockPieRepository>();

// real repositories
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IPieRepository, PieRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

// executed teh shoping cart static method and regiter teh returned Shoping card wwith services, as IShoppingCart
builder.Services.AddScoped<IShoppingCart, ShoppingCart>(sp => ShoppingCart.GetCart(sp));
builder.Services.AddSession(); // Inner service for handling sessions ( i.e. cookies / local storage) 
builder.Services.AddHttpContextAccessor(); // This is need to access the sessions

// MVC and RAZOR pages can live in the same applicaition
// THis example was build mainly using MVC, but a RAZOR page was
// added for the order form

// USE MVC approach: Add services to the container.
builder.Services.AddControllersWithViews()
    .AddJsonOptions(options =>
    {
        // Ignore data dependencies cycles (i.e. database)
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });

// USE also RAZOR PAGES
builder.Services.AddRazorPages();

// use for API - NOTE: If MVC is included, this is not needed
// to add APIs as AddControllersWithViews has the funcitonality
// Defining the statment along anything else will not cause issues.
// builder.Services.AddControllers();


// MIDDLEWAR COMPONENTS

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // added by instructure, is this better than wha is recomended by template?
    app.UseDeveloperExceptionPage(); // Diagnstic page for development only

    // added by template
    //app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    //app.UseHsts();
}

app.UseStaticFiles();  // to look for static files like images in wwwroot folder

app.UseSession(); // To have acces to sessions ( i.e. cookies, local storage)

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); // For validating users
app.UseAuthorization();  // for allowing user to access pages

// Default way to navigate the views (i.e. pages)
// app.MapDefaultControllerRoute(); // Default: "{controller=Home}/{action=Index}/{id?}"

// MVC Routing, with id as optional, similar to default routing
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// For example, will force ID to be a integer
//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id:int?}");

// RAZOR pages enabled 
app.MapRazorPages();

// use for API - NOTE: If MVC is included, this is not needed
// to add APIs, as MapControllerRoute has the functionality
// Defining the statment along anything else will not cause issues.
// app.MapControllers();


// Initialize the database ( Models/DbINitializer.cs)
DbInitializer.Seed(app);

app.Run();
