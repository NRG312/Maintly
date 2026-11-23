using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Maintly.API.Migrations
{
    /// <inheritdoc />
    public partial class FixForeignKeyNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Components_Processes_ProcessId",
                table: "Components");

            migrationBuilder.DropForeignKey(
                name: "FK_Processes_Machines_MachineId",
                table: "Processes");

            migrationBuilder.DropColumn(
                name: "IdMachine",
                table: "Processes");

            migrationBuilder.DropColumn(
                name: "IdProcess",
                table: "Components");

            migrationBuilder.AlterColumn<int>(
                name: "MachineId",
                table: "Processes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProcessId",
                table: "Components",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Components_Processes_ProcessId",
                table: "Components",
                column: "ProcessId",
                principalTable: "Processes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Processes_Machines_MachineId",
                table: "Processes",
                column: "MachineId",
                principalTable: "Machines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Components_Processes_ProcessId",
                table: "Components");

            migrationBuilder.DropForeignKey(
                name: "FK_Processes_Machines_MachineId",
                table: "Processes");

            migrationBuilder.AlterColumn<int>(
                name: "MachineId",
                table: "Processes",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "IdMachine",
                table: "Processes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ProcessId",
                table: "Components",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "IdProcess",
                table: "Components",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Components_Processes_ProcessId",
                table: "Components",
                column: "ProcessId",
                principalTable: "Processes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Processes_Machines_MachineId",
                table: "Processes",
                column: "MachineId",
                principalTable: "Machines",
                principalColumn: "Id");
        }
    }
}
