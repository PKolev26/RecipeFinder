using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeFinder.Data.Migrations
{
    public partial class AddingMakerTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipesMakers_AspNetUsers_MakerId",
                table: "RecipesMakers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecipesMakers",
                table: "RecipesMakers");

            migrationBuilder.DropIndex(
                name: "IX_RecipesMakers_RecipeId",
                table: "RecipesMakers");

            migrationBuilder.AlterColumn<int>(
                name: "MakerId",
                table: "RecipesMakers",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecipesMakers",
                table: "RecipesMakers",
                columns: new[] { "RecipeId", "MakerId" });

            migrationBuilder.CreateTable(
                name: "Makers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Maker Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "User Identifier"),
                    SkillLevel = table.Column<double>(type: "float", nullable: false, comment: "The skill level that the cook have")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Makers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Makers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RecipesMakers_MakerId",
                table: "RecipesMakers",
                column: "MakerId");

            migrationBuilder.CreateIndex(
                name: "IX_Makers_UserId",
                table: "Makers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipesMakers_Makers_MakerId",
                table: "RecipesMakers",
                column: "MakerId",
                principalTable: "Makers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipesMakers_Makers_MakerId",
                table: "RecipesMakers");

            migrationBuilder.DropTable(
                name: "Makers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecipesMakers",
                table: "RecipesMakers");

            migrationBuilder.DropIndex(
                name: "IX_RecipesMakers_MakerId",
                table: "RecipesMakers");

            migrationBuilder.AlterColumn<string>(
                name: "MakerId",
                table: "RecipesMakers",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecipesMakers",
                table: "RecipesMakers",
                columns: new[] { "MakerId", "RecipeId" });

            migrationBuilder.CreateIndex(
                name: "IX_RecipesMakers_RecipeId",
                table: "RecipesMakers",
                column: "RecipeId");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipesMakers_AspNetUsers_MakerId",
                table: "RecipesMakers",
                column: "MakerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
