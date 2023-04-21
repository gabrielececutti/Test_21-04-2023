using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtworksEntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artist",
                columns: table => new
                {
                    Id_Artist = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Artist__FB56A91037BAC086", x => x.Id_Artist);
                });

            migrationBuilder.CreateTable(
                name: "Character",
                columns: table => new
                {
                    Id_Character = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Characte__CDD73BE097DD29FB", x => x.Id_Character);
                });

            migrationBuilder.CreateTable(
                name: "Museum",
                columns: table => new
                {
                    Id_Museum = table.Column<int>(type: "int", nullable: false),
                    MuseumName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Museum__84BA05225CCC4267", x => x.Id_Museum);
                });

            migrationBuilder.CreateTable(
                name: "Artwork",
                columns: table => new
                {
                    Id_Artwork = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Id_Museum = table.Column<int>(type: "int", nullable: false),
                    Id_Artist = table.Column<int>(type: "int", nullable: false),
                    Id_Character = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Artwork__B99D1B3D4401A006", x => x.Id_Artwork);
                    table.ForeignKey(
                        name: "FK__Artwork__Id_Arti__2B3F6F97",
                        column: x => x.Id_Artist,
                        principalTable: "Artist",
                        principalColumn: "Id_Artist");
                    table.ForeignKey(
                        name: "FK__Artwork__Id_Char__2C3393D0",
                        column: x => x.Id_Character,
                        principalTable: "Character",
                        principalColumn: "Id_Character");
                    table.ForeignKey(
                        name: "FK__Artwork__Id_Muse__2A4B4B5E",
                        column: x => x.Id_Museum,
                        principalTable: "Museum",
                        principalColumn: "Id_Museum");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Artwork_Id_Artist",
                table: "Artwork",
                column: "Id_Artist");

            migrationBuilder.CreateIndex(
                name: "IX_Artwork_Id_Character",
                table: "Artwork",
                column: "Id_Character");

            migrationBuilder.CreateIndex(
                name: "IX_Artwork_Id_Museum",
                table: "Artwork",
                column: "Id_Museum");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Artwork");

            migrationBuilder.DropTable(
                name: "Artist");

            migrationBuilder.DropTable(
                name: "Character");

            migrationBuilder.DropTable(
                name: "Museum");
        }
    }
}
