using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeFinder.Data.Migrations
{
    public partial class ChangingDifficultiesConstants : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "IngredientComplexity",
                table: "Difficulties",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                comment: "The Ingredient Complexity",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldComment: "The Ingredient Complexity");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "IngredientComplexity",
                table: "Difficulties",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                comment: "The Ingredient Complexity",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldComment: "The Ingredient Complexity");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5d4ba034-e6dd-4832-8cda-7f6f43958f31", "AQAAAAEAACcQAAAAEIdnBRHGT9Ij41W0PS+1lat8pQWeFsATICy810VAC9/b/FnbHbwp9FfM1ffCQAJEDg==", "597a02c4-8ae1-47a1-9396-593f34913983" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1a4a8ed8-44d1-4cb6-abb2-cc9e59cb2cb3", "AQAAAAEAACcQAAAAEDscqALVm/Ymn6kLgQ79p1YxzRJayNUY9569F9DemdrAtUSYvQMY64Iv1K0lW4r+Og==", "3677265e-1a7d-4f7e-8a55-239867df673c" });
        }
    }
}
