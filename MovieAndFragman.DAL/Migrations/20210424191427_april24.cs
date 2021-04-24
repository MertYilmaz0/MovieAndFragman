using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieAndFragman.DAL.Migrations
{
    public partial class april24 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MediumPoster",
                table: "Fragman",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SmallPoster",
                table: "Fragman",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "ActivationCode", "CreatedDate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new Guid("8e616252-50f5-490d-84d2-bcba5ad58c3b"), new DateTime(2021, 4, 24, 22, 14, 26, 786, DateTimeKind.Local).AddTicks(9252), new byte[] { 212, 85, 218, 51, 190, 27, 155, 53, 227, 244, 136, 67, 192, 210, 165, 98, 226, 69, 211, 53, 16, 115, 32, 221, 123, 143, 8, 37, 31, 245, 119, 54, 108, 148, 36, 224, 181, 135, 228, 160, 209, 177, 46, 242, 42, 166, 151, 58, 145, 178, 176, 135, 51, 87, 12, 87, 143, 151, 32, 192, 40, 53, 75, 236 }, new byte[] { 218, 53, 110, 79, 89, 80, 204, 59, 104, 131, 44, 217, 192, 117, 213, 151, 190, 89, 117, 178, 179, 105, 201, 181, 74, 221, 222, 120, 230, 114, 175, 199, 219, 199, 70, 56, 28, 162, 2, 157, 184, 157, 142, 90, 148, 227, 248, 107, 48, 86, 112, 1, 232, 158, 223, 21, 51, 27, 149, 20, 48, 124, 155, 74, 43, 28, 22, 239, 250, 65, 20, 212, 46, 224, 173, 175, 227, 128, 25, 117, 84, 230, 17, 226, 42, 114, 125, 46, 53, 118, 226, 211, 124, 86, 61, 47, 54, 85, 130, 131, 79, 228, 21, 119, 167, 221, 67, 45, 177, 8, 63, 189, 151, 138, 252, 176, 206, 244, 24, 219, 41, 116, 36, 243, 126, 120, 94, 41 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MediumPoster",
                table: "Fragman");

            migrationBuilder.DropColumn(
                name: "SmallPoster",
                table: "Fragman");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "ActivationCode", "CreatedDate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new Guid("e9f12416-1963-4b14-9d92-d07f01af3af6"), new DateTime(2021, 4, 18, 20, 44, 33, 87, DateTimeKind.Local).AddTicks(4605), new byte[] { 74, 209, 7, 154, 228, 190, 105, 100, 35, 42, 73, 240, 196, 207, 175, 70, 241, 190, 157, 54, 98, 86, 99, 90, 45, 174, 111, 166, 86, 8, 251, 106, 164, 253, 107, 56, 71, 194, 247, 195, 237, 78, 236, 47, 225, 80, 251, 77, 94, 180, 138, 56, 207, 78, 154, 146, 68, 114, 28, 5, 15, 235, 141, 201 }, new byte[] { 210, 58, 241, 166, 161, 176, 6, 7, 227, 253, 249, 176, 133, 154, 47, 231, 90, 20, 32, 238, 112, 67, 55, 138, 162, 168, 219, 233, 12, 12, 190, 32, 231, 63, 188, 21, 74, 116, 127, 29, 149, 0, 44, 148, 25, 77, 235, 175, 103, 204, 186, 44, 38, 32, 1, 113, 219, 125, 17, 143, 139, 75, 50, 231, 169, 46, 235, 202, 44, 117, 238, 192, 229, 12, 183, 3, 173, 121, 201, 195, 12, 19, 36, 11, 159, 44, 215, 84, 4, 97, 120, 14, 119, 39, 172, 118, 130, 198, 235, 37, 171, 199, 192, 206, 9, 155, 239, 79, 93, 0, 224, 33, 3, 102, 3, 201, 8, 97, 65, 24, 33, 109, 106, 228, 208, 115, 254, 113 } });
        }
    }
}
