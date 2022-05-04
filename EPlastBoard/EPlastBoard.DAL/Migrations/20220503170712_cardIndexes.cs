using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EPlastBoard.DAL.Migrations
{
    public partial class cardIndexes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Index",
                table: "Cards",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Index",
                table: "Cards");
        }
    }
}
