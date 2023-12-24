using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hight_school_follow_up.Migrations
{
    /// <inheritdoc />
    public partial class o : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeacherCourses_Courses_courseid1",
                table: "TeacherCourses");

            migrationBuilder.DropIndex(
                name: "IX_TeacherCourses_courseid1",
                table: "TeacherCourses");

            migrationBuilder.DropColumn(
                name: "courseid1",
                table: "TeacherCourses");

            migrationBuilder.AlterColumn<string>(
                name: "password",
                table: "Parents",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<byte[]>(
                name: "parentimage",
                table: "Parents",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Parents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Parents");

            migrationBuilder.AddColumn<int>(
                name: "courseid1",
                table: "TeacherCourses",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "password",
                table: "Parents",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(60)",
                oldMaxLength: 60);

            migrationBuilder.AlterColumn<byte[]>(
                name: "parentimage",
                table: "Parents",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherCourses_courseid1",
                table: "TeacherCourses",
                column: "courseid1");

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherCourses_Courses_courseid1",
                table: "TeacherCourses",
                column: "courseid1",
                principalTable: "Courses",
                principalColumn: "courseid");
        }
    }
}
