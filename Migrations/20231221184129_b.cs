using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hight_school_follow_up.Migrations
{
    /// <inheritdoc />
    public partial class b : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "courseid",
                table: "Addingmodel_1",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "gradeid",
                table: "Addingmodel_1",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "teacherid",
                table: "Addingmodel_1",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "courseid",
                table: "Addingmodel_1");

            migrationBuilder.DropColumn(
                name: "gradeid",
                table: "Addingmodel_1");

            migrationBuilder.DropColumn(
                name: "teacherid",
                table: "Addingmodel_1");
        }
    }
}
