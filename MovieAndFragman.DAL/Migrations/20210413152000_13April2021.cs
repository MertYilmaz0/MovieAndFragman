using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieAndFragman.DAL.Migrations
{
    public partial class _13April2021 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Language",
                table: "Url",
                newName: "LanguageID");

            migrationBuilder.CreateTable(
                name: "Language",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguageName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Language", x => x.ID);
                });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "ActivationCode", "CreatedDate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new Guid("0741ca78-7451-4cc7-b17c-f7138fdc9e30"), new DateTime(2021, 4, 13, 18, 19, 59, 294, DateTimeKind.Local).AddTicks(9135), new byte[] { 192, 45, 117, 108, 58, 57, 195, 84, 70, 141, 224, 162, 40, 208, 144, 162, 116, 89, 22, 125, 235, 155, 96, 206, 175, 25, 198, 222, 208, 44, 22, 218, 19, 124, 31, 202, 232, 51, 19, 33, 50, 81, 193, 118, 182, 98, 129, 25, 187, 98, 53, 222, 231, 198, 64, 0, 82, 122, 235, 161, 86, 36, 37, 103 }, new byte[] { 12, 72, 23, 44, 41, 23, 113, 224, 92, 227, 2, 103, 148, 114, 191, 53, 19, 243, 61, 4, 217, 241, 118, 41, 59, 231, 254, 125, 201, 134, 228, 205, 193, 96, 167, 128, 241, 39, 218, 237, 142, 190, 89, 135, 49, 77, 65, 10, 198, 37, 89, 237, 168, 156, 60, 101, 80, 246, 221, 13, 205, 68, 172, 208, 156, 134, 89, 145, 158, 87, 183, 134, 198, 233, 178, 47, 232, 71, 169, 93, 215, 124, 176, 77, 39, 224, 10, 231, 253, 64, 242, 180, 252, 211, 16, 232, 28, 118, 156, 246, 33, 245, 174, 232, 14, 233, 181, 194, 0, 254, 44, 62, 241, 56, 49, 183, 53, 102, 198, 134, 57, 137, 97, 7, 204, 224, 243, 14 } });

            migrationBuilder.CreateIndex(
                name: "IX_Url_LanguageID",
                table: "Url",
                column: "LanguageID");

            migrationBuilder.AddForeignKey(
                name: "FK_Url_Language_LanguageID",
                table: "Url",
                column: "LanguageID",
                principalTable: "Language",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Url_Language_LanguageID",
                table: "Url");

            migrationBuilder.DropTable(
                name: "Language");

            migrationBuilder.DropIndex(
                name: "IX_Url_LanguageID",
                table: "Url");

            migrationBuilder.RenameColumn(
                name: "LanguageID",
                table: "Url",
                newName: "Language");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "ActivationCode", "CreatedDate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new Guid("20cca3dc-4024-4e14-984c-a9f0a6eb1f21"), new DateTime(2021, 4, 12, 22, 33, 48, 536, DateTimeKind.Local).AddTicks(1), new byte[] { 77, 97, 95, 220, 247, 182, 224, 169, 112, 41, 168, 118, 20, 156, 156, 62, 43, 75, 128, 1, 111, 238, 162, 161, 143, 92, 207, 136, 204, 100, 12, 222, 238, 190, 13, 240, 166, 89, 30, 6, 205, 73, 81, 176, 192, 134, 234, 195, 167, 14, 25, 100, 75, 52, 213, 168, 202, 9, 163, 85, 26, 136, 124, 116 }, new byte[] { 205, 165, 176, 193, 212, 134, 41, 246, 216, 53, 17, 35, 61, 21, 71, 93, 174, 240, 40, 227, 126, 102, 51, 241, 95, 234, 195, 16, 254, 249, 115, 240, 96, 156, 229, 57, 40, 150, 195, 205, 143, 188, 165, 153, 209, 144, 142, 154, 157, 241, 144, 236, 27, 62, 107, 232, 158, 236, 203, 138, 80, 155, 73, 186, 199, 159, 82, 244, 48, 157, 211, 46, 161, 231, 154, 61, 184, 12, 90, 184, 86, 116, 165, 162, 55, 149, 48, 13, 202, 107, 57, 135, 36, 64, 186, 226, 133, 50, 54, 6, 234, 1, 85, 155, 240, 14, 136, 5, 142, 35, 4, 171, 184, 102, 139, 83, 84, 119, 92, 109, 133, 92, 209, 145, 122, 88, 253, 251 } });
        }
    }
}
