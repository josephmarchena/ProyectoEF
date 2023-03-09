using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projectef.Migrations
{
    public partial class AddData3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaCreacion",
                table: "Tarea",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 7, 17, 35, 49, 884, DateTimeKind.Utc).AddTicks(2890),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 7, 17, 21, 6, 568, DateTimeKind.Utc).AddTicks(8536));

            migrationBuilder.InsertData(
                table: "Tarea",
                columns: new[] { "TareaId", "CategoriaId", "Descripcion", "FechaCreacion", "PrioridadTarea", "Titulo" },
                values: new object[] { new Guid("2ad473bf-f9f4-41c2-aa9c-0066da6efaf5"), new Guid("4d5fa2fc-b658-414c-8b9c-8670a42bc2b6"), "Descripcion de la tarea 3", new DateTime(2023, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Mi tarea 3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("2ad473bf-f9f4-41c2-aa9c-0066da6efaf5"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaCreacion",
                table: "Tarea",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 7, 17, 21, 6, 568, DateTimeKind.Utc).AddTicks(8536),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 7, 17, 35, 49, 884, DateTimeKind.Utc).AddTicks(2890));
        }
    }
}
