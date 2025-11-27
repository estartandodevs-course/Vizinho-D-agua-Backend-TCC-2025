using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VizinhoDAgua.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddTitleInAlert : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "AlertEntity",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "AlertEntity");
        }
    }
}
