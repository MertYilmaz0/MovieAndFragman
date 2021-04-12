using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieAndFragman.DAL.Migrations
{
    public partial class _12april2021 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    BrithDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    ActivationCode = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserRole = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Fragman",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Poster = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fragman", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Fragman_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FragComment",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false),
                    FragmanID = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FragComment", x => new { x.UserID, x.FragmanID });
                    table.ForeignKey(
                        name: "FK_FragComment_Fragman_FragmanID",
                        column: x => x.FragmanID,
                        principalTable: "Fragman",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FragComment_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GenreFragman",
                columns: table => new
                {
                    GenreID = table.Column<int>(type: "int", nullable: false),
                    FragmanID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreFragman", x => new { x.GenreID, x.FragmanID });
                    table.ForeignKey(
                        name: "FK_GenreFragman_Fragman_FragmanID",
                        column: x => x.FragmanID,
                        principalTable: "Fragman",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenreFragman_Genre_GenreID",
                        column: x => x.GenreID,
                        principalTable: "Genre",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rating",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false),
                    FragmanID = table.Column<int>(type: "int", nullable: false),
                    LoveLike = table.Column<bool>(type: "bit", nullable: false),
                    UnLike = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rating", x => new { x.UserID, x.FragmanID });
                    table.ForeignKey(
                        name: "FK_Rating_Fragman_FragmanID",
                        column: x => x.FragmanID,
                        principalTable: "Fragman",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rating_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Url",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Language = table.Column<int>(type: "int", nullable: false),
                    UrlPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FragmanID = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Url", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Url_Fragman_FragmanID",
                        column: x => x.FragmanID,
                        principalTable: "Fragman",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "ID", "ActivationCode", "BrithDate", "CreatedDate", "Email", "FirstName", "IsActive", "LastName", "PasswordHash", "PasswordSalt", "PhoneNumber", "UserName", "UserRole" },
                values: new object[] { 1, new Guid("20cca3dc-4024-4e14-984c-a9f0a6eb1f21"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 12, 22, 33, 48, 536, DateTimeKind.Local).AddTicks(1), null, "admin", false, "admin", new byte[] { 77, 97, 95, 220, 247, 182, 224, 169, 112, 41, 168, 118, 20, 156, 156, 62, 43, 75, 128, 1, 111, 238, 162, 161, 143, 92, 207, 136, 204, 100, 12, 222, 238, 190, 13, 240, 166, 89, 30, 6, 205, 73, 81, 176, 192, 134, 234, 195, 167, 14, 25, 100, 75, 52, 213, 168, 202, 9, 163, 85, 26, 136, 124, 116 }, new byte[] { 205, 165, 176, 193, 212, 134, 41, 246, 216, 53, 17, 35, 61, 21, 71, 93, 174, 240, 40, 227, 126, 102, 51, 241, 95, 234, 195, 16, 254, 249, 115, 240, 96, 156, 229, 57, 40, 150, 195, 205, 143, 188, 165, 153, 209, 144, 142, 154, 157, 241, 144, 236, 27, 62, 107, 232, 158, 236, 203, 138, 80, 155, 73, 186, 199, 159, 82, 244, 48, 157, 211, 46, 161, 231, 154, 61, 184, 12, 90, 184, 86, 116, 165, 162, 55, 149, 48, 13, 202, 107, 57, 135, 36, 64, 186, 226, 133, 50, 54, 6, 234, 1, 85, 155, 240, 14, 136, 5, 142, 35, 4, 171, 184, 102, 139, 83, 84, 119, 92, 109, 133, 92, 209, 145, 122, 88, 253, 251 }, null, "admin", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_FragComment_FragmanID",
                table: "FragComment",
                column: "FragmanID");

            migrationBuilder.CreateIndex(
                name: "IX_Fragman_UserID",
                table: "Fragman",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_GenreFragman_FragmanID",
                table: "GenreFragman",
                column: "FragmanID");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_FragmanID",
                table: "Rating",
                column: "FragmanID");

            migrationBuilder.CreateIndex(
                name: "IX_Url_FragmanID",
                table: "Url",
                column: "FragmanID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FragComment");

            migrationBuilder.DropTable(
                name: "GenreFragman");

            migrationBuilder.DropTable(
                name: "Rating");

            migrationBuilder.DropTable(
                name: "Url");

            migrationBuilder.DropTable(
                name: "Genre");

            migrationBuilder.DropTable(
                name: "Fragman");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
