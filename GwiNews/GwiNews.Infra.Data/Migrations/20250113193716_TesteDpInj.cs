using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GwiNews.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class TesteDpInj : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "ProfessionalSkills",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "ProfessionalInformations",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "NewsSubcategories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "NewsCategories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Formations",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "ProfessionalSkills");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "ProfessionalInformations");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "NewsSubcategories");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "NewsCategories");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Formations");
        }
    }
}
