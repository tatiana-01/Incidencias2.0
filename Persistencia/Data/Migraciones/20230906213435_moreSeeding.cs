using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistencia.Data.Migraciones
{
    /// <inheritdoc />
    public partial class moreSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Nombre", "Permisos" },
                values: new object[,]
                {
                    { 1, "Persona", "Basicos" },
                    { 2, "Administrador", "Todos" }
                });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "Contraseña",
                value: "AQAAAAIAAYagAAAAEBTmJbjytdBTmHD75zBB6uRBgWOQ0x3Rjw2Spl3KoehRFfAH9rpVtqpdsM95f4Rfhg==");

            migrationBuilder.InsertData(
                table: "UsuarioRoles",
                columns: new[] { "IdRol", "IdUsuario" },
                values: new object[] { 1, 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "UsuarioRoles",
                keyColumns: new[] { "IdRol", "IdUsuario" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "Contraseña",
                value: "AQAAAAIAAYagAAAAEBdxrnls6qOIS6VeHqUIHwpasHPXuyDNrZI3KVuH+pInJNQpfBzID4MvX+26NLgB6Q==");
        }
    }
}
