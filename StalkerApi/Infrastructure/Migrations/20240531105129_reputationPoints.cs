using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StalkerApi.Migrations
{
    /// <inheritdoc />
    public partial class reputationPoints : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReputationPoints",
                table: "Stalkers",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReputationPoints",
                table: "Stalkers");
        }
    }
}
