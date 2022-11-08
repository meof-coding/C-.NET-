using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab2.Data.Migrations
{
    public partial class UpdateIdentityRoomID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_AspNetUsers_UserAccountId",
                schema: "Identity",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_UserAccountId",
                schema: "Identity",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "UserAccountId",
                schema: "Identity",
                table: "Rooms");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserAccountId",
                schema: "Identity",
                table: "Rooms",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_UserAccountId",
                schema: "Identity",
                table: "Rooms",
                column: "UserAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_AspNetUsers_UserAccountId",
                schema: "Identity",
                table: "Rooms",
                column: "UserAccountId",
                principalSchema: "Identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
