using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TeacherControlWPF.Migrations
{
    public partial class Tablas_Faltantes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FechaIngreso",
                table: "Estudiantes",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<float>(
                name: "PuntosExtra",
                table: "Estudiantes",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.CreateTable(
                name: "Adicionales",
                columns: table => new
                {
                    AdicionalId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha = table.Column<DateTime>(nullable: false),
                    EstudianteId = table.Column<int>(nullable: false),
                    Puntos = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adicionales", x => x.AdicionalId);
                });

            migrationBuilder.CreateTable(
                name: "Tareas",
                columns: table => new
                {
                    TareaId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Descripcion = table.Column<string>(nullable: true),
                    Puntos = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tareas", x => x.TareaId);
                });

            migrationBuilder.CreateTable(
                name: "TareasDetalle",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TareaId = table.Column<int>(nullable: false),
                    Requerimiento = table.Column<string>(nullable: true),
                    Valor = table.Column<float>(nullable: false),
                    TareasTareaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TareasDetalle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TareasDetalle_Tareas_TareasTareaId",
                        column: x => x.TareasTareaId,
                        principalTable: "Tareas",
                        principalColumn: "TareaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TareasDetalle_TareasTareaId",
                table: "TareasDetalle",
                column: "TareasTareaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adicionales");

            migrationBuilder.DropTable(
                name: "TareasDetalle");

            migrationBuilder.DropTable(
                name: "Tareas");

            migrationBuilder.DropColumn(
                name: "FechaIngreso",
                table: "Estudiantes");

            migrationBuilder.DropColumn(
                name: "PuntosExtra",
                table: "Estudiantes");
        }
    }
}
