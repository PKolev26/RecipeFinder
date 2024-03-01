using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeFinder.Data.Migrations
{
    public partial class AddingRecipesIngredientsCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "This Category Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false, comment: "The Category Name")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "The Recipe Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "The Recipe Name"),
                    Instructions = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false, comment: "The Recipe Instructions"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "The Recipe Cover Image"),
                    PreparationTime = table.Column<int>(type: "int", nullable: false, comment: "The Recipe Preparation Time"),
                    PostedOn = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date of post"),
                    CategoryId = table.Column<int>(type: "int", nullable: false, comment: "The Recipe Category Id"),
                    CookId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "The Cook Identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recipes_AspNetUsers_CookId",
                        column: x => x.CookId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Recipes_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "The Ingredient Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "The Ingredient Name"),
                    Quantity = table.Column<double>(type: "float", nullable: false, comment: "The Ingredient Quantity"),
                    Unit = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false, comment: "The unit in which the ingredient is measured"),
                    RecipeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ingredients_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_RecipeId",
                table: "Ingredients",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_CategoryId",
                table: "Recipes",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_CookId",
                table: "Recipes",
                column: "CookId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "Recipes");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
