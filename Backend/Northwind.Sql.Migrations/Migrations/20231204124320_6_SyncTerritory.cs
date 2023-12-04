using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Northwind.Sql.Migrations.Migrations
{
    public partial class _6_SyncTerritory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeTerritories_Employees",
                table: "EmployeeTerritories");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeTerritories_Territories",
                table: "EmployeeTerritories");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerCustomerType_Customers",
                table: "CustomerCustomerTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Territories",
                table: "Territories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeTerritories",
                table: "EmployeeTerritories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "RegionDescription",
                table: "Region",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "CustomerID",
                table: "Customers",
                newName: "CustomerCode");

            migrationBuilder.RenameColumn(
                name: "CustomerID",
                table: "Orders",
                newName: "CustomerCode");

            migrationBuilder.RenameIndex(
                name: "CustomerID",
                table: "Orders",
                newName: "CustomerCode");

            migrationBuilder.RenameColumn(
                name: "TerritoryID",
                table: "EmployeeTerritories",
                newName: "TerritoryCode");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeTerritories_TerritoryID",
                table: "EmployeeTerritories",
                newName: "IX_EmployeeTerritories_TerritoryCode");

            migrationBuilder.RenameColumn(
                name: "TerritoryID",
                table: "Territories",
                newName: "TerritoryCode");

            migrationBuilder.AddColumn<int>(
                name: "TerritoryID",
                table: "Territories",
                type: "int",
                nullable: false)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "CustomerID",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Territories_TerritoryCode",
                table: "Territories",
                column: "TerritoryCode");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Territories",
                table: "Territories",
                column: "TerritoryID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeTerritories",
                table: "EmployeeTerritories",
                columns: new[] { "EmployeeID", "TerritoryCode" })
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Customers_CustomerCode",
                table: "Customers",
                column: "CustomerCode");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Territories_TerritoryCode",
                table: "Territories",
                column: "TerritoryCode")
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
                column: "TerritoryCode",
                principalTable: "Territories",
                principalColumn: "TerritoryCode");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers",
                table: "Orders",
                column: "CustomerCode",
                principalTable: "Customers",
                principalColumn: "CustomerCode");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerCustomerType_Customers",
                table: "CustomerCustomerTypes",
                column: "CustomerCode",
                principalTable: "Customers",
                principalColumn: "CustomerCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeTerritories_Employees",
                table: "EmployeeTerritories");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeTerritories_Territories",
                table: "EmployeeTerritories");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerCustomerType_Customers",
                table: "CustomerCustomerTypes");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Territories_TerritoryCode",
                table: "Territories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Territories",
                table: "Territories");

            migrationBuilder.DropIndex(
                name: "IX_Territories_TerritoryCode",
                table: "Territories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeTerritories",
                table: "EmployeeTerritories");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Customers_CustomerCode",
                table: "Customers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "TerritoryID",
                table: "Territories");

            migrationBuilder.DropColumn(
                name: "CustomerID",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Region",
                newName: "RegionDescription");

            migrationBuilder.RenameColumn(
                name: "CustomerCode",
                table: "Orders",
                newName: "CustomerID");

            migrationBuilder.RenameColumn(
                name: "TerritoryCode",
                table: "Territories",
                newName: "TerritoryID");

            migrationBuilder.RenameColumn(
                name: "CustomerCode",
                table: "Customers",
                newName: "CustomerID");

            migrationBuilder.RenameIndex(
                name: "CustomerCode",
                table: "Orders",
                newName: "CustomerID");

            migrationBuilder.RenameColumn(
                name: "TerritoryCode",
                table: "EmployeeTerritories",
                newName: "TerritoryID");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeTerritories_TerritoryCode",
                table: "EmployeeTerritories",
                newName: "IX_EmployeeTerritories_TerritoryID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Territories",
                table: "Territories",
                column: "TerritoryID")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeTerritories",
                table: "EmployeeTerritories",
                columns: new[] { "EmployeeId", "TerritoryId" })
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                column: "CustomerID");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers",
                table: "Orders",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "CustomerID");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerCustomerType_Customers",
                table: "CustomerCustomerTypes",
                column: "CustomerCode",
                principalTable: "Customers",
                principalColumn: "CustomerID");
        }
    }
}
