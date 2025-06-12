using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaCadastroDeHorasApi.Migrations
{
    /// <inheritdoc />
    public partial class creating_table_atividades : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Atividades",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    TipoAtividadeId = table.Column<int>(type: "integer", nullable: false),
                    TipoParticipacaoId = table.Column<int>(type: "integer", nullable: false),
                    pais = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    titulo = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    nomeInstituicao =
                        table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    cnpj = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    dataInicio = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    dataFim = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    isExecUfc = table.Column<bool>(type: "boolean", nullable: false),
                    cargaHoraria = table.Column<int>(type: "integer", nullable: false),
                    qtdHorasUtilizadas = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atividades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Atividades_TipoAtividadeId",
                        column: x => x.TipoAtividadeId,
                        principalTable: "Tipo_Atividade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Atividades_TipoParticipacaoId",
                        column: x => x.TipoParticipacaoId,
                        principalTable: "Tipo_Participacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
