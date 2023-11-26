using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestTaskAPI.Migrations
{
    /// <inheritdoc />
    public partial class CascadeDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventStages_Events_EventId",
                table: "EventStages");

            migrationBuilder.DropForeignKey(
                name: "FK_Organizers_Events_EventId",
                table: "Organizers");

            migrationBuilder.DropForeignKey(
                name: "FK_Speakers_Events_EventId",
                table: "Speakers");

            migrationBuilder.AlterColumn<int>(
                name: "EventId",
                table: "Speakers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EventId",
                table: "Organizers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EventId",
                table: "EventStages",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_EventStages_Events_EventId",
                table: "EventStages",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Organizers_Events_EventId",
                table: "Organizers",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Speakers_Events_EventId",
                table: "Speakers",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventStages_Events_EventId",
                table: "EventStages");

            migrationBuilder.DropForeignKey(
                name: "FK_Organizers_Events_EventId",
                table: "Organizers");

            migrationBuilder.DropForeignKey(
                name: "FK_Speakers_Events_EventId",
                table: "Speakers");

            migrationBuilder.AlterColumn<int>(
                name: "EventId",
                table: "Speakers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "EventId",
                table: "Organizers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "EventId",
                table: "EventStages",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_EventStages_Events_EventId",
                table: "EventStages",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Organizers_Events_EventId",
                table: "Organizers",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Speakers_Events_EventId",
                table: "Speakers",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id");
        }
    }
}
