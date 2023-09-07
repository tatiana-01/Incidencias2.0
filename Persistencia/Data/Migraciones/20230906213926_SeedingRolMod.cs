using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistencia.Data.Migraciones
{
    /// <inheritdoc />
    public partial class SeedingRolMod : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UsuarioRoles",
                keyColumns: new[] { "IdRol", "IdUsuario" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "UsuarioRoles",
                columns: new[] { "IdRol", "IdUsuario" },
                values: new object[] { 2, 1 });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "Contraseña",
                value: "AQAAAAIAAYagAAAAEN+Q9HJ2viSwM5XsgX4FMTtTP4HGZ5L9JXIaXz/FCVNnrDnjDC39ZmKAmJqLEt7mUQ==");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UsuarioRoles",
                keyColumns: new[] { "IdRol", "IdUsuario" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.InsertData(
                table: "UsuarioRoles",
                columns: new[] { "IdRol", "IdUsuario" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "Contraseña",
                value: "AQAAAAIAAYagAAAAEBTmJbjytdBTmHD75zBB6uRBgWOQ0x3Rjw2Spl3KoehRFfAH9rpVtqpdsM95f4Rfhg==");
        }
    }
}
