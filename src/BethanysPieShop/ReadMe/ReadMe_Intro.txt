Introduction 
-----------------------
Date: Augus 2023

This project is an example followed from PluralSight course "ASP.NET Core 6 Fundamentals" by Gill Creeren, 
and it is a WEB application using ASP.NET Core under MVC programmimng model. 

Hoever, the project aslso include example for Razor Pages and API functionality, all combined.
The authto also present integration with Blazzer, which is not adopted in this project.

It is recomended to read the multiple "ReadMe" files as it offers reminder for concepts presented in
here. Start with the "ReadMe_StepsToBuild.txt".

The project present many features available to this date.

Comments
---------

ORGANIZATION
The author handles this project under a simple organization, adding Models, Interfaces, and Repos
under the "Models" folder. 

In a bigger project, it is recomended to break the project into three:

* Domain Project (i.e. BethanysPieShop.Domain)
* Data Layer Project (i.e. BethanysPieShop.Data)
* Client Project (i.e. BethanysPieShop)

The Domain will  have folders for Interfaces, Models, and other organizational elements.
The Data Layer will refrence teh Domain, and implement the EF DB context.
The Client will refernce both Domain and Data Layer, implementing teh frontend functionality.

MODELS and VIEWMODELS
The author uses a simple exmple to transform Models into ViewModels, but for real applications
it is recomended not to expose Models in any way, and use a mapper to move data between 
models and ViewModels. The later is recomended for exposing the data to teh frontend.
If the data is tampered in teh frontend, the mapper will serve as an isolator for the 
real DB infromation (e.g. SQL Injection attacks).

It can be recommended to use AutoMapper.






