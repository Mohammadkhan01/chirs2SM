using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BLOG.WEB.Migrations
{
    /// <inheritdoc />
    public partial class Fees : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FeesHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalFees = table.Column<double>(type: "float", nullable: false),
                    TransportFees = table.Column<double>(type: "float", nullable: false),
                    TotalDue = table.Column<double>(type: "float", nullable: false),
                    RollNumber = table.Column<int>(type: "int", nullable: false),
                    Feespaid = table.Column<bool>(type: "bit", nullable: false),
                    TransportFesspaid = table.Column<bool>(type: "bit", nullable: false),
                    ClassName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeesHistory", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FeesHistory");
        }
    }
}
