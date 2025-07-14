using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaCadastroDeHorasApi.Migrations
{
    /// <inheritdoc />
    public partial class update_table_atividades_rename_column_tipoAtividadeComplementarHoras : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "tipoAtividadeComplementarHoras",
                table: "Atividades",
                newName: "categoriaAtividadeComplementarHoras");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "categoriaAtividadeComplementarHoras",
                table: "Atividades",
                newName: "tipoAtividadeComplementarHoras");
        }
    }
}
