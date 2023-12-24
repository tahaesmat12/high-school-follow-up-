using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hight_school_follow_up.Migrations
{
    /// <inheritdoc />
    public partial class tahaa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "phonenumberr",
                table: "Teachers",
                newName: "phonenumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "phonenumber",
                table: "Teachers",
                newName: "phonenumberr");
        }
    }
}
