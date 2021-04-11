using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieAndFragman.DAL.Migrations
{
    public partial class _03April : Migration
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
                values: new object[] { 1, new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 3, 21, 20, 47, 834, DateTimeKind.Local).AddTicks(1782), null, "admin", false, "admin", new byte[] { 201, 112, 2, 160, 194, 68, 233, 187, 19, 7, 194, 34, 110, 11, 244, 186, 201, 107, 249, 33, 218, 153, 184, 40, 252, 241, 241, 43, 177, 171, 113, 102, 102, 117, 238, 103, 141, 28, 210, 21, 62, 30, 66, 223, 87, 143, 250, 204, 238, 74, 0, 172, 215, 142, 50, 45, 70, 10, 199, 197, 116, 34, 139, 203 }, new byte[] { 146, 61, 142, 158, 98, 36, 14, 81, 103, 18, 2, 154, 236, 184, 73, 6, 252, 174, 158, 76, 253, 209, 211, 189, 164, 32, 0, 249, 229, 88, 83, 220, 165, 208, 78, 63, 98, 115, 230, 104, 171, 19, 82, 84, 217, 177, 232, 111, 81, 118, 148, 128, 154, 148, 215, 106, 215, 239, 163, 19, 229, 222, 164, 211, 109, 244, 172, 46, 60, 148, 207, 43, 202, 89, 21, 204, 66, 46, 164, 210, 66, 183, 219, 20, 128, 214, 185, 92, 177, 117, 83, 183, 27, 108, 150, 194, 232, 210, 47, 143, 224, 144, 180, 165, 120, 193, 55, 38, 157, 178, 17, 47, 120, 2, 142, 230, 161, 98, 132, 86, 89, 207, 37, 192, 40, 20, 166, 22 }, null, "admin", 1 });

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
