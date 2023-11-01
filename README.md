# CvApp
---
## Short review
<p>CvApp is created for creating, editing, deleting CVs, as well as for nicely displaying on screen for printing out one specific CV. 
It contains now 3 sections - genral info, languages and education (more sections can be added for real-life usage).</p>
---
## Technologies used
C# ASP.NET Core WEB
Razor pages
EntityFramework used for storing data in DB using Azure Data Studio.
---
### Prerequisites
Visual Studio
---
### Installation
--> Clone repository
--> Open from Visual Studio
--> Install necessary dependencies (e.g.NuGet packages)
--> Configure the connection string to connect your application to the Azure Data Studio database
--> Run following commands for migrations in Package Manager Console (choose CvApp.Data as default project):
  - addd-migartion Init
  - update-database
--> Try to run project, should open on your localhost
---
