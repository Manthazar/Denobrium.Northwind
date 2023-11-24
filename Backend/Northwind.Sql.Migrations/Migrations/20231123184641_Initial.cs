using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Northwind.Sql.Migrations.Migrations
{
    /// <summary>
    /// The initial database setup is represented by an awful sql script provided on GitHub: https://github.com/Microsoft/sql-server-samples/tree/master/samples/databases/northwind-pubs
    /// </summary>
    /// <remarks>
    /// At a later stage, I might change my opinion and embed the script here so that frequent sandbox resets will smoothly integrate into the migration step(s).
    /// </remarks>
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
