using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeFinder.Data.Migrations
{
    public partial class SeedingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6fc8295b-2cad-4198-a29a-785e11c99e11", "AQAAAAEAACcQAAAAEIDJ+pZ2pSPgZYX7eZup9t3Io6rOVuRGSmFgphyOOlMSc3w1E11sHNRJTo1Oldl6PA==", "c1902cb7-f952-4c8e-8346-87d50d51f0bd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d2f97c48-8c8c-4f57-a71c-bf6342264cc0", "AQAAAAEAACcQAAAAECn+TdfOQhpANoq6+4B7+97OlxWP0yWB4NF/F6JKcsC+072+0eIBbGZs1r9TpdGcqg==", "bc5ceeaa-7c89-4106-a7df-0e5b8ba671ae" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "CategoryId", "CookId", "DifficultyId", "ImageUrl", "Instructions", "Name", "PostedOn", "PreparationTime" },
                values: new object[] { 1, 2, "dea12856-c198-4129-b3f3-b893d8395082", 2, "https://assets.kulinaria.bg/attachments/pictures-images/0000/1918/MAIN-vegetarianska-musaka.jpg?1431936459", "1. Preheat oven to 180°C.\r\n2. Slice potatoes & eggplants\r\n3. Heat olive oil. Cook onions until soft. Add ground beef, garlic, tomato paste, diced tomatoes, oregano, cinnamon, salt & pepper. Simmer.\r\n4. Fry potato slices until golden brown.\r\n5. Layer potatoes, eggplants, & meat mixture. Repeat layers.\r\n6. Whisk eggs & yogurt. Pour over meat.\r\n7. Bake at 180°C (350°F) for 45 minutes to 1 hour.\r\n8. Cool before serving. Enjoy!\r\n", "Musaka", new DateTime(2024, 3, 6, 12, 13, 36, 871, DateTimeKind.Local).AddTicks(1379), 60 });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "AuthorId", "Description", "PostedOn", "RecipeId", "Title" },
                values: new object[] { 1, "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e", "I made this musaka with your recipe and its awesome.", new DateTime(2024, 3, 6, 12, 13, 36, 830, DateTimeKind.Local).AddTicks(872), 1, "Very good Musaka!" });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name", "Quantity", "RecipeId", "Unit" },
                values: new object[] { 1, "Potato", 4.0, 1, "kg" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fbd57d35-e4b1-49ce-8e0d-1e67ea6d69b5", "AQAAAAEAACcQAAAAELv1MSK3WKYX45t+nT8ZzfRsi2N5+8i0VlTt9DRlY7ucjkP/eDR4NN4Xjkj5SamF9g==", "cc117c23-e0fe-49f2-8015-aa774fbaa06f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e55fe1d1-66c5-4be1-875c-648bd45b891f", "AQAAAAEAACcQAAAAEEfrntAEGnN7lwdB/S/PvPq3VmIid1EPH9RZtsxo2gC9iu1MXUtKZU4WfWNUhSfilQ==", "efeb11bb-f96f-4841-b019-60cdd87cc462" });
        }
    }
}
