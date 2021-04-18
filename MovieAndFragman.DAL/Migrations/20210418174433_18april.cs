using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieAndFragman.DAL.Migrations
{
    public partial class _18april : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CounterView",
                table: "Fragman",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "ActivationCode", "CreatedDate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new Guid("e9f12416-1963-4b14-9d92-d07f01af3af6"), new DateTime(2021, 4, 18, 20, 44, 33, 87, DateTimeKind.Local).AddTicks(4605), new byte[] { 74, 209, 7, 154, 228, 190, 105, 100, 35, 42, 73, 240, 196, 207, 175, 70, 241, 190, 157, 54, 98, 86, 99, 90, 45, 174, 111, 166, 86, 8, 251, 106, 164, 253, 107, 56, 71, 194, 247, 195, 237, 78, 236, 47, 225, 80, 251, 77, 94, 180, 138, 56, 207, 78, 154, 146, 68, 114, 28, 5, 15, 235, 141, 201 }, new byte[] { 210, 58, 241, 166, 161, 176, 6, 7, 227, 253, 249, 176, 133, 154, 47, 231, 90, 20, 32, 238, 112, 67, 55, 138, 162, 168, 219, 233, 12, 12, 190, 32, 231, 63, 188, 21, 74, 116, 127, 29, 149, 0, 44, 148, 25, 77, 235, 175, 103, 204, 186, 44, 38, 32, 1, 113, 219, 125, 17, 143, 139, 75, 50, 231, 169, 46, 235, 202, 44, 117, 238, 192, 229, 12, 183, 3, 173, 121, 201, 195, 12, 19, 36, 11, 159, 44, 215, 84, 4, 97, 120, 14, 119, 39, 172, 118, 130, 198, 235, 37, 171, 199, 192, 206, 9, 155, 239, 79, 93, 0, 224, 33, 3, 102, 3, 201, 8, 97, 65, 24, 33, 109, 106, 228, 208, 115, 254, 113 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CounterView",
                table: "Fragman");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "ActivationCode", "CreatedDate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new Guid("8be7225c-bfa9-415d-8527-c19109a03ff3"), new DateTime(2021, 4, 17, 22, 6, 31, 887, DateTimeKind.Local).AddTicks(1236), new byte[] { 161, 209, 221, 112, 33, 254, 168, 33, 35, 34, 190, 50, 104, 32, 63, 169, 35, 88, 61, 181, 93, 202, 220, 151, 189, 68, 70, 154, 43, 208, 140, 100, 165, 238, 158, 184, 229, 204, 61, 83, 174, 217, 83, 174, 244, 11, 133, 79, 165, 249, 56, 113, 101, 94, 24, 12, 183, 41, 138, 176, 4, 142, 23, 5 }, new byte[] { 224, 53, 87, 85, 64, 228, 48, 213, 236, 90, 69, 176, 250, 54, 160, 245, 42, 117, 87, 253, 131, 155, 25, 59, 124, 207, 115, 27, 65, 86, 201, 127, 25, 6, 28, 139, 232, 192, 232, 5, 25, 74, 91, 116, 246, 123, 40, 169, 7, 177, 189, 122, 153, 31, 45, 143, 80, 59, 43, 171, 18, 89, 17, 231, 20, 106, 162, 210, 102, 165, 41, 61, 83, 206, 102, 191, 231, 249, 106, 199, 82, 30, 255, 100, 76, 218, 198, 187, 169, 171, 108, 37, 190, 188, 167, 6, 138, 109, 139, 153, 235, 224, 167, 88, 34, 91, 185, 143, 66, 36, 240, 44, 179, 160, 151, 18, 208, 167, 197, 56, 219, 171, 29, 74, 227, 214, 243, 214 } });
        }
    }
}
