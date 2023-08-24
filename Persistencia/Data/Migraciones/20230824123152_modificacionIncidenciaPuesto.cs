using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistencia.Data.Migraciones
{
    /// <inheritdoc />
    public partial class modificacionIncidenciaPuesto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IncidenciaPuestos_EstadoIncidencias_IdEstadoIncidencia",
                table: "IncidenciaPuestos");

            migrationBuilder.AlterColumn<int>(
                name: "IdEstadoIncidencia",
                table: "IncidenciaPuestos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_IncidenciaPuestos_EstadoIncidencias_IdEstadoIncidencia",
                table: "IncidenciaPuestos",
                column: "IdEstadoIncidencia",
                principalTable: "EstadoIncidencias",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IncidenciaPuestos_EstadoIncidencias_IdEstadoIncidencia",
                table: "IncidenciaPuestos");

            migrationBuilder.AlterColumn<int>(
                name: "IdEstadoIncidencia",
                table: "IncidenciaPuestos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_IncidenciaPuestos_EstadoIncidencias_IdEstadoIncidencia",
                table: "IncidenciaPuestos",
                column: "IdEstadoIncidencia",
                principalTable: "EstadoIncidencias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
