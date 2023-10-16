using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyVilla_VillaAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddLocalusersToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LocalUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalUsers", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "VillaNumbers",
                keyColumn: "VillNo",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 16, 19, 11, 22, 472, DateTimeKind.Local).AddTicks(8111));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 16, 19, 11, 22, 472, DateTimeKind.Local).AddTicks(7949));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 16, 19, 11, 22, 472, DateTimeKind.Local).AddTicks(7961));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 16, 19, 11, 22, 472, DateTimeKind.Local).AddTicks(7963));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 16, 19, 11, 22, 472, DateTimeKind.Local).AddTicks(7964));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 16, 19, 11, 22, 472, DateTimeKind.Local).AddTicks(7966));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LocalUsers");

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
    }
}
