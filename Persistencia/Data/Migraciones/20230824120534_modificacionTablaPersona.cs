using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistencia.Data.Migraciones
{
    /// <inheritdoc />
    public partial class modificacionTablaPersona : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personas_EPSs_IdEPS",
                table: "Personas");

            migrationBuilder.AlterColumn<int>(
                name: "IdEPS",
                table: "Personas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_EPSs_IdEPS",
                table: "Personas",
                column: "IdEPS",
                principalTable: "EPSs",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personas_EPSs_IdEPS",
                table: "Personas");

            migrationBuilder.AlterColumn<int>(
                name: "IdEPS",
                table: "Personas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_EPSs_IdEPS",
                table: "Personas",
                column: "IdEPS",
                principalTable: "EPSs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
