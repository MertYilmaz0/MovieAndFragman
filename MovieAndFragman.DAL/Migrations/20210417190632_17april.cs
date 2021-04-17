using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieAndFragman.DAL.Migrations
{
    public partial class _17april : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CounterDisLike",
                table: "Fragman",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CounterLike",
                table: "Fragman",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "Ratio",
                table: "Fragman",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "ActivationCode", "CreatedDate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new Guid("8be7225c-bfa9-415d-8527-c19109a03ff3"), new DateTime(2021, 4, 17, 22, 6, 31, 887, DateTimeKind.Local).AddTicks(1236), new byte[] { 161, 209, 221, 112, 33, 254, 168, 33, 35, 34, 190, 50, 104, 32, 63, 169, 35, 88, 61, 181, 93, 202, 220, 151, 189, 68, 70, 154, 43, 208, 140, 100, 165, 238, 158, 184, 229, 204, 61, 83, 174, 217, 83, 174, 244, 11, 133, 79, 165, 249, 56, 113, 101, 94, 24, 12, 183, 41, 138, 176, 4, 142, 23, 5 }, new byte[] { 224, 53, 87, 85, 64, 228, 48, 213, 236, 90, 69, 176, 250, 54, 160, 245, 42, 117, 87, 253, 131, 155, 25, 59, 124, 207, 115, 27, 65, 86, 201, 127, 25, 6, 28, 139, 232, 192, 232, 5, 25, 74, 91, 116, 246, 123, 40, 169, 7, 177, 189, 122, 153, 31, 45, 143, 80, 59, 43, 171, 18, 89, 17, 231, 20, 106, 162, 210, 102, 165, 41, 61, 83, 206, 102, 191, 231, 249, 106, 199, 82, 30, 255, 100, 76, 218, 198, 187, 169, 171, 108, 37, 190, 188, 167, 6, 138, 109, 139, 153, 235, 224, 167, 88, 34, 91, 185, 143, 66, 36, 240, 44, 179, 160, 151, 18, 208, 167, 197, 56, 219, 171, 29, 74, 227, 214, 243, 214 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CounterDisLike",
                table: "Fragman");

            migrationBuilder.DropColumn(
                name: "CounterLike",
                table: "Fragman");

            migrationBuilder.DropColumn(
                name: "Ratio",
                table: "Fragman");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "ActivationCode", "CreatedDate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new Guid("0741ca78-7451-4cc7-b17c-f7138fdc9e30"), new DateTime(2021, 4, 13, 18, 19, 59, 294, DateTimeKind.Local).AddTicks(9135), new byte[] { 192, 45, 117, 108, 58, 57, 195, 84, 70, 141, 224, 162, 40, 208, 144, 162, 116, 89, 22, 125, 235, 155, 96, 206, 175, 25, 198, 222, 208, 44, 22, 218, 19, 124, 31, 202, 232, 51, 19, 33, 50, 81, 193, 118, 182, 98, 129, 25, 187, 98, 53, 222, 231, 198, 64, 0, 82, 122, 235, 161, 86, 36, 37, 103 }, new byte[] { 12, 72, 23, 44, 41, 23, 113, 224, 92, 227, 2, 103, 148, 114, 191, 53, 19, 243, 61, 4, 217, 241, 118, 41, 59, 231, 254, 125, 201, 134, 228, 205, 193, 96, 167, 128, 241, 39, 218, 237, 142, 190, 89, 135, 49, 77, 65, 10, 198, 37, 89, 237, 168, 156, 60, 101, 80, 246, 221, 13, 205, 68, 172, 208, 156, 134, 89, 145, 158, 87, 183, 134, 198, 233, 178, 47, 232, 71, 169, 93, 215, 124, 176, 77, 39, 224, 10, 231, 253, 64, 242, 180, 252, 211, 16, 232, 28, 118, 156, 246, 33, 245, 174, 232, 14, 233, 181, 194, 0, 254, 44, 62, 241, 56, 49, 183, 53, 102, 198, 134, 57, 137, 97, 7, 204, 224, 243, 14 } });
        }
    }
}
