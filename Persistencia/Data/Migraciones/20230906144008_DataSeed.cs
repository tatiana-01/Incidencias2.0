using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistencia.Data.Migraciones
{
    /// <inheritdoc />
    public partial class DataSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Generos",
                columns: new[] { "Id", "Nombre" },
                values: new object[] { 1, "Otros" });

            migrationBuilder.InsertData(
                table: "Personas",
                columns: new[] { "Id", "FechaNacimiento", "IdARL", "IdEPS", "IdGenero", "Nombre" },
                values: new object[] { "123456", new DateOnly(2023, 9, 6), null, null, 1, "Admin" });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Contraseña", "Email", "IdPersona", "UsuarioPersona" },
                values: new object[] { 1, "AQAAAAIAAYagAAAAEBdxrnls6qOIS6VeHqUIHwpasHPXuyDNrZI3KVuH+pInJNQpfBzID4MvX+26NLgB6Q==", "admin@corre.com", "123456", "Admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: "123456");

            migrationBuilder.DeleteData(
                table: "Generos",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
