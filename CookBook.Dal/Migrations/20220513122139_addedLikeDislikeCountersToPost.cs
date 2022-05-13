using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CookBook.Dal.Migrations
{
    public partial class addedLikeDislikeCountersToPost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Liked",
                table: "Posts",
                newName: "LikeCounter");

            migrationBuilder.AddColumn<int>(
                name: "DislikeCunter",
                table: "Posts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DislikeCunter",
                table: "Posts");

            migrationBuilder.RenameColumn(
                name: "LikeCounter",
                table: "Posts",
                newName: "Liked");
        }
    }
}
