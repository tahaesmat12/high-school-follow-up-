using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hight_school_follow_up.Migrations
{
    /// <inheritdoc />
    public partial class taha : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addingmodel_1");

            migrationBuilder.AlterColumn<string>(
                name: "coursename",
                table: "Courses",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "coursename",
                table: "Courses",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.CreateTable(
                name: "Addingmodel_1",
                columns: table => new
                {
                    behaviour = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    courseid = table.Column<int>(type: "int", nullable: false),
                    coursename = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    grade = table.Column<int>(type: "int", nullable: false),
                    gradeid = table.Column<int>(type: "int", nullable: false),
                    level = table.Column<int>(type: "int", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phonenumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    studentid = table.Column<int>(type: "int", nullable: false),
                    studentname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    teacherid = table.Column<int>(type: "int", nullable: false),
                    teachername = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                });
        }
    }
}
