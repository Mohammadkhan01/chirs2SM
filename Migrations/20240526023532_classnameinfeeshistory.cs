using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BLOG.WEB.Migrations
{
    /// <inheritdoc />
    public partial class classnameinfeeshistory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendance_ClassName_ClassNameId",
                table: "Attendance");

            migrationBuilder.DropForeignKey(
                name: "FK_Subject_ClassName_ClassNameId",
                table: "Subject");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClassName",
                table: "ClassName");

            migrationBuilder.DropColumn(
                name: "ClassName",
                table: "FeesHistory");

            migrationBuilder.RenameTable(
                name: "ClassName",
                newName: "ClassNames");

            migrationBuilder.AddColumn<int>(
                name: "ClassNameId",
                table: "FeesHistory",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClassNames",
                table: "ClassNames",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_FeesHistory_ClassNameId",
                table: "FeesHistory",
                column: "ClassNameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendance_ClassNames_ClassNameId",
                table: "Attendance",
                column: "ClassNameId",
                principalTable: "ClassNames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FeesHistory_ClassNames_ClassNameId",
                table: "FeesHistory",
                column: "ClassNameId",
                principalTable: "ClassNames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subject_ClassNames_ClassNameId",
                table: "Subject",
                column: "ClassNameId",
                principalTable: "ClassNames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendance_ClassNames_ClassNameId",
                table: "Attendance");

            migrationBuilder.DropForeignKey(
                name: "FK_FeesHistory_ClassNames_ClassNameId",
                table: "FeesHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_Subject_ClassNames_ClassNameId",
                table: "Subject");

            migrationBuilder.DropIndex(
                name: "IX_FeesHistory_ClassNameId",
                table: "FeesHistory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClassNames",
                table: "ClassNames");

            migrationBuilder.DropColumn(
                name: "ClassNameId",
                table: "FeesHistory");

            migrationBuilder.RenameTable(
                name: "ClassNames",
                newName: "ClassName");

            migrationBuilder.AddColumn<string>(
                name: "ClassName",
                table: "FeesHistory",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClassName",
                table: "ClassName",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendance_ClassName_ClassNameId",
                table: "Attendance",
                column: "ClassNameId",
                principalTable: "ClassName",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subject_ClassName_ClassNameId",
                table: "Subject",
                column: "ClassNameId",
                principalTable: "ClassName",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
