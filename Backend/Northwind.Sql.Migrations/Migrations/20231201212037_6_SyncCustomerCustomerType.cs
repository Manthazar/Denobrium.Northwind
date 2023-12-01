using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Northwind.Sql.Migrations.Migrations
{
    public partial class Mig_6_SyncCustomerCustomerType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerCustomerDemo",
                table: "CustomerCustomerDemo");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerCustomerDemo_Customers",
                table: "CustomerCustomerDemo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerCustomerDemo",
                table: "CustomerCustomerDemo");

            migrationBuilder.RenameTable(
                name: "CustomerCustomerDemo",
                newName: "CustomerCustomerTypes");

            migrationBuilder.RenameColumn(
                name: "CustomerID",
                newName: "CustomerCode",
                table: "CustomerCustomerTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerCustomerTypes",
                table: "CustomerCustomerTypes",
                columns: new[] { "CustomerCode", "CustomerTypeCode" })
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerCustomerTypes_CustomerTypeCode",
                table: "CustomerCustomerTypes",
                column: "CustomerTypeCode");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerCustomerType_Customers",
                table: "CustomerCustomerTypes",
                column: "CustomerCode",
                principalTable: "Customers",
                principalColumn: "CustomerCode");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerCustomerType_CustomerTypes",
                table: "CustomerCustomerTypes",
                column: "CustomerTypeCode",
                principalTable: "CustomerTypes",
                principalColumn: "CustomerTypeCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerCustomerType_Customers",
                table: "CustomerCustomerTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerCustomerType_CustomerTypes",
                table: "CustomerCustomerTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerCustomerTypes",
                table: "CustomerCustomerTypes");

            migrationBuilder.DropIndex(
                name: "IX_CustomerCustomerTypes_CustomerTypeCode",
                table: "CustomerCustomerTypes");

            migrationBuilder.RenameTable(
                name: "CustomerCustomerTypes",
                newName: "CustomerCustomerDemo");

            migrationBuilder.RenameColumn(
                name: "CustomerCode",
                newName: "CustomerID",
                table: "CustomerCustomerDemo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerCustomerDemo",
                table: "CustomerCustomerDemo",
                columns: new[] { "CustomerID", "CustomerTypeCode" })
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerCustomerDemo",
                table: "CustomerCustomerDemo",
                column: "CustomerTypeCode",
                principalTable: "CustomerTypes",
                principalColumn: "CustomerTypeCode");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerCustomerDemo_Customers",
                table: "CustomerCustomerDemo",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "CustomerCode");
        }
    }
}
