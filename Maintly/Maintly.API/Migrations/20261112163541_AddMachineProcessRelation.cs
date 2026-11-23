using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Maintly.API.Migrations
{
    /// <inheritdoc />
    public partial class AddMachineProcessRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdMachine",
                table: "Processes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdProcess",
                table: "Components",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdMachine",
                table: "Processes");

            migrationBuilder.DropColumn(
                name: "IdProcess",
                table: "Components");
        }
    }
}
