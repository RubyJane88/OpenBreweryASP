using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OpenBreweryASP.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brewery",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BreweryType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountyProvince = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Longitude = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Latitude = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WebsiteUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brewery", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BreweryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_Brewery_BreweryId",
                        column: x => x.BreweryId,
                        principalTable: "Brewery",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Brewery",
                columns: new[] { "Id", "BreweryType", "City", "Country", "CountyProvince", "CreatedAt", "Latitude", "Longitude", "Name", "Phone", "PostalCode", "State", "Street", "UpdatedAt", "WebsiteUrl" },
                values: new object[,]
                {
                    { new Guid("41ba6032-4389-4546-8e83-36a5a58ff72d"), "contract", "Alameda", "United States", null, new DateTime(2018, 8, 24, 1, 24, 11, 758, DateTimeKind.Local), "37.7834497667258", "-122.306283180899", "Almanac Beer Company", "4159326531", "94501-5047", "California", "651B W Tower Ave", new DateTime(2018, 8, 24, 1, 24, 11, 758, DateTimeKind.Local), "https://almanacbeer.com" },
                    { new Guid("611be954-ebdb-4d03-9d8b-0a7a867835c0"), "bar", "Houston", "United States", null, new DateTime(2019, 8, 24, 1, 24, 11, 758, DateTimeKind.Local), "29.9515464", "-95.5186591", "11 Below Brewing Company", "2814442337", "77066-3107", "Texas", "6820 Bourgeois Rd", new DateTime(2019, 8, 24, 1, 24, 11, 758, DateTimeKind.Local), "http://www.11belowbrewing.com" },
                    { new Guid("e33f0ff9-c919-4b6c-b054-4e1ef1b7bff5"), "large", "Bend", "United States", null, new DateTime(2019, 9, 24, 1, 24, 11, 758, DateTimeKind.Local), null, null, "10 Barrel Brewing Co", "5415851007", "97701-9847", "Oregon", "62970 18th St", new DateTime(2019, 9, 24, 1, 24, 11, 758, DateTimeKind.Local), "http://www.10barrel.com" },
                    { new Guid("26a3c529-ab7c-4f20-873f-156778632582"), "brewpub", "Reno", "United States", null, new DateTime(2019, 11, 26, 0, 24, 11, 758, DateTimeKind.Local), "39.5171702", "-119.7732015", "10 Torr Distilling and Brewing", "7755307014", "89502", "Nevada", "490 Mill St", new DateTime(2019, 11, 26, 0, 24, 11, 758, DateTimeKind.Local), "http://www.10torr.com" }
                });

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
                name: "Brewery");
        }
    }
}
