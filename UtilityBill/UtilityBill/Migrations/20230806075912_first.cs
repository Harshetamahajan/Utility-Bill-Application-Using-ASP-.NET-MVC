using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UtilityBill.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    AddressId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Street = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PinCode = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.AddressId);
                });

            migrationBuilder.CreateTable(
                name: "MeterDetail",
                columns: table => new
                {
                    MeterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstallationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeterDetail", x => x.MeterId);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationDetail",
                columns: table => new
                {
                    ApplicationDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ApplicationStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConnectionType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequiredLoad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MeterDetailMeterId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationDetail", x => x.ApplicationDetailId);
                    table.ForeignKey(
                        name: "FK_ApplicationDetail_MeterDetail_MeterDetailMeterId",
                        column: x => x.MeterDetailMeterId,
                        principalTable: "MeterDetail",
                        principalColumn: "MeterId");
                });

            migrationBuilder.CreateTable(
                name: "BillDetail",
                columns: table => new
                {
                    BillDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnitsConsumed = table.Column<int>(type: "int", nullable: false),
                    TotalBill = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BillDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BillStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MeterDetailMeterId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillDetail", x => x.BillDetailId);
                    table.ForeignKey(
                        name: "FK_BillDetail_MeterDetail_MeterDetailMeterId",
                        column: x => x.MeterDetailMeterId,
                        principalTable: "MeterDetail",
                        principalColumn: "MeterId");
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    AddressId = table.Column<int>(type: "int", nullable: true),
                    ApplicationDetailId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_User_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "AddressId");
                    table.ForeignKey(
                        name: "FK_User_ApplicationDetail_ApplicationDetailId",
                        column: x => x.ApplicationDetailId,
                        principalTable: "ApplicationDetail",
                        principalColumn: "ApplicationDetailId");
                });

            migrationBuilder.CreateTable(
                name: "TicketDetail",
                columns: table => new
                {
                    TicketDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketDetail", x => x.TicketDetailId);
                    table.ForeignKey(
                        name: "FK_TicketDetail_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationDetail_MeterDetailMeterId",
                table: "ApplicationDetail",
                column: "MeterDetailMeterId");

            migrationBuilder.CreateIndex(
                name: "IX_BillDetail_MeterDetailMeterId",
                table: "BillDetail",
                column: "MeterDetailMeterId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketDetail_UserId",
                table: "TicketDetail",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_User_AddressId",
                table: "User",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_User_ApplicationDetailId",
                table: "User",
                column: "ApplicationDetailId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BillDetail");

            migrationBuilder.DropTable(
                name: "TicketDetail");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "ApplicationDetail");

            migrationBuilder.DropTable(
                name: "MeterDetail");
        }
    }
}
