using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Northwind.Sql.Migrations.Migrations
{
    public partial class _9_RenameCustomerId : Migration
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
