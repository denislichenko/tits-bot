# TitsBot

## About
This is a comic bot that was written in less than half an hour. Based on .Net Core framework. 

## Setup 
The description presumes that you already have a bot and it’s token. If not, please create one. You’ll find several explanations on the internet how to do this.

### Add migration 
We can execute the migration command using NuGet Package Manger Console as well as dotnet CLI (command line interface).

In Visual Studio, open NuGet Package Manager Console from Tools -> NuGet Package Manager -> Package Manager Console and enter the following command:
`add-migration init`
If you use dotnet CLI, enter the following command: `dotnet ef migrations add init`

### Update your database
After creating a migration, we still need to create the database using the update-database command in the Package Manager Console, as below.
`update-database`
Enter the following command in dotnet CLI.
`dotnet ef database update`

### Build project 
Now you can start the Bot in a local instance. 
