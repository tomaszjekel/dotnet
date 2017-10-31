//To Run
dotnet restore to.mo1.sln 

//Generate MSSql entity 
dotnet ef migrations add InitialCreate; 

//Remove config ef migration 
dotnet ef migrations remove --configuration InitialCreation 

//Update db 
dotnet ef database update 

//Generate Views and Conroller form Model if needed 
dotnet aspnet-codegenerator controller -name UserController -m User -dc ApplicationDbContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries
