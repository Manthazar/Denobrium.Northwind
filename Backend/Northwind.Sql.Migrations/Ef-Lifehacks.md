


# Initialization
## ...from existing database

Ensure, the following packages are referenced:
- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.Design
- Microsoft.EntityFrameworkCore.SqlServer
- Microsoft.EntityFrameworkCore.Tools

Run this command to get the kick-off models generated:
Scaffold-DbContext "Server=(localhost);Database=Northwind;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models