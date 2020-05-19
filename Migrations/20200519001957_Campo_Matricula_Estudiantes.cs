using Microsoft.EntityFrameworkCore.Migrations;

namespace TeacherControlWPF.Migrations
{
    public partial class Campo_Matricula_Estudiantes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Matricula",
                table: "Estudiantes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Matricula",
                table: "Estudiantes");
        }
    }
}
