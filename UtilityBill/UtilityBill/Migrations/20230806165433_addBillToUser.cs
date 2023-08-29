using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UtilityBill.Migrations
{
    /// <inheritdoc />
    public partial class addBillToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "BillDetail",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BillDetail_UserId",
                table: "BillDetail",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BillDetail_User_UserId",
                table: "BillDetail",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BillDetail_User_UserId",
                table: "BillDetail");

            migrationBuilder.DropIndex(
                name: "IX_BillDetail_UserId",
                table: "BillDetail");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "BillDetail");
        }
    }
}
