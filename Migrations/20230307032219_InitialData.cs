using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projectef.Migrations
{
    public partial class InitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaCreacion",
                table: "Tarea",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 7, 3, 22, 18, 737, DateTimeKind.Utc).AddTicks(3829),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoriaId", "Descripcion", "Nombre", "Peso" },
                values: new object[] { new Guid("4d5fa2fc-b658-414c-8b9c-8670a42bc2b4"), null, "Actividades Pendientes", 20 });

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoriaId", "Descripcion", "Nombre", "Peso" },
                values: new object[] { new Guid("4d5fa2fc-b658-414c-8b9c-8670a42bc2b5"), null, "Actividades Personales", 50 });

            migrationBuilder.InsertData(
                table: "Tarea",
                columns: new[] { "TareaId", "CategoriaId", "Descripcion", "PrioridadTarea", "Titulo" },
                values: new object[] { new Guid("5cbb38c4-0d16-4220-a835-feee920d750a"), new Guid("4d5fa2fc-b658-414c-8b9c-8670a42bc2b4"), "Descripcion de la tarea 1", 0, "Mi tarea 1" });

            migrationBuilder.InsertData(
                table: "Tarea",
                columns: new[] { "TareaId", "CategoriaId", "Descripcion", "PrioridadTarea", "Titulo" },
                values: new object[] { new Guid("9f8b42d3-9902-4634-9c82-427d8888b1be"), new Guid("4d5fa2fc-b658-414c-8b9c-8670a42bc2b5"), "Descripcion de la tarea 2", 1, "Mi tarea 2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("5cbb38c4-0d16-4220-a835-feee920d750a"));

            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("9f8b42d3-9902-4634-9c82-427d8888b1be"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("4d5fa2fc-b658-414c-8b9c-8670a42bc2b4"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("4d5fa2fc-b658-414c-8b9c-8670a42bc2b5"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaCreacion",
                table: "Tarea",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 7, 3, 22, 18, 737, DateTimeKind.Utc).AddTicks(3829));
        }
    }
}
