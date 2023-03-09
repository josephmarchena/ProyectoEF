using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projectef.Migrations
{
    public partial class AddData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaCreacion",
                table: "Tarea",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 7, 17, 15, 14, 909, DateTimeKind.Utc).AddTicks(9781),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 7, 3, 22, 18, 737, DateTimeKind.Utc).AddTicks(3829));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaCreacion",
                table: "Tarea",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 7, 3, 22, 18, 737, DateTimeKind.Utc).AddTicks(3829),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 7, 17, 15, 14, 909, DateTimeKind.Utc).AddTicks(9781));
        }
    }
}
