
## How to Run this Project

### Prerequisites
- .NET 8 or higher
- PostgreSQL Database
- Any REST client (e.g., Postman) or browser for testing API endpoints.

### Steps
1. Clone the repository:   
   - git clone <https://github.com/RicardoZitelli/AmbevAvaliacao.git>

2. Navigate to the project directory:   
   - cd <project-folder>

3. Setup the database:
   - Ensure PostgreSQL is installed and running.
   - Create a new database (e.g., `DeveloperEvaluation`).
   - Update the connection string in `appsettings.json`.

4. Run migrations to create the necessary tables:   
   - dotnet ef database update

5. Start the application:
   - dotnet run
