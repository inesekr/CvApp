## CvApp
---
### Short review
#### CvApp is created for creating, editing, deleting CVs, as well as for nicely displaying on screen for printing out one specific CV. 
#### It contains now 3 sections - genral info, languages and education (more sections can be added for real-life usage).
---
### Technologies used
#### C# ASP.NET Core WEB App (Model-View-Controller), .Net version 6.0.
#### EntityFramework used for storing data in DB using Azure Data Studio.
---
### Prerequisites
#### Visual Studio
---
#### Installation
* Clone repository
* Open from Visual Studio
* Install necessary dependencies (e.g.NuGet packages) if any missing
* Configure the connection string to connect your application to the Azure Data Studio database (in appsettings.json file)
* Run following commands for migrations in Package Manager Console (choose CvApp.Data as default project):<br>
  ` addd-migration Init ` <br>
  ` update-database `
* Try to run project, should open on your localhost
---
