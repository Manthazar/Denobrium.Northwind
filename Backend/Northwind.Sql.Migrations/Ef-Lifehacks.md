

# Day to day

## Add migration
`add-migration "tbd"`
`add-migration "#{id of the github itemn}_niceAndShortDescription"`

## Apply a migration
The latest: `database update`


## Rollback a migration
`add-migration "tbd"`


# Initialization
## ...from existing database

Ensure, the following packages are referenced:
- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.Design
- Microsoft.EntityFrameworkCore.SqlServer
- Microsoft.EntityFrameworkCore.Tools

Run this command to get the kick-off models generated:
Scaffold-DbContext "Server=(localhost);Database=Northwind;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models

## Initial migrations

It is important that there is an initial migration in the project. Otherwise it won't be possible to move out the db context (and we would be potentially doubling changes on it)'.
The way to do this is 
1. `add-migration "Initial"`
2. Move the db context whereever you want
3. Add project reference/ fix naming namespace changes.

We also need to define the migration assembly now since it is different from the db context assembly:

services.AddDbContext<ApplicationDbContext>(
    options =>
        options.UseSqlServer(
            Configuration.GetConnectionString("DefaultConnection"),
            x => x.MigrationsAssembly("WebApplication1.Migrations")));