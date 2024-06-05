using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SWD.SmartThrive.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class FixNameTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Sesion",
                table: "Sesion");

            migrationBuilder.RenameTable(
                name: "Sesion",
                newName: "Session");

            migrationBuilder.RenameIndex(
                name: "IX_Sesion_CourseId",
                table: "Session",
                newName: "IX_Session_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Session",
                table: "Session",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Session",
                table: "Session");

            migrationBuilder.RenameTable(
                name: "Session",
                newName: "Sesion");

            migrationBuilder.RenameIndex(
                name: "IX_Session_CourseId",
                table: "Sesion",
                newName: "IX_Sesion_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sesion",
                table: "Sesion",
                column: "Id");
        }
    }
}
