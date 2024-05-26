using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BLOG.WEB.Migrations
{
    /// <inheritdoc />
    public partial class FeeCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fees_ClassName_ClassNameId",
                table: "Fees");

            migrationBuilder.DropForeignKey(
                name: "FK_Fees_Person_PersonId",
                table: "Fees");

            migrationBuilder.DropIndex(
                name: "IX_Fees_ClassNameId",
                table: "Fees");

            migrationBuilder.DropIndex(
                name: "IX_Fees_PersonId",
                table: "Fees");

            migrationBuilder.DropColumn(
                name: "ClassNameId",
                table: "Fees");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "Fees");

            migrationBuilder.AddColumn<string>(
                name: "FeesPurpose",
                table: "Fees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FeesType",
                table: "Fees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "MonthlyPay",
                table: "Fees",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FeesPurpose",
                table: "Fees");

            migrationBuilder.DropColumn(
                name: "FeesType",
                table: "Fees");

            migrationBuilder.DropColumn(
                name: "MonthlyPay",
                table: "Fees");

            migrationBuilder.AddColumn<int>(
                name: "ClassNameId",
                table: "Fees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "Fees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Fees_ClassNameId",
                table: "Fees",
                column: "ClassNameId");

            migrationBuilder.CreateIndex(
                name: "IX_Fees_PersonId",
                table: "Fees",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fees_ClassName_ClassNameId",
                table: "Fees",
                column: "ClassNameId",
                principalTable: "ClassName",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Fees_Person_PersonId",
                table: "Fees",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
