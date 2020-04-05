using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class TeacherModelEdit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TeacherStatus",
                table: "Teachers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<short>(
                name: "TeacherStatus",
                table: "Teachers",
                nullable: false,
                defaultValue: (short)0);
        }
    }
}
