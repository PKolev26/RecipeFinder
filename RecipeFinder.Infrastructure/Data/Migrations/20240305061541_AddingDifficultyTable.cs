using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeFinder.Data.Migrations
{
    public partial class AddingDifficultyTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DifficultyId",
                table: "Recipes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "The Recipe Difficulty Id");

            migrationBuilder.CreateTable(
                name: "Difficulties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "This Difficulty Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "The Difficulty Name"),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "The Difficulty Description"),
                    SkillLevel = table.Column<double>(type: "float", nullable: false, comment: "The recommended skill level that the cook should have"),
                    IngredientComplexity = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "The Ingredient Complexity")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Difficulties", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_DifficultyId",
                table: "Recipes",
                column: "DifficultyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_Difficulties_DifficultyId",
                table: "Recipes",
                column: "DifficultyId",
                principalTable: "Difficulties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_Difficulties_DifficultyId",
                table: "Recipes");

            migrationBuilder.DropTable(
                name: "Difficulties");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_DifficultyId",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "DifficultyId",
                table: "Recipes");
        }
    }
}
