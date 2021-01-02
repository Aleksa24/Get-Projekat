using Microsoft.EntityFrameworkCore.Migrations;

namespace Get_Projekat.Migrations
{
    public partial class InitialMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Studenti",
                columns: table => new
                {
                    BrojIndeksa = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adresa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Grad = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studenti", x => x.BrojIndeksa);
                });

            migrationBuilder.CreateTable(
                name: "Ispiti",
                columns: table => new
                {
                    BrojIndeksa = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PredmetId = table.Column<long>(type: "bigint", nullable: false),
                    Ocena = table.Column<short>(type: "smallint", nullable: false),
                    StudentBrojIndeksa = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ispiti", x => new { x.BrojIndeksa, x.PredmetId });
                    table.ForeignKey(
                        name: "FK_Ispiti_Studenti_StudentBrojIndeksa",
                        column: x => x.StudentBrojIndeksa,
                        principalTable: "Studenti",
                        principalColumn: "BrojIndeksa",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ispiti_StudentBrojIndeksa",
                table: "Ispiti",
                column: "StudentBrojIndeksa");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ispiti");

            migrationBuilder.DropTable(
                name: "Studenti");
        }
    }
}
