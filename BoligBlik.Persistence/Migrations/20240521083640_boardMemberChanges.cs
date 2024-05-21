using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoligBlik.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class boardMemberChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BoardMembers_Users_UserId",
                table: "BoardMembers");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "BoardMembers",
                newName: "UserID");

            migrationBuilder.RenameIndex(
                name: "IX_BoardMembers_UserId",
                table: "BoardMembers",
                newName: "IX_BoardMembers_UserID");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserID",
                table: "BoardMembers",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_BoardMembers_Users_UserID",
                table: "BoardMembers",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BoardMembers_Users_UserID",
                table: "BoardMembers");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "BoardMembers",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_BoardMembers_UserID",
                table: "BoardMembers",
                newName: "IX_BoardMembers_UserId");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "BoardMembers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BoardMembers_Users_UserId",
                table: "BoardMembers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
