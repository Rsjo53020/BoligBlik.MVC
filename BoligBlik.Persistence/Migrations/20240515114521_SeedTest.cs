using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoligBlik.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SeedTest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BoardMembers_Users_MemberId",
                table: "BoardMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Items_ItemId",
                table: "Bookings");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "BoardMembers");

            migrationBuilder.RenameColumn(
                name: "MemberId",
                table: "BoardMembers",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_BoardMembers_MemberId",
                table: "BoardMembers",
                newName: "IX_BoardMembers_UserId");

            migrationBuilder.CreateTable(
                name: "BookingItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rules = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Repairs = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageFilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    UpdateStamp = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingItems", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_BoardMembers_Users_UserId",
                table: "BoardMembers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_BookingItems_ItemId",
                table: "Bookings",
                column: "ItemId",
                principalTable: "BookingItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BoardMembers_Users_UserId",
                table: "BoardMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_BookingItems_ItemId",
                table: "Bookings");

            migrationBuilder.DropTable(
                name: "BookingItems");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "BoardMembers",
                newName: "MemberId");

            migrationBuilder.RenameIndex(
                name: "IX_BoardMembers_UserId",
                table: "BoardMembers",
                newName: "IX_BoardMembers_MemberId");

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "BoardMembers",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Repairs = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    Rules = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdateStamp = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_BoardMembers_Users_MemberId",
                table: "BoardMembers",
                column: "MemberId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Items_ItemId",
                table: "Bookings",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
