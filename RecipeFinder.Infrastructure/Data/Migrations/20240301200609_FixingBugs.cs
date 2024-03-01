using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeFinder.Data.Migrations
{
    public partial class FixingBugs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RecipeId",
                table: "Comments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_RecipeId",
                table: "Comments",
                column: "RecipeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Recipes_RecipeId",
                table: "Comments",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Recipes_RecipeId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_RecipeId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "RecipeId",
                table: "Comments");
        }
    }
}
