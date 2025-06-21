using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaCadastroDeHorasApi.Migrations
{
    /// <inheritdoc />
    public partial class updating_table_atividades_add_column_comprovante : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "comprovante",
                table: "Atividades",
                type: "bytea",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<string>(
                name: "nomeArquivo",
                table: "Atividades",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "tipoArquivo",
                table: "Atividades",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "comprovante",
                table: "Atividades");

            migrationBuilder.DropColumn(
                name: "nomeArquivo",
                table: "Atividades");

            migrationBuilder.DropColumn(
                name: "tipoArquivo",
                table: "Atividades");
        }
    }
}
