using Microsoft.EntityFrameworkCore.Migrations;

namespace DividendScanner.Migrations
{
    public partial class AddSectorTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SectorID",
                table: "Companies",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Sectors",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sectors", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Companies_SectorID",
                table: "Companies",
                column: "SectorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Sectors_SectorID",
                table: "Companies",
                column: "SectorID",
                principalTable: "Sectors",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Sectors_SectorID",
                table: "Companies");

            migrationBuilder.DropTable(
                name: "Sectors");

            migrationBuilder.DropIndex(
                name: "IX_Companies_SectorID",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "SectorID",
                table: "Companies");
        }
    }
}
