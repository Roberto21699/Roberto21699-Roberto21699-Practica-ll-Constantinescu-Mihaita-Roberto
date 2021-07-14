using Microsoft.EntityFrameworkCore.Migrations;

namespace Restaurant.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produse",
                columns: table => new
                {
                    ProdusId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Denumire = table.Column<string>(nullable: true),
                    Pret = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produse", x => x.ProdusId);
                });

            migrationBuilder.CreateTable(
                name: "Roluri",
                columns: table => new
                {
                    RolId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tip = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roluri", x => x.RolId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(nullable: true),
                    Prenume = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    Parola = table.Column<string>(nullable: true),
                    RolId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Roluri_RolId",
                        column: x => x.RolId,
                        principalTable: "Roluri",
                        principalColumn: "RolId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comenzi",
                columns: table => new
                {
                    ComandaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comenzi", x => x.ComandaId);
                    table.ForeignKey(
                        name: "FK_Comenzi_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Note",
                columns: table => new
                {
                    NotaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<string>(nullable: true),
                    Total = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Note", x => x.NotaId);
                    table.ForeignKey(
                        name: "FK_Note_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rezervari",
                columns: table => new
                {
                    RezervareId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NrPersoane = table.Column<int>(nullable: false),
                    Data = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezervari", x => x.RezervareId);
                    table.ForeignKey(
                        name: "FK_Rezervari_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetaliiComenzi",
                columns: table => new
                {
                    ProdusId = table.Column<int>(nullable: false),
                    ComandaId = table.Column<int>(nullable: false),
                    Cantitate = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetaliiComenzi", x => new { x.ProdusId, x.ComandaId });
                    table.ForeignKey(
                        name: "FK_DetaliiComenzi_Comenzi_ComandaId",
                        column: x => x.ComandaId,
                        principalTable: "Comenzi",
                        principalColumn: "ComandaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetaliiComenzi_Produse_ProdusId",
                        column: x => x.ProdusId,
                        principalTable: "Produse",
                        principalColumn: "ProdusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comenzi_UserId",
                table: "Comenzi",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_DetaliiComenzi_ComandaId",
                table: "DetaliiComenzi",
                column: "ComandaId");

            migrationBuilder.CreateIndex(
                name: "IX_Note_UserId",
                table: "Note",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervari_UserId",
                table: "Rezervari",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RolId",
                table: "Users",
                column: "RolId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetaliiComenzi");

            migrationBuilder.DropTable(
                name: "Note");

            migrationBuilder.DropTable(
                name: "Rezervari");

            migrationBuilder.DropTable(
                name: "Comenzi");

            migrationBuilder.DropTable(
                name: "Produse");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roluri");
        }
    }
}
