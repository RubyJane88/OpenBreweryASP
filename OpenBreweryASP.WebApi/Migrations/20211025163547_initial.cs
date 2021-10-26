using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OpenBreweryASP.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Breweries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BreweryType = table.Column<int>(type: "int", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    County_province = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Postal_code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Longitude = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Latitude = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Website_url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Breweries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BreweryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_Breweries_BreweryId",
                        column: x => x.BreweryId,
                        principalTable: "Breweries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Breweries",
                columns: new[] { "Id", "BreweryType", "City", "Country", "County_province", "Created_at", "Latitude", "Longitude", "Name", "Phone", "Postal_code", "State", "Street", "Updated_at", "Website_url" },
                values: new object[] { 299, 6, "Alameda", "United States", null, new DateTime(2018, 8, 24, 1, 24, 11, 758, DateTimeKind.Local), "37.7834497667258", "-122.306283180899", "Almanac Beer Company", "4159326531", "94501-5047", "California", "651B W Tower Ave", new DateTime(2018, 8, 24, 1, 24, 11, 758, DateTimeKind.Local), "https://almanacbeer.com" });

            migrationBuilder.CreateIndex(
                name: "IX_Address_BreweryId",
                table: "Address",
                column: "BreweryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Breweries");
        }
    }
}
