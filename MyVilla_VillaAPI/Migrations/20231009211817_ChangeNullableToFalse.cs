using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyVilla_VillaAPI.Migrations
{
    /// <inheritdoc />
    public partial class ChangeNullableToFalse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Villas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "VillaNumbers",
                keyColumn: "VillNo",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 10, 2, 48, 17, 393, DateTimeKind.Local).AddTicks(1996));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 10, 2, 48, 17, 393, DateTimeKind.Local).AddTicks(1457));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 10, 2, 48, 17, 393, DateTimeKind.Local).AddTicks(1489));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 10, 2, 48, 17, 393, DateTimeKind.Local).AddTicks(1493));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 10, 2, 48, 17, 393, DateTimeKind.Local).AddTicks(1496));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 10, 2, 48, 17, 393, DateTimeKind.Local).AddTicks(1500));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Villas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "VillaNumbers",
                keyColumn: "VillNo",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 9, 19, 0, 31, 676, DateTimeKind.Local).AddTicks(8363));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 9, 19, 0, 31, 676, DateTimeKind.Local).AddTicks(8052));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 9, 19, 0, 31, 676, DateTimeKind.Local).AddTicks(8077));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 9, 19, 0, 31, 676, DateTimeKind.Local).AddTicks(8080));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 9, 19, 0, 31, 676, DateTimeKind.Local).AddTicks(8083));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 9, 19, 0, 31, 676, DateTimeKind.Local).AddTicks(8085));
        }
    }
}
