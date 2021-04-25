using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieAndFragman.DAL.Migrations
{
    public partial class april25 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Live",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BroadcastPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageSPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageLPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Live", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Podcast",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BroadcastPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageSPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageLPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Podcast", x => x.ID);
                });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "ActivationCode", "CreatedDate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new Guid("e88f92b9-6f39-4a66-a758-1659e261aa75"), new DateTime(2021, 4, 25, 15, 15, 25, 354, DateTimeKind.Local).AddTicks(8084), new byte[] { 38, 149, 53, 208, 13, 74, 156, 152, 159, 177, 153, 230, 227, 53, 103, 220, 129, 108, 36, 209, 189, 95, 200, 124, 219, 158, 212, 254, 108, 196, 207, 54, 245, 217, 139, 80, 38, 148, 68, 102, 41, 57, 139, 212, 37, 9, 131, 162, 222, 76, 140, 140, 153, 93, 110, 207, 189, 233, 107, 199, 55, 249, 110, 73 }, new byte[] { 80, 81, 118, 55, 233, 16, 124, 239, 92, 238, 95, 93, 63, 44, 215, 61, 212, 81, 131, 139, 71, 42, 161, 126, 94, 37, 87, 102, 224, 92, 208, 251, 148, 29, 141, 61, 144, 52, 167, 74, 205, 220, 247, 54, 8, 123, 206, 157, 8, 96, 9, 79, 218, 8, 85, 137, 13, 184, 44, 190, 163, 52, 135, 121, 69, 37, 194, 78, 11, 65, 248, 65, 120, 88, 237, 125, 33, 79, 192, 175, 146, 71, 115, 19, 58, 107, 14, 181, 45, 40, 34, 107, 222, 41, 254, 122, 198, 109, 192, 47, 241, 80, 71, 38, 129, 249, 198, 139, 157, 239, 208, 75, 230, 210, 149, 251, 48, 242, 28, 25, 67, 204, 160, 69, 104, 214, 158, 199 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Live");

            migrationBuilder.DropTable(
                name: "Podcast");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "ActivationCode", "CreatedDate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new Guid("8e616252-50f5-490d-84d2-bcba5ad58c3b"), new DateTime(2021, 4, 24, 22, 14, 26, 786, DateTimeKind.Local).AddTicks(9252), new byte[] { 212, 85, 218, 51, 190, 27, 155, 53, 227, 244, 136, 67, 192, 210, 165, 98, 226, 69, 211, 53, 16, 115, 32, 221, 123, 143, 8, 37, 31, 245, 119, 54, 108, 148, 36, 224, 181, 135, 228, 160, 209, 177, 46, 242, 42, 166, 151, 58, 145, 178, 176, 135, 51, 87, 12, 87, 143, 151, 32, 192, 40, 53, 75, 236 }, new byte[] { 218, 53, 110, 79, 89, 80, 204, 59, 104, 131, 44, 217, 192, 117, 213, 151, 190, 89, 117, 178, 179, 105, 201, 181, 74, 221, 222, 120, 230, 114, 175, 199, 219, 199, 70, 56, 28, 162, 2, 157, 184, 157, 142, 90, 148, 227, 248, 107, 48, 86, 112, 1, 232, 158, 223, 21, 51, 27, 149, 20, 48, 124, 155, 74, 43, 28, 22, 239, 250, 65, 20, 212, 46, 224, 173, 175, 227, 128, 25, 117, 84, 230, 17, 226, 42, 114, 125, 46, 53, 118, 226, 211, 124, 86, 61, 47, 54, 85, 130, 131, 79, 228, 21, 119, 167, 221, 67, 45, 177, 8, 63, 189, 151, 138, 252, 176, 206, 244, 24, 219, 41, 116, 36, 243, 126, 120, 94, 41 } });
        }
    }
}
