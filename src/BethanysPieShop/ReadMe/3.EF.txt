EF core commands to create teh DB ( Code First approach)
======================================================

NuGet Packages needed
--------------------------------
  <PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="8.0.0-preview.6.23329.4" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="8.0.0-preview.6.23329.4">
      <PrivateAssets>all</PrivateAssets>
      <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
    </PackageReference>

* Create Models
* Create DB context with model-to-table properties
* Run command to initialize and update the DB
* add DbInitializer program: DbInitializer
* Refrence DbInitialize at the Program.cs: DbInitializer.Seed(app);

Initialize the DB 
------------------------------
add-migration InitialMigrations
update-database


Updating the DB 
---------------------
add-migration AddShopingCartItem
update-database

add-migration OrderAdded
update-database
