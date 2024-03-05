using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeFinder.Data.Migrations
{
    public partial class SeedDifficultiesAndCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2583110c-12bc-4fec-b931-db358942fbe2", "AQAAAAEAACcQAAAAEH1fRuVGHlXVQNI/i7bI5FzgKDcuhVNtVjn3xzEcyDYGwk2n2jf8teonSf9Di7WpJg==", "9cbd859b-e5a4-433c-b18b-d9a8cacb9b39" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0db673b5-4512-4034-a57f-bb21086da0f3", "AQAAAAEAACcQAAAAEDX2ziSt1YRHoOnR0cNunJ5aStCB1wT0JKQnfnfxMtggtN7U01ZTSEZEZ1Q+PDW4/A==", "bf460d8f-b83a-4180-b892-58afb174c1e3" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Appetizer" },
                    { 2, "Main Course" },
                    { 3, "Dessert" }
                });

            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Description", "IngredientComplexity", "Name", "SkillLevel" },
                values: new object[,]
                {
                    { 1, "Recipes suitable for novice cooks with basic cooking skills.", "Common ingredients.", "Beginner", 1.0 },
                    { 2, "Recipes requiring some cooking experience and familiarity with various cooking techniques.", "Mix of common and some specialty ingredients.", "Intermediate", 3.0 },
                    { 3, "Recipes suitable for experienced cooks with confidence in their cooking skills.", "Primarily specialty ingredients.", "Advanced", 5.0 },
                    { 4, "Highly challenging recipes requiring expert-level cooking skills and experience.", "Rare or exotic ingredients.", "Expert", 7.0 },
                    { 5, "Culinary creations for professionals or exceptionally skilled home cooks.", "Varied, may include rare, seasonal, or hard-to-find ingredients.", "Master Chef", 9.0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6e80cf53-6cf3-4cd8-8d18-25aeb09093a5", "AQAAAAEAACcQAAAAELd1LFhBwfGQWe+HDtXIvdg5MHZHbaSzdJSF9686EpXFZeHxAJO/JzducbmUEApE5Q==", "3aebedd0-f080-449e-aeb4-9f019702d599" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5e593c05-5c08-484d-bcf2-4fe25793a00a", "AQAAAAEAACcQAAAAEEU+zZsgztuqwuDO2poELe6ccA+OVA2ohsGpPxSChS6gJRlh/KD0Uk286wlntQgv2A==", "4e1a4108-4f5c-4861-950a-da5840f0e953" });
        }
    }
}
