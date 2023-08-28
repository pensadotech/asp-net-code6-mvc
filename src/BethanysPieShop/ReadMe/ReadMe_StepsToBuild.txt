How to start a project
--------------------------

The author recomends to start by  

  * Configuring the application.

From there, continue with 

  * adding Models and a mock repository
  * This is, add a controller and a view.
  * Add a first page, using Models only. 
    Even though the developer need to type the URL 
    for example: https://localhost:7275/Pie/List
  * Add a ViewModel and use it for the screen, instead of Models.
    
    NOTE: This example present a simple ideas, for more advance
          projects it is recomended to use a mapper tool ( e.g. AutoMapper).

  * Work in showing the data first and work in the page style

As following steps in the approach, the instructore recomends

  * to create teh database using EF, code first approach (is is teh only option now)
  * Create the DB context using Model classes
  * define the connection string
  * use migration to generate the SQl code and update the DB ( see ReadMe_EF file)


The next recommended step is 

 * Add routing in the Program.cs
 * Add navigation 

 The next step is to improve the views

 * By adding partial views
 * By adding View Components
 * By adding Tag helpers
 * By adding forms using Model binding
 * in thi step teh instructire added a Razor page to demostrate that MVC pages 
   can be combiened in teh same project.
 
 The next step is to implement testing for the project, as it is critical
 that teh funcitonality is in check as the project grows.

  * Add a test project 
  * Add testing folders an function for each functionality.
  * As new functinality is added, add more test cases. 

The next step is adding a API, this was to demostarte that a WEB app can also expose APIs.
In this example the author uses a SEARCH functionality as example, creating a view
that uses JQuery to demostrate the interaction.

The next step was adding security based on a SQL databae

  * change the DB COntext to use IdentityDbContext instead of the traditiona DbContext
  * Apply mirgrations and database again, to add Authentication tables.
  * Use Scafolding to bring Identity functionality in palce.
  * Adjust the main views to plug in the Scafolding generated functionality.


Publish to Azure
-----------------------

For the last step, the author recommended to deploy to to the cloud.
Follow the ReadMe_PublishToAzure.txt













