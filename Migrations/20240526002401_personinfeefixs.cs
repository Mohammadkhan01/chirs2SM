using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BLOG.WEB.Migrations
{
    /// <inheritdoc />
    public partial class personinfeefixs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StudentName",
                table: "FeesHistory");

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "FeesHistory",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_FeesHistory_PersonId",
                table: "FeesHistory",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_FeesHistory_Person_PersonId",
                table: "FeesHistory",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FeesHistory_Person_PersonId",
                table: "FeesHistory");

            migrationBuilder.DropIndex(
                name: "IX_FeesHistory_PersonId",
                table: "FeesHistory");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "FeesHistory");

            migrationBuilder.AddColumn<string>(
                name: "StudentName",
                table: "FeesHistory",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
