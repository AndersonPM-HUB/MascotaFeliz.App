using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MascotaFeliz.App.Persistencia.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Historias",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fechaInicial = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Historias", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apellidos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TarjetaProfesional = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "VisitasPyP",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fechaVisita = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Temperatura = table.Column<float>(type: "real", nullable: false),
                    Peso = table.Column<float>(type: "real", nullable: false),
                    FrecuenciaRespiratoria = table.Column<float>(type: "real", nullable: false),
                    FrecuenciaCardiaca = table.Column<float>(type: "real", nullable: false),
                    estadoAnimo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ID_Veterinario = table.Column<int>(type: "int", nullable: false),
                    recomendaciones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HistoriaID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisitasPyP", x => x.ID);
                    table.ForeignKey(
                        name: "FK_VisitasPyP_Historias_HistoriaID",
                        column: x => x.HistoriaID,
                        principalTable: "Historias",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Mascotas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    especie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    raza = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    propietarioID = table.Column<int>(type: "int", nullable: true),
                    veterinarioID = table.Column<int>(type: "int", nullable: true),
                    historiaID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mascotas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mascotas_Historias_historiaID",
                        column: x => x.historiaID,
                        principalTable: "Historias",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Mascotas_Personas_propietarioID",
                        column: x => x.propietarioID,
                        principalTable: "Personas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Mascotas_Personas_veterinarioID",
                        column: x => x.veterinarioID,
                        principalTable: "Personas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mascotas_historiaID",
                table: "Mascotas",
                column: "historiaID");

            migrationBuilder.CreateIndex(
                name: "IX_Mascotas_propietarioID",
                table: "Mascotas",
                column: "propietarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Mascotas_veterinarioID",
                table: "Mascotas",
                column: "veterinarioID");

            migrationBuilder.CreateIndex(
                name: "IX_VisitasPyP_HistoriaID",
                table: "VisitasPyP",
                column: "HistoriaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mascotas");

            migrationBuilder.DropTable(
                name: "VisitasPyP");

            migrationBuilder.DropTable(
                name: "Personas");

            migrationBuilder.DropTable(
                name: "Historias");
        }
    }
}
