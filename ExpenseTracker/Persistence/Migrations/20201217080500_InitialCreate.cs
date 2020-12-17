using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TestValues",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestValues", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "TestValues",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[] { new Guid("58e46b6f-1379-42a2-9009-f18117b418ec"), "Lorem ipsum dolor1", "Test Value 1" });

            migrationBuilder.InsertData(
                table: "TestValues",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[] { new Guid("2f800fb0-ccb3-4ca7-8bdc-8cfedab27c95"), "Lorem ipsum dolor2", "Test Value 2" });

            migrationBuilder.InsertData(
                table: "TestValues",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[] { new Guid("d81c4744-d4b3-4786-8690-f3bab0499b74"), "Lorem ipsum dolor3", "Test Value 3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TestValues");
        }
    }
}
