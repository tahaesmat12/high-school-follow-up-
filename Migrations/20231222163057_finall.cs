using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hight_school_follow_up.Migrations
{
    /// <inheritdoc />
    public partial class finall : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "email",
                table: "Teachers",
                newName: "temail");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "temail",
                table: "Teachers",
                newName: "email");
        }
    }
}
