Publishing the application to Azure
---------------------------------------

For the last step, the author recommended to deploy to to the cloud.

Register:  azure.microsoft.com
Portal: portal.azure.com

* In Azure Services create a resource group
* Name it "BethanysPieShop"
* Select Region (US)

To publish using VS (PaaS) 

   Note: For larger and complex projects that involve many developers, use CI/CD pipelines.

* Select the project, and with the mouse right-button select "Publish"
* Select Azure
* Target use a "Axure AppService (Windows)"
* In dialog box, enter

     -Target (Subcription name)
     - AppService
     - Add an App Service Instance
     - add name (used as part of the URI), for example bethanyspieshop20230808
     - Select Resource Group
     - add a new Hosting plan ( i.e. the server hosting teh app)
     - Select ok.
     -  On Service Dependencies, make sure to assign a proper SQL server in teh cloud.
          - Select the button to connect the dependency
          - Select an Azure SQL Database.
          - Create a new SQl DB (BethanysPieShop_db)
          - assign to teh resource group
          - create a new database server, adding admin user and pwd
          - hit teh create button
          - with datbase server connected, hit NEXT 
          - add admin user and pwd
          - copy the generated connection string (save in notepad)
          - Save connection string as "Azure App Settings"
          - Then select Next and Finish.
    
     - keep a copy of the local connection string
     - replace the connection string with the one Azure generated
     
     - Go to azure to configure the SQL database Azure firewall
     - Teh Resource group will have all new created resources
     - Select the SQL Database -> Set Server Firewall
     - Under Firewall rules, add the current IP address (local computer)
       to allow accessing the DB using the local computer
     - Go back to VS, and in the manager console  execute a: update-database
     - This will update the DB in Azure.
     
     - Finally, in VS, use the Publish button
     - you can see the application at 

             bethanyspieshop20230808.azurewebsites.net
     


