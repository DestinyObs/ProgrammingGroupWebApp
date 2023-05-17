using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProgrammingGroupWebApp.Migrations
{
    public partial class WeCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "addLanguages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_addLanguages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUser",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LanguageId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUser", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_AppUser_addLanguages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "addLanguages",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "codingMeetUps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LangId = table.Column<int>(type: "int", nullable: false),
                    MeetUpCategory = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_codingMeetUps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_codingMeetUps_addLanguages_LangId",
                        column: x => x.LangId,
                        principalTable: "addLanguages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_codingMeetUps_AppUser_UserId",
                        column: x => x.UserId,
                        principalTable: "AppUser",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "groups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LangId = table.Column<int>(type: "int", nullable: false),
                    GroupCategory = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_groups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_groups_addLanguages_LangId",
                        column: x => x.LangId,
                        principalTable: "addLanguages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_groups_AppUser_UserId",
                        column: x => x.UserId,
                        principalTable: "AppUser",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppUser_LanguageId",
                table: "AppUser",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_codingMeetUps_LangId",
                table: "codingMeetUps",
                column: "LangId");

            migrationBuilder.CreateIndex(
                name: "IX_codingMeetUps_UserId",
                table: "codingMeetUps",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_groups_LangId",
                table: "groups",
                column: "LangId");

            migrationBuilder.CreateIndex(
                name: "IX_groups_UserId",
                table: "groups",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "codingMeetUps");

            migrationBuilder.DropTable(
                name: "groups");

            migrationBuilder.DropTable(
                name: "AppUser");

            migrationBuilder.DropTable(
                name: "addLanguages");
        }
    }
}
