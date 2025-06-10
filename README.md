* Add Migration
	* Navigate to codebase root path.	* Run: `dotnet ef migrations add <migration-name> --project Dog.Infrastructure -o DataStore/Migrations`
	* Run: `dotnet ef database update --project Dog.Infrastructure`