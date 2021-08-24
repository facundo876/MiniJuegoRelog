using Microsoft.EntityFrameworkCore.Migrations;

namespace MiniJuegoRelog.Migrations
{
    public partial class SegundaMigracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Participantes",
                table: "Participantes");

            migrationBuilder.RenameTable(
                name: "Participantes",
                newName: "PARTICIPANTES");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PARTICIPANTES",
                table: "PARTICIPANTES",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "TIEMPOS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "1, 1"),
                    Tiempo = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ParticipanteId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TIEMPOS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TIEMPOS_PARTICIPANTES_ParticipanteId",
                        column: x => x.ParticipanteId,
                        principalTable: "PARTICIPANTES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TIEMPOS_ParticipanteId",
                table: "TIEMPOS",
                column: "ParticipanteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TIEMPOS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PARTICIPANTES",
                table: "PARTICIPANTES");

            migrationBuilder.RenameTable(
                name: "PARTICIPANTES",
                newName: "Participantes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Participantes",
                table: "Participantes",
                column: "Id");
        }
    }
}
