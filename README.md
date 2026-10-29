# EstateHub Property Management System

ASP.NET Core MVC (.NET 8) with XAMPP MySQL. Modules: account registration/login, dashboard, properties, tenants, leases, rent payments, and maintenance.

## Run on Windows
1. Install .NET 8 SDK. Open XAMPP and start **MySQL**.
2. Extract this ZIP to a **new empty folder**. Do not nest another copy of the project inside it.
3. In `appsettings.json`, change MySQL port/password if your XAMPP uses different settings. Default is `127.0.0.1:3306`, user `root`, empty password.
4. Open PowerShell in the directory containing `EstateHub.csproj`.
5. Run `dotnet restore`, `dotnet build`, then `dotnet run`.
6. Visit `http://localhost:5092/Account/Register` and create your account.

The app automatically creates `estatehub_db` and tables if the MySQL user has CREATE privileges. A manual `database_setup.sql` is also included. Passwords are hashed using ASP.NET Core PasswordHasher; SQL values are parameterized; management pages require authentication.

**Workflow:** Add properties and tenants first. Create a lease using their numeric IDs. Record payments against lease IDs. Add maintenance requests against property IDs.

**Academic demonstration only.** This project has not been compiled in the packaging environment because the .NET SDK is unavailable. It is not a production multi-tenant application: all signed-in users share the same data, and it needs authorization roles, stronger validation, backups and auditing before real-world use.
