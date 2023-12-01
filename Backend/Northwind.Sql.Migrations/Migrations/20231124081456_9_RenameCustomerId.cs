using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Northwind.Sql.Migrations.Migrations
{
    /// <summary>
    /// Renames the customer id column to customerCode as a test for EF migrations.
    /// </summary>
    public partial class Mig_9_RenameCustomerId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CustomerID",
                table: "Customers",
                newName: "CustomerCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CustomerCode",
                table: "Customers",
                newName: "CustomerID");
        }
    }
}
