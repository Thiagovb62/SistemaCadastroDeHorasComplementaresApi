using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaCadastroDeHorasApi.Migrations
{
    /// <inheritdoc />
    public partial class updating_table_atividades_add_status_from_atividade_usuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "AtividadeUsuarios");

            migrationBuilder.AddColumn<DateTime>(
                name: "dataSubmissao",
                table: "Atividades",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "status",
                table: "Atividades",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "dataSubmissao",
                table: "Atividades");

            migrationBuilder.DropColumn(
                name: "status",
                table: "Atividades");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "AtividadeUsuarios",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
