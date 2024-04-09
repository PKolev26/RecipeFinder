using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeFinder.Data.Migrations
{
    public partial class ExtendingApplicationUserAndSeedingAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Recipes",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                comment: "The Recipe Name",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldComment: "The Recipe Name");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProfilePicture",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePicture", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e", 0, "5e0fe925-6ef7-46c6-88f2-24501a96c5a9", "ApplicationUser", "guest@gmail.com", false, "Test", "Guest", false, null, "guest@gmail.com", "guest@gmail.com", "AQAAAAEAACcQAAAAEFIu5WvOKe188tLgUbOxkDHx89SP9M0D0qigq0hwWkJgjx4SFcBBNreCta8qGpbinA==", null, false, "https://www.pngitem.com/pimgs/m/146-1468479_my-profile-icon-blank-profile-picture-circle-hd.png", "bf64cb73-6399-42d8-9e5b-249b900bf70c", false, "guest@gmail.com" },
                    { "8acdd283-300d-4ef1-a83f-813efc164767", 0, "37ed8dfb-1179-4d9c-a7ef-60d41820b340", "ApplicationUser", "admin@gmail.com", false, "Admin", "Admin", false, null, "admin@gmail.com", "admin@gmail.com", "AQAAAAEAACcQAAAAEPw3mXbS18zE2OPKND2RflDAwWxIFaGbUBhlcRqAn+tzULW56w991NbEw8OQMEtWbA==", null, false, "https://www.pngmart.com/files/21/Admin-Profile-Vector-PNG-Clipart.png", "f4f55b87-6616-47fd-8564-a02bcb828a31", false, "admin@gmail.com" },
                    { "dea12856-c198-4129-b3f3-b893d8395082", 0, "edae1ca8-eef3-46b3-8b49-95176f9a7389", "ApplicationUser", "user@gmail.com", false, "Test", "User", false, null, "user@gmail.com", "user@gmail.com", "AQAAAAEAACcQAAAAEO/ObkDg19DEPiTFSFUpbWlDj9R1bTthlyGQP0OMaTWiaIVhID1T7ADJ+YCWCOaEqA==", null, false, "https://p7.hiclipart.com/preview/355/848/997/computer-icons-user-profile-google-account-photos-icon-account.jpg", "ac89e1e0-edc4-4448-8c22-c859f5c5def6", false, "user@gmail.com" }
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8acdd283-300d-4ef1-a83f-813efc164767");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ProfilePicture",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Recipes",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                comment: "The Recipe Name",
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25,
                oldComment: "The Recipe Name");

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
                column: "PostedOn",
                value: new DateTime(2024, 3, 29, 12, 13, 2, 251, DateTimeKind.Local).AddTicks(8427));

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 1,
                column: "PostedOn",
                value: new DateTime(2024, 3, 29, 12, 13, 2, 287, DateTimeKind.Local).AddTicks(5018));

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 2,
                column: "PostedOn",
                value: new DateTime(2024, 3, 29, 12, 13, 2, 287, DateTimeKind.Local).AddTicks(5070));
        }
    }
}
