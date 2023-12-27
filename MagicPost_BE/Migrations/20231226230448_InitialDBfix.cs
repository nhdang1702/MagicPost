using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicPost_BE.Migrations
{
    /// <inheritdoc />
    public partial class InitialDBfix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Office_WorkAtOfficeId1",
                table: "Accounts");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_WorkAtOfficeId1",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "WorkAtOfficeId1",
                table: "Accounts");

            migrationBuilder.AlterColumn<long>(
                name: "WorkAtOfficeId",
                table: "Accounts",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 1,
                column: "WorkAtOfficeId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 2,
                column: "WorkAtOfficeId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 3,
                column: "WorkAtOfficeId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 4,
                column: "WorkAtOfficeId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_WorkAtOfficeId",
                table: "Accounts",
                column: "WorkAtOfficeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Office_WorkAtOfficeId",
                table: "Accounts",
                column: "WorkAtOfficeId",
                principalTable: "Office",
                principalColumn: "OfficeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Office_WorkAtOfficeId",
                table: "Accounts");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_WorkAtOfficeId",
                table: "Accounts");

            migrationBuilder.AlterColumn<int>(
                name: "WorkAtOfficeId",
                table: "Accounts",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "WorkAtOfficeId1",
                table: "Accounts",
                type: "bigint",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 1,
                columns: new[] { "WorkAtOfficeId", "WorkAtOfficeId1" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 2,
                columns: new[] { "WorkAtOfficeId", "WorkAtOfficeId1" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 3,
                columns: new[] { "WorkAtOfficeId", "WorkAtOfficeId1" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 4,
                columns: new[] { "WorkAtOfficeId", "WorkAtOfficeId1" },
                values: new object[] { null, null });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_WorkAtOfficeId1",
                table: "Accounts",
                column: "WorkAtOfficeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Office_WorkAtOfficeId1",
                table: "Accounts",
                column: "WorkAtOfficeId1",
                principalTable: "Office",
                principalColumn: "OfficeId");
        }
    }
}
