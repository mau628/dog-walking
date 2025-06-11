# ECI Challenge: Dog Walking Business

## Objective:
Create a Windows Forms application to manage client and dog information for a dog walking business.

## Timeframe: 
3 business days

## Requirements:
1. Form Design:
    * ✅ Include fields for client name, phone number, dog name, breed, age, walk date, and duration.
    * ✅ Add buttons for saving, clearing, deleting, and exiting.
2. Functionality:
    * ✅ Implement validation for relevant fields.
    * ✅ Ensure the save button stores the information and displays a confirmation message.
    * ✅ Delete should remove the item.
    * ✅ Clear button should reset all fields.
    * ✅ Exit button should close the application. 
2. Data Persistence:
    * ✅ Save the data entered to a file, physical or in-memory database so that it remains available even after the application is closed and reopened.
    * ✅ Set up a README file in your GitHub repo with instructions on how to run the application.
4. Useful Features:
    * ✅ Include an area to retrieve saved entries.
    * ✅ Implement search functionality to find specific entries.
    * ✅ Include error handling for unexpected inputs.
    * ✅ Have a login flow.
    * ✅ Allow for adding a dog walk for a client that records information about the event.
    * ✅ Use validation messages where appropriate.

## Pre-requirements:
  * Visual Studio
  * Microsoft SQL Server (or similar for data persistence / binding)
  * GitHub account (or similar)

## Instructions:
* ✅ Read the above requirements carefully
* ✅ Create a GitHub repo that can be accessed by us. “Commit early, commit often”
* ✅ Complete as many of the features as possible in the timeframe. There is no requirement to finish ALL features / optional items. It is better to focus on quality code and implementation than rushing and completing all items.
* ✅ Use AI! If you need to, use AI to help you with specific areas. Keep in mind that AI doesn’t always produce the best results, and we wouldn’t expect the entire solution to be solely from AI.
* ✅ Include unit tests to verify the functionality of your code.
* ✅ Document your code thoroughly to make it easier for others to understand and maintain.
* ✅ Feel free to add any other features that are not on this list if you believe they will help or are useful.

## Run the Application:
1. Clone the repository to your local machine.
2. Open the solution in Visual Studio.
3. Restore the NuGet packages if prompted.
4. Access to `AppData/Local/dog-walking.db` file is required for the application to run.
5. Apply the migrations to the database if it is not already set up. Check the Migrations section below for instructions.
6. Press `F5` to run the application.
7. The application should start and ask for username and password.
    * For mocking purposes, any username and password can be used to log in.
    * Users are stored in-memory, so they will not persist after the application is closed.

### Workflow:
1. **Add Client**: Click on the "Add Client" button, fill in the client details, then click "Save".
    * Client window will be be closed to see the changes in the main window.
    * Reopen the client window to be able to add a dog for the client.
2. **Add Dog**: Fill in the dog details and select the owner from the dropdown, then click "Save".
    * Dog window will be closed to see the changes in the main window.
    * Reopen the client window to be able to add a walk for the dog.
3. **Add Walk**: Select a dog, fill in the walk details, then click "Save".

## Run Unit Tests:
1. Open the solution in Visual Studio.
2. Navigate to the Test Explorer.
3. Run all tests to verify the functionality of the application.

### Run tests and check code coverage:
1. Open PowerShell in the solution directory.
2. Run the following command to execute tests and generate code coverage:
    ```bash
    .\run-tests.ps1
    ```
3. A browser window will open displaying the code coverage report.

## Project Structure:
* **Dog.Core**: Contains the services and validation logic.
* **Dog.Domain**: Contains the domain models and interfaces.
* **Dog.Infrastructure**: Contains the data access layer, including Entity Framework Core configurations and migrations.
* **Dog.Presentation**: Contains the user interface components.
* **Dog.Runtime**: Contains the main entry point of the application. All services are registered here.

## Migrations:
To Add a Migration:
* Navigate to codebase root path.
* Run: `dotnet ef migrations add <migration-name> --project Dog.Infrastructure -o DataStore/Migrations`

To update the database the first time:
* Navigate to codebase root path.
* Run: `dotnet ef database update --project Dog.Infrastructure`

## TODO's:
* Refactor the code to allow child record updates without needing to reopen the form.
* Refactor the grids to refresh on data change.
* When adding a new dog, the Dog form should already have the current Owner selected.
* Add pagination to the grids.
* Add a search bar to the grids.
* Add user authentication flow.
* Add a settings page to configure the database connection string.
* Enhance Search functionality to allow to edit any record from the search results and use more advanced search options.
