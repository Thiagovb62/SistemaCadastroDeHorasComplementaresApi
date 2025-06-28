using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SistemaCadastroDeHorasApi.Migrations
{
    /// <inheritdoc />
    public partial class alter_table_user_and_atividades : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<int>(
                name: "horasRestantesTotais",
                table: "Usuarios",
                type: "integer",
                defaultValue:288);

            migrationBuilder.AddColumn<int>(
                name: "tipoAtividadeComplementarHoras",
                table: "Atividades",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HorasTotais",
                table: "Usuarios",
                type: "integer",
                defaultValue: 288);

            migrationBuilder.AddColumn<int>(
                name: "HorasTotaisDeAtividadesArtisticoCulturaisEEsportivas",
                table: "Usuarios",
                type: "integer",
                nullable: false,
                defaultValue: 80);

            migrationBuilder.AddColumn<int>(
                name: "HorasTotaisDeExperienciasLigadasAFormacaoProfissional",
                table: "Usuarios",
                type: "integer",
                nullable: false,
                defaultValue: 64);

            migrationBuilder.AddColumn<int>(
                name: "HorasTotaisDeIniciacaoADocenciaOuVivenciaOuExtensão",
                table: "Usuarios",
                type: "integer",
                nullable: false,
                defaultValue: 96);

            migrationBuilder.AddColumn<int>(
                name: "HorasTotaisDeOutrasAtividades",
                table: "Usuarios",
                type: "integer",
                nullable: false,
                defaultValue: 48 );

            migrationBuilder.AddColumn<int>(
                name: "HorasTotaisDeParticipacaoOuOrganizacaoDeEventos",
                table: "Usuarios",
                type: "integer",
                nullable: false,
                defaultValue: 32);

            migrationBuilder.AddColumn<int>(
                name: "HorasTotaisDeProducaoTecnicaOuCientifica",
                table: "Usuarios",
                type: "integer",
                nullable: false,
                defaultValue: 96);

            migrationBuilder.AddColumn<int>(
                name: "HorasTotaisDeVivenciasDeGestao",
                table: "Usuarios",
                type: "integer",
                nullable: false,
                defaultValue: 48);

            migrationBuilder.AddColumn<int>(
                name: "horasRestantesDeAtividadesArtisticoCulturaisEEsportivas",
                table: "Usuarios",
                type: "integer",
                nullable: false,
                defaultValue: 80);

            migrationBuilder.AddColumn<int>(
                name: "horasRestantesDeExperienciasLigadasAFormacaoProfissional",
                table: "Usuarios",
                type: "integer",
                nullable: false,
                defaultValue: 64);

            migrationBuilder.AddColumn<int>(
                name: "horasRestantesDeIniciacaoADocenciaOuVivenciaOuExtensão",
                table: "Usuarios",
                type: "integer",
                nullable: false,
                defaultValue: 96);

            migrationBuilder.AddColumn<int>(
                name: "horasRestantesDeOutrasAtividades",
                table: "Usuarios",
                type: "integer",
                nullable: false,
                defaultValue: 48);

            migrationBuilder.AddColumn<int>(
                name: "horasRestantesDeParticipacaoOuOrganizacaoDeEventos",
                table: "Usuarios",
                type: "integer",
                nullable: false,
                defaultValue: 32);

            migrationBuilder.AddColumn<int>(
                name: "horasRestantesDeProducaoTecnicaOuCientifica",
                table: "Usuarios",
                type: "integer",
                nullable: false,
                defaultValue: 68);

            migrationBuilder.AddColumn<int>(
                name: "horasRestantesDeVivenciasDeGestao",
                table: "Usuarios",
                type: "integer",
                nullable: false,
                defaultValue: 48);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HorasTotais",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "HorasTotaisDeAtividadesArtisticoCulturaisEEsportivas",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "HorasTotaisDeExperienciasLigadasAFormacaoProfissional",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "HorasTotaisDeIniciacaoADocenciaOuVivenciaOuExtensão",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "HorasTotaisDeOutrasAtividades",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "HorasTotaisDeParticipacaoOuOrganizacaoDeEventos",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "HorasTotaisDeProducaoTecnicaOuCientifica",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "HorasTotaisDeVivenciasDeGestao",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "horasRestantesDeAtividadesArtisticoCulturaisEEsportivas",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "horasRestantesDeExperienciasLigadasAFormacaoProfissional",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "horasRestantesDeIniciacaoADocenciaOuVivenciaOuExtensão",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "horasRestantesDeOutrasAtividades",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "horasRestantesDeParticipacaoOuOrganizacaoDeEventos",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "horasRestantesDeProducaoTecnicaOuCientifica",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "horasRestantesDeVivenciasDeGestao",
                table: "Usuarios");

            migrationBuilder.RenameColumn(
                name: "horasRestantesTotais",
                table: "Usuarios",
                newName: "HorasId");

            migrationBuilder.RenameColumn(
                name: "tipoAtividadeComplementarHoras",
                table: "Atividades",
                newName: "HorasAtividadesComplemetaresId");

            migrationBuilder.CreateTable(
                name: "HorasAtividadesComplemetares",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    HorasMaximas = table.Column<int>(type: "integer", nullable: false),
                    HorasRestantes = table.Column<int>(type: "integer", nullable: false),
                    HorasemSolicitaçõesSubmetidas = table.Column<int>(type: "integer", nullable: false),
                    tipoAtividadeComplementarHoras = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HorasAtividadesComplemetares", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_HorasId",
                table: "Usuarios",
                column: "HorasId");

            migrationBuilder.CreateIndex(
                name: "IX_Atividades_HorasAtividadesComplemetaresId",
                table: "Atividades",
                column: "HorasAtividadesComplemetaresId");

            migrationBuilder.AddForeignKey(
                name: "FK_Atividades_HorasAtividadesComplemetares_HorasAtividadesComp~",
                table: "Atividades",
                column: "HorasAtividadesComplemetaresId",
                principalTable: "HorasAtividadesComplemetares",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_HorasAtividadesComplemetares_HorasId",
                table: "Usuarios",
                column: "HorasId",
                principalTable: "HorasAtividadesComplemetares",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
