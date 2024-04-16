using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeFinder.Data.Migrations
{
    public partial class AddedProfilePictureDefaultValue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c0681ae3-37aa-4692-9e2b-9c363176c638", "AQAAAAEAACcQAAAAECHmkUhG7s9Tap0gJwd2JDcngMHfL7jOXFbEOVLqHL+lUIVokewNW0BfS+BEZwJobA==", "bd167cdb-277d-47d0-a71d-eb30d6eb2ad0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8acdd283-300d-4ef1-a83f-813efc164767",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cc6faa78-984f-41a1-b330-33fdf1738f2c", "AQAAAAEAACcQAAAAEPDDN6uhgWGD2+1HMckAdOhAkumjijMOtrfh3rRihKlK0fIXA20Vys7ffidWrHYHaQ==", "7cd18bdf-9108-4115-8f13-811ea0a2a2ba" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "ProfilePicture", "SecurityStamp" },
                values: new object[] { "a98167b1-abab-4d99-b410-772bc4392c89", "AQAAAAEAACcQAAAAEONIB6blVvMsmzOdqS1OmxU5J/A33D4iuyxDY62Tak9Bxk7mkfWeJsW+J4afKN4NGw==", "", "66f39047-2dd6-4e66-84fb-7ca54c10fc37" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "PostedOn",
                value: new DateTime(2024, 4, 16, 17, 21, 55, 564, DateTimeKind.Local).AddTicks(8615));

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 1,
                column: "PostedOn",
                value: new DateTime(2024, 4, 16, 17, 21, 55, 571, DateTimeKind.Local).AddTicks(111));

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 2,
                column: "PostedOn",
                value: new DateTime(2024, 4, 16, 17, 21, 55, 571, DateTimeKind.Local).AddTicks(117));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5e0fe925-6ef7-46c6-88f2-24501a96c5a9", "AQAAAAEAACcQAAAAEFIu5WvOKe188tLgUbOxkDHx89SP9M0D0qigq0hwWkJgjx4SFcBBNreCta8qGpbinA==", "bf64cb73-6399-42d8-9e5b-249b900bf70c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8acdd283-300d-4ef1-a83f-813efc164767",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "37ed8dfb-1179-4d9c-a7ef-60d41820b340", "AQAAAAEAACcQAAAAEPw3mXbS18zE2OPKND2RflDAwWxIFaGbUBhlcRqAn+tzULW56w991NbEw8OQMEtWbA==", "f4f55b87-6616-47fd-8564-a02bcb828a31" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "ProfilePicture", "SecurityStamp" },
                values: new object[] { "edae1ca8-eef3-46b3-8b49-95176f9a7389", "AQAAAAEAACcQAAAAEO/ObkDg19DEPiTFSFUpbWlDj9R1bTthlyGQP0OMaTWiaIVhID1T7ADJ+YCWCOaEqA==", "https://p7.hiclipart.com/preview/355/848/997/computer-icons-user-profile-google-account-photos-icon-account.jpg", "ac89e1e0-edc4-4448-8c22-c859f5c5def6" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "PostedOn",
                value: new DateTime(2024, 4, 9, 10, 14, 27, 972, DateTimeKind.Local).AddTicks(2968));

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 1,
                column: "PostedOn",
                value: new DateTime(2024, 4, 9, 10, 14, 28, 20, DateTimeKind.Local).AddTicks(8067));

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 2,
                column: "PostedOn",
                value: new DateTime(2024, 4, 9, 10, 14, 28, 20, DateTimeKind.Local).AddTicks(8118));
        }
    }
}
