using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistencia.Data.Migraciones
{
    /// <inheritdoc />
    public partial class modificacion2TablaPersona : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personas_ARLs_IdARL",
                table: "Personas");

            migrationBuilder.AlterColumn<int>(
                name: "IdARL",
                table: "Personas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_ARLs_IdARL",
                table: "Personas",
                column: "IdARL",
                principalTable: "ARLs",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personas_ARLs_IdARL",
                table: "Personas");

            migrationBuilder.AlterColumn<int>(
                name: "IdARL",
                table: "Personas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_ARLs_IdARL",
                table: "Personas",
                column: "IdARL",
                principalTable: "ARLs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
