using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeFinder.Data.Migrations
{
    public partial class AddingRecipeUsersTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RecipesUsers",
                columns: table => new
                {
                    RecipeId = table.Column<int>(type: "int", nullable: false, comment: "Recipe Identifier"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Maker Identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipesUsers", x => new { x.RecipeId, x.UserId });
                    table.ForeignKey(
                        name: "FK_RecipesUsers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipesUsers_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RecipesUsers_UserId",
                table: "RecipesUsers",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecipesUsers");

            migrationBuilder.CreateTable(
                name: "RecipesMakers",
                columns: table => new
                {
                    MakerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RecipeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipesMakers", x => new { x.MakerId, x.RecipeId });
                    table.ForeignKey(
                        name: "FK_RecipesMakers_AspNetUsers_MakerId",
                        column: x => x.MakerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipesMakers_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RecipesMakers_RecipeId",
                table: "RecipesMakers",
                column: "RecipeId");
        }
    }
}
