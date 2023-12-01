using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Northwind.Sql.Migrations.Migrations
{
    public partial class _6_AlignCustomerTypeConventions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CustomerDesc",
                table: "CustomerDemographics",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "CustomerTypeID",
                table: "CustomerDemographics",
                newName: "CustomerTypeCode");

            migrationBuilder.RenameTable(name: "CustomerDemographics", newName: "CustomerTypes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(name: "CustomerTypes", newName: "CustomerDemographics");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "CustomerDemographics",
                newName: "CustomerDesc");

            migrationBuilder.RenameColumn(
                name: "CustomerTypeCode",
                table: "CustomerDemographics",
                newName: "CustomerTypeID");
        }
    }
}
