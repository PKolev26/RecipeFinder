using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeFinder.Data.Migrations
{
    public partial class UpdatingConstraints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Difficulties",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                comment: "The Difficulty Description",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldComment: "The Difficulty Description");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Difficulties",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                comment: "The Difficulty Description",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldComment: "The Difficulty Description");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a4382623-0f8c-45a3-842a-7ba657ab463e", "AQAAAAEAACcQAAAAEOjnPKeFQtVaXw43z2kLpnthgtwP/r4g/xqah9J8TUW6vYHA9vzHZ7pkC/rQoELh9w==", "78f60505-2744-47bf-844d-fe165ea5b4cd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fc7f7abf-3aa6-45a8-af7e-46acdd811e20", "AQAAAAEAACcQAAAAEMu/o779E1TrUtyvs/cExkKKIueTc3Zq1KnPrMDTW184Dhf+bI0ncnB01aD5wMFGMg==", "4d1b0089-4b03-4663-85f6-cb950fd68495" });
        }
    }
}
