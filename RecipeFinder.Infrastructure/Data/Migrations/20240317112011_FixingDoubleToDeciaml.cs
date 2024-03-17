using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeFinder.Data.Migrations
{
    public partial class FixingDoubleToDeciaml : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Quantity",
                table: "Ingredients",
                type: "decimal(18,2)",
                nullable: false,
                comment: "The Ingredient Quantity",
                oldClrType: typeof(double),
                oldType: "float",
                oldComment: "The Ingredient Quantity");

            migrationBuilder.AlterColumn<decimal>(
                name: "SkillLevel",
                table: "Difficulties",
                type: "decimal(18,2)",
                nullable: false,
                comment: "The recommended skill level that the cook should have",
                oldClrType: typeof(double),
                oldType: "float",
                oldComment: "The recommended skill level that the cook should have");

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
                column: "PostedOn",
                value: new DateTime(2024, 3, 17, 13, 20, 1, 597, DateTimeKind.Local).AddTicks(771));

            migrationBuilder.UpdateData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: 1,
                column: "SkillLevel",
                value: 1m);

            migrationBuilder.UpdateData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: 2,
                column: "SkillLevel",
                value: 3m);

            migrationBuilder.UpdateData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: 3,
                column: "SkillLevel",
                value: 5m);

            migrationBuilder.UpdateData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: 4,
                column: "SkillLevel",
                value: 7m);

            migrationBuilder.UpdateData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: 5,
                column: "SkillLevel",
                value: 9m);

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 1,
                column: "Quantity",
                value: 4m);

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 2,
                column: "Quantity",
                value: 3m);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 1,
                column: "PostedOn",
                value: new DateTime(2024, 3, 17, 13, 20, 2, 326, DateTimeKind.Local).AddTicks(8322));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Quantity",
                table: "Ingredients",
                type: "float",
                nullable: false,
                comment: "The Ingredient Quantity",
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldComment: "The Ingredient Quantity");

            migrationBuilder.AlterColumn<double>(
                name: "SkillLevel",
                table: "Difficulties",
                type: "float",
                nullable: false,
                comment: "The recommended skill level that the cook should have",
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldComment: "The recommended skill level that the cook should have");

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

            migrationBuilder.UpdateData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: 1,
                column: "SkillLevel",
                value: 1.0);

            migrationBuilder.UpdateData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: 2,
                column: "SkillLevel",
                value: 3.0);

            migrationBuilder.UpdateData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: 3,
                column: "SkillLevel",
                value: 5.0);

            migrationBuilder.UpdateData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: 4,
                column: "SkillLevel",
                value: 7.0);

            migrationBuilder.UpdateData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: 5,
                column: "SkillLevel",
                value: 9.0);

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 1,
                column: "Quantity",
                value: 4.0);

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 2,
                column: "Quantity",
                value: 3.0);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 1,
                column: "PostedOn",
                value: new DateTime(2024, 3, 6, 12, 44, 5, 984, DateTimeKind.Local).AddTicks(3676));
        }
    }
}
