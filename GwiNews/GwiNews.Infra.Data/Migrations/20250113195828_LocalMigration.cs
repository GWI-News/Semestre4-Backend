using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GwiNews.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class LocalMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NewsCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReaderUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    CompleteName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(510)", maxLength: 510, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(1020)", maxLength: 1020, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReaderUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsersWithNews",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    CompleteName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(510)", maxLength: 510, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(1020)", maxLength: 1020, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersWithNews", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NewsSubcategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(55)", maxLength: 55, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsSubcategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NewsSubcategories_NewsCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "NewsCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Formations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Institution = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Activity1 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Activity2 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Activity3 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Formations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Formations_ReaderUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "ReaderUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProfessionalInformations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompleteName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CompleteAddress = table.Column<string>(type: "nvarchar(510)", maxLength: 510, nullable: false),
                    Objective = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ImgUrl = table.Column<string>(type: "nvarchar(510)", maxLength: 510, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    WorkPlatformUrl = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfessionalInformations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProfessionalInformations_ReaderUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "ReaderUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProfessionalSkills",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Skill1 = table.Column<string>(type: "nvarchar(55)", maxLength: 55, nullable: false),
                    Skill2 = table.Column<string>(type: "nvarchar(55)", maxLength: 55, nullable: false),
                    Skill3 = table.Column<string>(type: "nvarchar(55)", maxLength: 55, nullable: false),
                    Skill4 = table.Column<string>(type: "nvarchar(55)", maxLength: 55, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfessionalSkills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProfessionalSkills_ReaderUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "ReaderUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    NewsUrl = table.Column<string>(type: "nvarchar(510)", maxLength: 510, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    Subtitle = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    NewsBody = table.Column<string>(type: "nvarchar(max)", maxLength: 65535, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(510)", maxLength: 510, nullable: false),
                    PublishDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AuthorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EditorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.Id);
                    table.ForeignKey(
                        name: "FK_News_NewsCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "NewsCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_News_UsersWithNews_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "UsersWithNews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_News_UsersWithNews_EditorId",
                        column: x => x.EditorId,
                        principalTable: "UsersWithNews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NewsNewsSubcategory",
                columns: table => new
                {
                    NewsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubcategoriesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsNewsSubcategory", x => new { x.NewsId, x.SubcategoriesId });
                    table.ForeignKey(
                        name: "FK_NewsNewsSubcategory_NewsSubcategories_SubcategoriesId",
                        column: x => x.SubcategoriesId,
                        principalTable: "NewsSubcategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NewsNewsSubcategory_News_NewsId",
                        column: x => x.NewsId,
                        principalTable: "News",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NewsReaderUser",
                columns: table => new
                {
                    FavoritedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FavoritedNewsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsReaderUser", x => new { x.FavoritedById, x.FavoritedNewsId });
                    table.ForeignKey(
                        name: "FK_NewsReaderUser_News_FavoritedNewsId",
                        column: x => x.FavoritedNewsId,
                        principalTable: "News",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NewsReaderUser_ReaderUsers_FavoritedById",
                        column: x => x.FavoritedById,
                        principalTable: "ReaderUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Formations_UserId",
                table: "Formations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_News_AuthorId",
                table: "News",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_News_CategoryId",
                table: "News",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_News_EditorId",
                table: "News",
                column: "EditorId");

            migrationBuilder.CreateIndex(
                name: "IX_NewsNewsSubcategory_SubcategoriesId",
                table: "NewsNewsSubcategory",
                column: "SubcategoriesId");

            migrationBuilder.CreateIndex(
                name: "IX_NewsReaderUser_FavoritedNewsId",
                table: "NewsReaderUser",
                column: "FavoritedNewsId");

            migrationBuilder.CreateIndex(
                name: "IX_NewsSubcategories_CategoryId",
                table: "NewsSubcategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessionalInformations_UserId",
                table: "ProfessionalInformations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessionalSkills_UserId",
                table: "ProfessionalSkills",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Formations");

            migrationBuilder.DropTable(
                name: "NewsNewsSubcategory");

            migrationBuilder.DropTable(
                name: "NewsReaderUser");

            migrationBuilder.DropTable(
                name: "ProfessionalInformations");

            migrationBuilder.DropTable(
                name: "ProfessionalSkills");

            migrationBuilder.DropTable(
                name: "NewsSubcategories");

            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "ReaderUsers");

            migrationBuilder.DropTable(
                name: "NewsCategories");

            migrationBuilder.DropTable(
                name: "UsersWithNews");
        }
    }
}
