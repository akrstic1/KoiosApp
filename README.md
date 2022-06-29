# KoiosApp

## Setup

1. Create a local MSSQL database
2. Adjust the connection string in appsettings.json
3. Execute the database update script inside KoiosTask.Dal project
 `dotnet ef database update --startup-project ../KoiosTask.Web`
4. Run
