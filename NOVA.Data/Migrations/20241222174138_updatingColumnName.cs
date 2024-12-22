using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NOVAData.Migrations
{
    /// <inheritdoc />
    public partial class updatingColumnName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskStatusUpdates_Statuses_StatusId",
                table: "TaskStatusUpdates");

            migrationBuilder.DropColumn(
                name: "SatusId",
                table: "TaskStatusUpdates");

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "TaskStatusUpdates",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskStatusUpdates_Statuses_StatusId",
                table: "TaskStatusUpdates",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskStatusUpdates_Statuses_StatusId",
                table: "TaskStatusUpdates");

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "TaskStatusUpdates",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "SatusId",
                table: "TaskStatusUpdates",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskStatusUpdates_Statuses_StatusId",
                table: "TaskStatusUpdates",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id");
        }
    }
}
