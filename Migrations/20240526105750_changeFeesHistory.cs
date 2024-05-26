using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BLOG.WEB.Migrations
{
    /// <inheritdoc />
    public partial class changeFeesHistory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FeesHistory_Fees_FeesId",
                table: "FeesHistory");

            migrationBuilder.DropIndex(
                name: "IX_FeesHistory_FeesId",
                table: "FeesHistory");

            migrationBuilder.DropColumn(
                name: "FeesId",
                table: "FeesHistory");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FeesId",
                table: "FeesHistory",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_FeesHistory_FeesId",
                table: "FeesHistory",
                column: "FeesId");

            migrationBuilder.AddForeignKey(
                name: "FK_FeesHistory_Fees_FeesId",
                table: "FeesHistory",
                column: "FeesId",
                principalTable: "Fees",
                principalColumn: "FeesId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
