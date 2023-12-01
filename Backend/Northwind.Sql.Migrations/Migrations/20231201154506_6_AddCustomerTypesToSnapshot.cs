using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Northwind.Sql.Migrations.Migrations
{
    public partial class _6_AddCustomerTypesToSnapshot : Migration
    {
        /// <summary>
        /// The reverse engineering of entity has skipped the link type <see cref="Core.Models.CustomerType"/> and used it by a shadow type. It meant that its columns/ indexes remained invisible in the snapshot
        /// causing migration issues since they weren't considered. Hence we add the type back to the snapshot (already exists in the schema).
        /// </summary>
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "CustomerDemographics",
            //    columns: table => new
            //    {
            //        CustomerTypeID = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false),
            //        CustomerDesc = table.Column<string>(type: "ntext", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_CustomerDemographics", x => x.CustomerTypeID)
            //            .Annotation("SqlServer:Clustered", false);
            //    });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "CustomerDemographics");
        }
    }
}
