# PracticalTestWithEnterpriseArc

open the solution file in Visual Studio.
Change connection string in the appsettings.json file of the web project.
Choose Repo project in package manager console and run the following command for migration and create database.

Tools –> NuGet Package Manager –> Package Manager Console

PM> Add-Migration InitialCreate

PM> Update-Database

Run the application.

Please run application and hit below url.

http://localhost:59299/Users/list

This will return of all users form database.

For create a new user you need to run below url and pass json object user which conatin fullname and isactive flag.

http://localhost:59299/Users/create

here is sample json object of user

{"FullName": "Bill Gates", "IsActive": true   }

For list of services you need to run below url

http://localhost:59299/services/list

For list of specify user you need to run below URL with userid 

http://localhost:59299/Users/{UserId}/Services
