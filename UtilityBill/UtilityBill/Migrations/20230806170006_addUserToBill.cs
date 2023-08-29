using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UtilityBill.Migrations
{
    /// <inheritdoc />
    public partial class addUserToBill : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BillDetail_User_UserId",
                table: "BillDetail");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "BillDetail",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BillDetail_User_UserId",
                table: "BillDetail",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BillDetail_User_UserId",
                table: "BillDetail");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "BillDetail",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_BillDetail_User_UserId",
                table: "BillDetail",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId");
        }
    }
}
