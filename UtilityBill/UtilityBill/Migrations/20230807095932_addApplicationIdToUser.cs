using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UtilityBill.Migrations
{
    /// <inheritdoc />
    public partial class addApplicationIdToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_ApplicationDetail_ApplicationDetailId",
                table: "User");

            migrationBuilder.AlterColumn<int>(
                name: "ApplicationDetailId",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_User_ApplicationDetail_ApplicationDetailId",
                table: "User",
                column: "ApplicationDetailId",
                principalTable: "ApplicationDetail",
                principalColumn: "ApplicationDetailId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_ApplicationDetail_ApplicationDetailId",
                table: "User");

            migrationBuilder.AlterColumn<int>(
                name: "ApplicationDetailId",
                table: "User",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_User_ApplicationDetail_ApplicationDetailId",
                table: "User",
                column: "ApplicationDetailId",
                principalTable: "ApplicationDetail",
                principalColumn: "ApplicationDetailId");
        }
    }
}
