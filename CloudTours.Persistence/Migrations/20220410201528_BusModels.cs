using Microsoft.EntityFrameworkCore.Migrations;

namespace CloudTours.Persistence.Migrations
{
    public partial class BusModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BusManuFacturers",
                columns: table => new
                {
                    BusManuFacturerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(150)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusManuFacturers", x => x.BusManuFacturerId);
                });

            migrationBuilder.CreateTable(
                name: "BusModels",
                columns: table => new
                {
                    BusModelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusModelName = table.Column<string>(type: "varchar(150)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    SeatCapacity = table.Column<int>(type: "int", nullable: false),
                    HasToilet = table.Column<bool>(type: "bit", nullable: false),
                    BusManuFacturerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusModels", x => x.BusModelId);
                    table.ForeignKey(
                        name: "FK_BusModels_BusManuFacturers_BusManuFacturerId",
                        column: x => x.BusManuFacturerId,
                        principalTable: "BusManuFacturers",
                        principalColumn: "BusManuFacturerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "BusManuFacturers",
                columns: new[] { "BusManuFacturerId", "Name" },
                values: new object[,]
                {
                    { 1, "Mercedes" },
                    { 2, "Man" },
                    { 3, "Neoplan" },
                    { 4, "Isuzu" }
                });

            migrationBuilder.InsertData(
                table: "BusModels",
                columns: new[] { "BusModelId", "BusManuFacturerId", "BusModelName", "HasToilet", "SeatCapacity", "Type" },
                values: new object[,]
                {
                    { 1, 1, "Mercedess Travego2", true, 44, 2 },
                    { 3, 1, "Mercedess Travego1", false, 44, 2 },
                    { 2, 2, "Man-Fortuna", true, 0, 0 },
                    { 5, 2, "Man-Lions", true, 26, 1 },
                    { 4, 3, "Starliner", true, 44, 2 },
                    { 6, 4, "Citibus", true, 44, 2 },
                    { 7, 4, "Citimark", false, 52, 2 },
                    { 8, 4, "Novociti", true, 48, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BusModels_BusManuFacturerId",
                table: "BusModels",
                column: "BusManuFacturerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusModels");

            migrationBuilder.DropTable(
                name: "BusManuFacturers");
        }
    }
}
