using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projectef.Migrations
{
    public partial class AddData2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaCreacion",
                table: "Tarea",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 7, 17, 21, 6, 568, DateTimeKind.Utc).AddTicks(8536),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 7, 17, 15, 14, 909, DateTimeKind.Utc).AddTicks(9781));

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoriaId", "Descripcion", "Nombre", "Peso" },
                values: new object[] { new Guid("4d5fa2fc-b658-414c-8b9c-8670a42bc2b6"), null, "Actividades Profesionales", 90 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("4d5fa2fc-b658-414c-8b9c-8670a42bc2b6"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaCreacion",
                table: "Tarea",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 7, 17, 15, 14, 909, DateTimeKind.Utc).AddTicks(9781),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 7, 17, 21, 6, 568, DateTimeKind.Utc).AddTicks(8536));
        }
    }
}
