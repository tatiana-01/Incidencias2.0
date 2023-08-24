using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistencia.Data.Migraciones
{
    /// <inheritdoc />
    public partial class modificacionCategoria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TipoComponentes_Categorias_IdCategoria",
                table: "TipoComponentes");

            migrationBuilder.DropIndex(
                name: "IX_TipoComponentes_IdCategoria",
                table: "TipoComponentes");

            migrationBuilder.DropColumn(
                name: "IdCategoria",
                table: "TipoComponentes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdCategoria",
                table: "TipoComponentes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TipoComponentes_IdCategoria",
                table: "TipoComponentes",
                column: "IdCategoria");

            migrationBuilder.AddForeignKey(
                name: "FK_TipoComponentes_Categorias_IdCategoria",
                table: "TipoComponentes",
                column: "IdCategoria",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
