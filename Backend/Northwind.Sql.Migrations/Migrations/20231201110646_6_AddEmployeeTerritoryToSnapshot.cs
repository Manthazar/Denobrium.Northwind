using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Northwind.Sql.Migrations.Migrations
{
    /// <summary>
    /// The reverse engineering of entity has skipped the link type <see cref="Core.Models.EmployeeTerritory"/> and used it by a shadow type. It meant that its columns/ indexes remained invisible in the snapshot
    /// causing migration issues since they weren't considered. Hence we add the type back to the snapshot (already exists in the schema).
    /// </summary>
    public partial class Mig_6_AddEmployeeTerritoryToSnapshot : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeTerritories_Employees",
                table: "EmployeeTerritories");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeTerritories_Territories",
                table: "EmployeeTerritories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeTerritories",
                table: "EmployeeTerritories");

            // See summary.
            //migrationBuilder.AddColumn<int>(
            //    name: "EmployeeId",
            //    table: "EmployeeTerritories",
            //    type: "int",
            //    nullable: false,
            //    defaultValue: 0);

            //migrationBuilder.AddColumn<string>(
            //    name: "TerritoryId",
            //    table: "EmployeeTerritories",
            //    type: "nvarchar(20)",
            //    nullable: false,
            //    defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeTerritories",
                table: "EmployeeTerritories",
                columns: new[] { "EmployeeId", "TerritoryId" })
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTerritories_EmployeeID",
                table: "EmployeeTerritories",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTerritories_TerritoryId",
                table: "EmployeeTerritories",
                column: "TerritoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeTerritories_Employees",
                table: "EmployeeTerritories",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeID");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeTerritories_Territories",
                table: "EmployeeTerritories",
                column: "TerritoryId",
                principalTable: "Territories",
                principalColumn: "TerritoryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeTerritories_Employees",
                table: "EmployeeTerritories");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeTerritories_Territories",
                table: "EmployeeTerritories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeTerritories",
                table: "EmployeeTerritories");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeTerritories_EmployeeID",
                table: "EmployeeTerritories");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeTerritories_TerritoryId",
                table: "EmployeeTerritories");

            // See summary.
            //migrationBuilder.DropColumn(
            //    name: "EmployeeId",
            //    table: "EmployeeTerritories");

            //migrationBuilder.DropColumn(
            //    name: "TerritoryId",
            //    table: "EmployeeTerritories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeTerritories",
                table: "EmployeeTerritories",
                columns: new[] { "EmployeeID", "TerritoryID" })
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeTerritories_Employees",
                table: "EmployeeTerritories",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "EmployeeID");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeTerritories_Territories",
                table: "EmployeeTerritories",
                column: "TerritoryID",
                principalTable: "Territories",
                principalColumn: "TerritoryID");
        }
    }
}
