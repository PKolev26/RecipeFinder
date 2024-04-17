using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeFinder.Data.Migrations
{
    public partial class FixedUserProfilePicture : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "71baea75-6e3f-4fe7-8f34-2f9b3ca7a341", "AQAAAAEAACcQAAAAEBGfmPWcmFEd1VjgWlLkTKQo1MrqNxvm7XkvST8AFSZ5i0c/c2idghJijNMzSKMNiA==", "194f3127-f1ad-4899-bc8b-e2cd6f6d10b5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8acdd283-300d-4ef1-a83f-813efc164767",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e40c173d-1aea-4e84-b5aa-020b4e6df7b3", "AQAAAAEAACcQAAAAEJ0AWWt0r0n8cTVrtlZEABw/b+W3jheq4JmuTkaBssgJPGdwsRs4Mdma9WQnsffNvg==", "7b0f0221-97c8-48f0-af8e-0c773f2996f7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "ProfilePicture", "SecurityStamp" },
                values: new object[] { "1485c628-5ab0-4ab5-8a94-24f37f7c3360", "AQAAAAEAACcQAAAAEPA8ZApyElWuQ+n5ogNGvIH8hzaG3fJUsYiIFBfu2aM3U3rmblIt+cyy3ouoqoYtGg==", "https://p7.hiclipart.com/preview/355/848/997/computer-icons-user-profile-google-account-photos-icon-account.jpg", "ef6aca6d-9ab9-40dd-9a48-a0cf502b13fa" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "PostedOn",
                value: new DateTime(2024, 4, 17, 16, 5, 29, 998, DateTimeKind.Local).AddTicks(1997));

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 3,
                column: "PostedOn",
                value: new DateTime(2024, 4, 17, 16, 5, 30, 4, DateTimeKind.Local).AddTicks(5058));

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 4,
                column: "PostedOn",
                value: new DateTime(2024, 4, 17, 16, 5, 30, 4, DateTimeKind.Local).AddTicks(5075));

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 5,
                column: "PostedOn",
                value: new DateTime(2024, 4, 17, 16, 5, 30, 4, DateTimeKind.Local).AddTicks(5080));

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 6,
                column: "PostedOn",
                value: new DateTime(2024, 4, 17, 16, 5, 30, 4, DateTimeKind.Local).AddTicks(5084));

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 7,
                column: "PostedOn",
                value: new DateTime(2024, 4, 17, 16, 5, 30, 4, DateTimeKind.Local).AddTicks(5087));

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 8,
                column: "PostedOn",
                value: new DateTime(2024, 4, 17, 16, 5, 30, 4, DateTimeKind.Local).AddTicks(5138));

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 9,
                column: "PostedOn",
                value: new DateTime(2024, 4, 17, 16, 5, 30, 4, DateTimeKind.Local).AddTicks(5142));

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 10,
                column: "PostedOn",
                value: new DateTime(2024, 4, 17, 16, 5, 30, 4, DateTimeKind.Local).AddTicks(5145));

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 11,
                column: "PostedOn",
                value: new DateTime(2024, 4, 17, 16, 5, 30, 4, DateTimeKind.Local).AddTicks(5148));

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 12,
                column: "PostedOn",
                value: new DateTime(2024, 4, 17, 16, 5, 30, 4, DateTimeKind.Local).AddTicks(5152));

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 13,
                column: "PostedOn",
                value: new DateTime(2024, 4, 17, 16, 5, 30, 4, DateTimeKind.Local).AddTicks(5155));

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 14,
                column: "PostedOn",
                value: new DateTime(2024, 4, 17, 16, 5, 30, 4, DateTimeKind.Local).AddTicks(5158));

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 15,
                column: "PostedOn",
                value: new DateTime(2024, 4, 17, 16, 5, 30, 4, DateTimeKind.Local).AddTicks(5161));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a95a2a15-12cc-4567-9cfb-eeaa67294b07", "AQAAAAEAACcQAAAAEF/ATRWMCVXYuXoI6jeKvG8p+fxwsswjnonIF0QTHcbYB1cwEERjdTc3aFty7qX2MA==", "1c6dc899-c0a3-44f8-934e-6790d27de1a8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8acdd283-300d-4ef1-a83f-813efc164767",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8f44e95e-21b7-43aa-a0db-6a3e60a2073d", "AQAAAAEAACcQAAAAENnTs+RB+TQx6rULyVHvqsPoOsejParYdwhEKSK7Hoih+YAJfss99w6RhO49OZrLNQ==", "60fc04fe-0926-4f24-bff4-e3b762b68ccb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "ProfilePicture", "SecurityStamp" },
                values: new object[] { "96b3fbf0-484b-4bfb-9e5e-79c94246503f", "AQAAAAEAACcQAAAAEMlbXyvAuCWqGNMN53YePmCKpNut+HEKmuwPdlBZ3q/hWeUyjdus+nUasLjo9Vzsew==", "", "b136088e-3762-4765-82c8-b8bdb5a1c8f4" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "PostedOn",
                value: new DateTime(2024, 4, 17, 12, 46, 48, 513, DateTimeKind.Local).AddTicks(8737));

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 3,
                column: "PostedOn",
                value: new DateTime(2024, 4, 17, 12, 46, 48, 562, DateTimeKind.Local).AddTicks(1767));

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 4,
                column: "PostedOn",
                value: new DateTime(2024, 4, 17, 12, 46, 48, 562, DateTimeKind.Local).AddTicks(1808));

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 5,
                column: "PostedOn",
                value: new DateTime(2024, 4, 17, 12, 46, 48, 562, DateTimeKind.Local).AddTicks(1813));

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 6,
                column: "PostedOn",
                value: new DateTime(2024, 4, 17, 12, 46, 48, 562, DateTimeKind.Local).AddTicks(1817));

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 7,
                column: "PostedOn",
                value: new DateTime(2024, 4, 17, 12, 46, 48, 562, DateTimeKind.Local).AddTicks(1821));

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 8,
                column: "PostedOn",
                value: new DateTime(2024, 4, 17, 12, 46, 48, 562, DateTimeKind.Local).AddTicks(1825));

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 9,
                column: "PostedOn",
                value: new DateTime(2024, 4, 17, 12, 46, 48, 562, DateTimeKind.Local).AddTicks(1829));

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 10,
                column: "PostedOn",
                value: new DateTime(2024, 4, 17, 12, 46, 48, 562, DateTimeKind.Local).AddTicks(1833));

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 11,
                column: "PostedOn",
                value: new DateTime(2024, 4, 17, 12, 46, 48, 562, DateTimeKind.Local).AddTicks(1837));

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 12,
                column: "PostedOn",
                value: new DateTime(2024, 4, 17, 12, 46, 48, 562, DateTimeKind.Local).AddTicks(1841));

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 13,
                column: "PostedOn",
                value: new DateTime(2024, 4, 17, 12, 46, 48, 562, DateTimeKind.Local).AddTicks(1844));

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 14,
                column: "PostedOn",
                value: new DateTime(2024, 4, 17, 12, 46, 48, 562, DateTimeKind.Local).AddTicks(1949));

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 15,
                column: "PostedOn",
                value: new DateTime(2024, 4, 17, 12, 46, 48, 562, DateTimeKind.Local).AddTicks(1955));
        }
    }
}
