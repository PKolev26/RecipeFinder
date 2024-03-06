using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeFinder.Data.Migrations
{
    public partial class FinalizingDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "RecipeId",
                table: "Ingredients",
                type: "int",
                nullable: false,
                comment: "Recipe Identifier",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "RecipeId",
                table: "Comments",
                type: "int",
                nullable: false,
                comment: "Recipe Identifier",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "55b3ed9e-d896-45fb-8527-d126cf4e2863", "AQAAAAEAACcQAAAAEEsmRmCRzlQ9+1EgRpQLclTwraE1bBX3ccZ3QMURxf8A2oSeDCaT+JiKM6jG6tjVgA==", "6fddc879-1bc8-4044-860c-e2159a1ea24c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b061f59c-e4f3-422b-8ae1-34ed66061a8b", "AQAAAAEAACcQAAAAEL0D8C+xgOUJMI44BEneTpHL5xGdry8u7wJzd4lhFbIMEEbiv11px4IMK51A0H6Omw==", "3e0a5a7f-4266-491d-9801-e6b0165cd4cc" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "PostedOn",
                value: new DateTime(2024, 3, 6, 12, 44, 5, 938, DateTimeKind.Local).AddTicks(2969));

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name", "Quantity", "RecipeId", "Unit" },
                values: new object[] { 2, "Minced Meat", 3.0, 1, "kg" });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 1,
                column: "PostedOn",
                value: new DateTime(2024, 3, 6, 12, 44, 5, 984, DateTimeKind.Local).AddTicks(3676));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AlterColumn<int>(
                name: "RecipeId",
                table: "Ingredients",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Recipe Identifier");

            migrationBuilder.AlterColumn<int>(
                name: "RecipeId",
                table: "Comments",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Recipe Identifier");

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

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "PostedOn",
                value: new DateTime(2024, 3, 6, 12, 13, 36, 830, DateTimeKind.Local).AddTicks(872));

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 1,
                column: "PostedOn",
                value: new DateTime(2024, 3, 6, 12, 13, 36, 871, DateTimeKind.Local).AddTicks(1379));
        }
    }
}
