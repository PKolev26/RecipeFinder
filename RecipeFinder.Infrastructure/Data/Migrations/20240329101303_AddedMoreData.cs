using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeFinder.Data.Migrations
{
    public partial class AddedMoreData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Unit",
                table: "Ingredients",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                comment: "The unit in which the ingredient is measured",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldComment: "The unit in which the ingredient is measured");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ebf70bff-4e63-4677-ba16-64594e18dff8", "AQAAAAEAACcQAAAAEIm887/rDHfyiXequMeEON6d7MMcPOzTC2HCIkM1bwF0dwMxXs/+IPvAOFdsI7UOfg==", "5e21c04a-657f-4341-8d09-6cbece29c3c7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1caf1fd8-eb43-46ee-bdcb-f3d10aa67724", "AQAAAAEAACcQAAAAEMNysn4c5110kfvvkZ9aUm6Oug05W8BvEkci8XKztvKmHV9NDO6GAxbjfJBB1f4olw==", "e355ce01-1054-401d-9252-365e96ee4b65" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "PostedOn", "Title" },
                values: new object[] { "I made this moussaka with your recipe and its awesome.", new DateTime(2024, 3, 29, 12, 13, 2, 251, DateTimeKind.Local).AddTicks(8427), "Very good Moussaka!" });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "potato");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "minced meat");

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Name", "PostedOn" },
                values: new object[] { "Moussaka", new DateTime(2024, 3, 29, 12, 13, 2, 287, DateTimeKind.Local).AddTicks(5018) });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "CategoryId", "CookId", "DifficultyId", "ImageUrl", "Instructions", "Name", "PostedOn", "PreparationTime" },
                values: new object[] { 2, 3, "dea12856-c198-4129-b3f3-b893d8395082", 1, "https://imagesvc.meredithcorp.io/v3/mm/image?url=https%3A%2F%2Fimages.media-allrecipes.com%2Fuserphotos%2F7929481.jpg&q=60&c=sc&poi=auto&orient=true&h=512", "Mix flour, milk, egg, butter, sugar, baking powder, and salt together.\r\n\r\nHeat a lightly oiled griddle over low heat. Scoop 1/4 cup batter onto the griddle and cook until top and edges are dry, 3 to 4 minutes. Flip and cook until lightly browned on the other side, 2 to 3 minutes. Repeat with remaining batter.", "Homemade Pancakes", new DateTime(2024, 3, 29, 12, 13, 2, 287, DateTimeKind.Local).AddTicks(5070), 35 });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name", "Quantity", "RecipeId", "Unit" },
                values: new object[,]
                {
                    { 3, "flour", 1.5m, 2, "cups" },
                    { 4, "milk", 1.75m, 2, "cups" },
                    { 5, "egg", 1m, 2, "count" },
                    { 6, "melted butter", 1m, 2, "cup" },
                    { 7, "white sugar", 1m, 2, "tablespoon" },
                    { 8, "baking powder", 2m, 2, "tablespoons" },
                    { 9, "salt", 1m, 2, "tablespoon" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AlterColumn<string>(
                name: "Unit",
                table: "Ingredients",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                comment: "The unit in which the ingredient is measured",
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25,
                oldComment: "The unit in which the ingredient is measured");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "25fa611a-c822-4833-b032-c6cfcb4d92ef", "AQAAAAEAACcQAAAAEMPZMOeaDg6qG8XhyCrSn3sIep5T+bRjilVmjpCDUt/352Z+EM1UYEu0buY4N3VF3A==", "1dff9817-81fc-45fa-88b6-68c0e51051f7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f36ab215-5430-467c-a1ad-d4f274f79bb8", "AQAAAAEAACcQAAAAEGQJj+8Td6aF0UOTYwRnXE39HtCJijb3F0SUHxCz5Q8M11DgaKEUzCiB489Fpmsywg==", "5c3c8018-bae9-47e2-90d5-31a0c3cc7ef7" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "PostedOn", "Title" },
                values: new object[] { "I made this musaka with your recipe and its awesome.", new DateTime(2024, 3, 17, 13, 20, 1, 597, DateTimeKind.Local).AddTicks(771), "Very good Musaka!" });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Potato");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Minced Meat");

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Name", "PostedOn" },
                values: new object[] { "Musaka", new DateTime(2024, 3, 17, 13, 20, 2, 326, DateTimeKind.Local).AddTicks(8322) });
        }
    }
}
