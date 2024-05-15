using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoligBlik.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialNew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BoardMembers_Users_UserId",
                table: "BoardMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Users_UserId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Properties_Users_BoardManagerId",
                table: "Properties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.EnsureSchema(
                name: "user");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User",
                newSchema: "user");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                schema: "user",
                table: "User",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BoardMembers_User_UserId",
                table: "BoardMembers",
                column: "UserId",
                principalSchema: "user",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_User_UserId",
                table: "Bookings",
                column: "UserId",
                principalSchema: "user",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_User_BoardManagerId",
                table: "Properties",
                column: "BoardManagerId",
                principalSchema: "user",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BoardMembers_User_UserId",
                table: "BoardMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_User_UserId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Properties_User_BoardManagerId",
                table: "Properties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                schema: "user",
                table: "User");

            migrationBuilder.RenameTable(
                name: "User",
                schema: "user",
                newName: "Users");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BoardMembers_Users_UserId",
                table: "BoardMembers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Users_UserId",
                table: "Bookings",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_Users_BoardManagerId",
                table: "Properties",
                column: "BoardManagerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
