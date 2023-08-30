Adding Security to a web application
---------------------------------------

Uses ASP.NET Core Identity
   - It is a memberhsip system
   - Supports UI Login functionality (not useful for APIs)
   - Can be used for Authentication and Authorization
   - Can work with Third party providers like Google

Comes with out-of-the box functionality
   - Manage users, roles, claims, passwords, email confrimation, etc

There are scafolding pages availabel like Logins, password screen, etc.

Works by default with SQL databases, but can work with other DB too.

IdentityDbContext is the base class used for implementing security

Security has been added in a Razor Class Library (RCL).

Scafonlding can be used to generate the code with the library and these can be modified to 
adpat to the requirements for the applicaiton.

Important Classes: 
   
   * UserManager<IdentityUser> - used for interact with user objects in the data store (e.g. Create or Delete users)
   
   * SignInManager<IdentityUser> - used for handling all authentication actions (i.e. login, chnage pwd)


 Configuration 
 -----------------------

* To implment security add teh following Nuget Packages 
    ( whatch for version compatible with .NET 6. )

      - Microsoft.AspNetCore.Identity.EntityFrameworkCore (ver 6.0.20)
      - Microsoft.AspNetCore.Identity.UI (ver 6.0.20)


* For te DB context (e.g. BethanysPieShopDbContext), replace the base class to IdentityDbContext
  This will allow the system to know about users adn roles, aside from the added DB definitions. 
         
         DbContext -> IdentityDbContext

* Add middleware to Program.cs
      
      app.UseAuthentication();
      app.UseAuthorization();

* Add migration 
    * Do a build
    * Add migration command: 
        - add-migration IdentityAdded
        - update-database

* Services needed. The example below uses the default service (i.e. SQL)
  and passess the defined DB for teh project. 

     builder.Services.AddDefaultIdentity<IdentityUser>()
                     .AddEntityFrameworkStores<BethanysPieShopDbContext>();

    
    this service also permits specific configuration options

     builder.Services.AddDefaultIdentity<IdentityUser>(options => 
                {
                  options.Password.RequieDigit = true;
                  options.Password.RequiredLength = 8;
                  options.Password.RequireNonAlphanumeric = true;
                  options.User.RequireUNiqueEmail = true;
                })
                .AddEntityFrameworkStores<BethanysPieShopDbContext>();

 

 Adding Authentication using Scafolding
 ----------------------------------------
 * Select the project -> Add -> New Scaffolded Item

 * Select Identity from dialog box

 * It will show all the build-in functionality available for adding identity related funcitonality

 * for this example only the Account/Login and Account/Register will be used
   and select the DB contenxt that has the identity class

 * After the scafolded operation will add into the Program.cs the services to handle 
   authentication

     using Microsoft.AspNetCore.Identity;

     var connectionString = builder.Configuration.GetConnectionString("BethanysPieShopDbContextConnection") ?? 
            throw new InvalidOperationException("Connection string 'BethanysPieShopDbContextConnection' not found.");

     builder.Services.AddDbContext<BethanysPieShopDbContext>(options =>
         options.UseSqlServer(connectionString)); ;

     builder.Services.AddDefaultIdentity<IdentityUser>(options => 
         options.SignInRequireConfirmedAccount = true  // THis line was removed from the example for simplicity
         )
        .AddEntityFrameworkStores<BethanysPieShopDbContext>();

* The scafolding operation added teh folder "Areas". This is used to organize specific functionality.
  For this example the "Identity" area where authentication razor pages are added.

  NOTE: For this project, the Login and Register cshtml pages were modify for the exercise. 

* In the project Views/Shared/_Layout the following line was added to render teh authentication pages

    @RenderSection("Scripts", required: false)

* The scafolde operation also added the page Views/Shared/_LoginPartial.cshtml to help visualize if the
  user is logged in or not

* In the project Views/Shared/_Layout  add refrence to the Login partial view

      <partial name="_LoginPartial" />


Using Authorization to secure pages
-------------------------------------

Authorization is enforced by using arrtibutes, for example, for all authenticated users
theere will be access to the controller

[Authorize]
public classOrderController : Controller
{
}

The authorizatio can be applied at teh lever of an action too, to provide a finer-grain control

public classOrderController : Controller
{
   [Authorize]
   public IActionResult Checkout()
   {
   }
}

However, to restric specific roles, the attribute can specify only the group permited only to the page

[Authorize(Roles = "Administrator")]
public classOrderController : Controller
{
}

* In the Program.cs is is requied to have teh middleware for authorization

     app.UseAuthorization();

* Add the [Authorize] attribute in the controlers or actions that requires restrictions.


* This exerices does not include it, but pages can be added specific for administrators to 
  manage users subcriptions. 


