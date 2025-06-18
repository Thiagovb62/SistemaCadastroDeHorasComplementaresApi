using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaCadastroDeHorasApi.Migrations
{
    /// <inheritdoc />
    public partial class updating_table_atividades_add_user_references : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "cnpj",
                table: "Atividades",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Atividades",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Atividades_UsuarioId",
                table: "Atividades",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Atividades_Usuarios_UsuarioId",
                table: "Atividades",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Atividades_Usuarios_UsuarioId",
                table: "Atividades");

            migrationBuilder.DropIndex(
                name: "IX_Atividades_UsuarioId",
                table: "Atividades");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Atividades");

            migrationBuilder.AlterColumn<string>(
                name: "cnpj",
                table: "Atividades",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100,
                oldNullable: true);
        }
    }
}
