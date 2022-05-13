using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CookBook.Dal.Migrations
{
    public partial class updatedPostEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Liked",
                table: "Posts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Liked",
                table: "Posts");
        }
    }
}
