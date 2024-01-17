using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace entity_framwork_intro.Migrations
{
    /// <inheritdoc />
    public partial class DoubleChecking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Titel",
                table: "Posts",
                newName: "Title");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Posts",
                newName: "Titel");
        }
    }
}
