using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeFinder.Data.Migrations
{
    public partial class ChangingInstructionConstants : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Instructions",
                table: "Recipes",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                comment: "The Recipe Instructions",
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldComment: "The Recipe Instructions");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7d9db03b-78ad-4f52-8874-ae7ebe80e5d5", "AQAAAAEAACcQAAAAEGFP/dtTqaGRtXhxvwaGZTZ7yYIkXI+ouhjQonVdigPdt3Tv3jJ1Cohe7b2vur36Zg==", "c823856a-f5ad-478f-b126-18a1b8a74617" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4e517565-eb91-405e-a2cd-715735512d5a", "AQAAAAEAACcQAAAAEI1pcv5wHgyzQfjRsZCpqctmgeS6jaImEt8GWvUaGd1yO9I1TJeTf8wYCB6ILjyz+A==", "6a31a912-5e41-46b9-b3d5-7214dccdb75c" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Instructions",
                table: "Recipes",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                comment: "The Recipe Instructions",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldComment: "The Recipe Instructions");

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
        }
    }
}
