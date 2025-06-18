using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaCadastroDeHorasApi.Migrations
{
    /// <inheritdoc />
    public partial class creating_table_AtividadeUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AtividadeUsuarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    UsuarioId = table.Column<int>(type: "integer", nullable: false),
                    AtividadeId = table.Column<Guid>(type: "uuid", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtividadeUsuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AtividadeUsuarios_Atividades_AtividadeId",
                        column: x => x.AtividadeId,
                        principalTable: "Atividades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AtividadeUsuarios_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AtividadeUsuarios_AtividadeId",
                table: "AtividadeUsuarios",
                column: "AtividadeId");

            migrationBuilder.CreateIndex(
                name: "IX_AtividadeUsuarios_UsuarioId",
                table: "AtividadeUsuarios",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AtividadeUsuarios");
        }
    }
}
