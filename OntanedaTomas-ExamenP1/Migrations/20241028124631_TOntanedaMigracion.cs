using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OntanedaTomas_ExamenP1.Migrations
{
    /// <inheritdoc />
    public partial class TOntanedaMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Celular",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Modelo = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Anio = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Celular", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TOntaneda",
                columns: table => new
                {
                    IdCPU = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VelocidadCPU = table.Column<float>(type: "real", nullable: false),
                    Marca = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EstaOverclokeado = table.Column<bool>(type: "bit", nullable: false),
                    FechaObtencion = table.Column<DateOnly>(type: "date", nullable: false),
                    IdCelular = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TOntaneda", x => x.IdCPU);
                    table.ForeignKey(
                        name: "FK_TOntaneda_Celular_IdCelular",
                        column: x => x.IdCelular,
                        principalTable: "Celular",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TOntaneda_IdCelular",
                table: "TOntaneda",
                column: "IdCelular");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TOntaneda");

            migrationBuilder.DropTable(
                name: "Celular");
        }
    }
}
