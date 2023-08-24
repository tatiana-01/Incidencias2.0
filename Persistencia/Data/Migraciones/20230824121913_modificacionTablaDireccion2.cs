using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistencia.Data.Migraciones
{
    /// <inheritdoc />
    public partial class modificacionTablaDireccion2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Numero",
                table: "Direcciones",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "LetraViaSecundaria",
                table: "Direcciones",
                type: "varchar(1)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(1)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Letra",
                table: "Direcciones",
                type: "varchar(1)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(1)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Numero",
                table: "Direcciones",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Direcciones",
                keyColumn: "LetraViaSecundaria",
                keyValue: null,
                column: "LetraViaSecundaria",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "LetraViaSecundaria",
                table: "Direcciones",
                type: "varchar(1)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(1)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Direcciones",
                keyColumn: "Letra",
                keyValue: null,
                column: "Letra",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Letra",
                table: "Direcciones",
                type: "varchar(1)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(1)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
