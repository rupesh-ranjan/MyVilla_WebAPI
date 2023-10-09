using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyVilla_VillaAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedVillaNumberTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "VillaNumbers",
                columns: new[] { "VillNo", "CreatedDate", "SpecialDetails", "UpdatedDate" },
                values: new object[] { 1, new DateTime(2023, 10, 9, 12, 14, 1, 120, DateTimeKind.Local).AddTicks(2719), "special defect", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 9, 12, 14, 1, 120, DateTimeKind.Local).AddTicks(2503));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 9, 12, 14, 1, 120, DateTimeKind.Local).AddTicks(2517));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 9, 12, 14, 1, 120, DateTimeKind.Local).AddTicks(2519));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 9, 12, 14, 1, 120, DateTimeKind.Local).AddTicks(2521));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 9, 12, 14, 1, 120, DateTimeKind.Local).AddTicks(2524));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "VillaNumbers",
                keyColumn: "VillNo",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 8, 20, 6, 9, 166, DateTimeKind.Local).AddTicks(5207));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 8, 20, 6, 9, 166, DateTimeKind.Local).AddTicks(5223));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 8, 20, 6, 9, 166, DateTimeKind.Local).AddTicks(5226));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 8, 20, 6, 9, 166, DateTimeKind.Local).AddTicks(5228));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 8, 20, 6, 9, 166, DateTimeKind.Local).AddTicks(5231));
        }
    }
}
