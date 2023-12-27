using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MagicPost_BE.Migrations
{
    /// <inheritdoc />
    public partial class InitialDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerID);
                });

            migrationBuilder.CreateTable(
                name: "Office",
                columns: table => new
                {
                    OfficeId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OfficeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OfficeType = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Office", x => x.OfficeId);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    AccountId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<int>(type: "int", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkAtOfficeId = table.Column<int>(type: "int", nullable: true),
                    WorkAtOfficeId1 = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.AccountId);
                    table.ForeignKey(
                        name: "FK_Accounts_Office_WorkAtOfficeId1",
                        column: x => x.WorkAtOfficeId1,
                        principalTable: "Office",
                        principalColumn: "OfficeId");
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ShipDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    SentFromOfficeId = table.Column<long>(type: "bigint", nullable: true),
                    SentToOfficeId = table.Column<long>(type: "bigint", nullable: true),
                    CurrentOfficeOfficeId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Office_CurrentOfficeOfficeId",
                        column: x => x.CurrentOfficeOfficeId,
                        principalTable: "Office",
                        principalColumn: "OfficeId");
                    table.ForeignKey(
                        name: "FK_Orders_Office_SentFromOfficeId",
                        column: x => x.SentFromOfficeId,
                        principalTable: "Office",
                        principalColumn: "OfficeId");
                    table.ForeignKey(
                        name: "FK_Orders_Office_SentToOfficeId",
                        column: x => x.SentToOfficeId,
                        principalTable: "Office",
                        principalColumn: "OfficeId");
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "AccountId", "Email", "FullName", "Password", "Phone", "Role", "WorkAtOfficeId", "WorkAtOfficeId1" },
                values: new object[,]
                {
                    { 1, "dang@vnu.edu.vn", "Nguyen Hong Dang", "123", "0888888888", 0, null, null },
                    { 2, "duong@vnu.edu.vn", "Nguyen Hoang Duong", "123", "0999999999", 0, null, null },
                    { 3, "an@vnu.edu.vn", "Vu Huu An", "123", "0777777777", 2, null, null },
                    { 4, "andy@vnu.edu.vn", "Andy", "123", "0152345688", 4, null, null }
                });

            migrationBuilder.InsertData(
                table: "Office",
                columns: new[] { "OfficeId", "Address", "OfficeName", "OfficeType", "Phone" },
                values: new object[,]
                {
                    { 100L, null, "Ha Dong", 0, null },
                    { 101L, null, "Cau Giay", 1, null },
                    { 102L, null, "Hai Ba Trung", 1, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_WorkAtOfficeId1",
                table: "Accounts",
                column: "WorkAtOfficeId1");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CurrentOfficeOfficeId",
                table: "Orders",
                column: "CurrentOfficeOfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerID",
                table: "Orders",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_SentFromOfficeId",
                table: "Orders",
                column: "SentFromOfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_SentToOfficeId",
                table: "Orders",
                column: "SentToOfficeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Office");
        }
    }
}
