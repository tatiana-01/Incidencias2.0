using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistencia.Data.Migraciones
{
    /// <inheritdoc />
    public partial class nuevaDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: "123456",
                column: "FechaNacimiento",
                value: new DateOnly(2023, 9, 7));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "Contraseña",
                value: "AQAAAAIAAYagAAAAECbBDKkKGLvLFGr+5ZbYRyMyq+S700hdhyIYz/2s7m1fPoNJxNBrenrzcX2aIsR8+A==");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: "123456",
                column: "FechaNacimiento",
                value: new DateOnly(2023, 9, 6));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "Contraseña",
                value: "AQAAAAIAAYagAAAAEN+Q9HJ2viSwM5XsgX4FMTtTP4HGZ5L9JXIaXz/FCVNnrDnjDC39ZmKAmJqLEt7mUQ==");
        }
    }
}
