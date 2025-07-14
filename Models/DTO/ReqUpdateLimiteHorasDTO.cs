using System.ComponentModel;

namespace SistemaCadastroDeHorasApi.Models.DTO;

public record ReqUpdateLimiteHorasDTO(
    [DefaultValue(96)] int HorasTotaisDeIniciacaoADocenciaOuVivenciaOuExtensão,
    [DefaultValue(32)] int HorasTotaisDeParticipacaoOuOrganizacaoDeEventos,
    [DefaultValue(80)] int HorasTotaisDeAtividadesArtisticoCulturaisEEsportivas,
    [DefaultValue(64)] int HorasTotaisDeExperienciasLigadasAFormacaoProfissional,
    [DefaultValue(96)] int HorasTotaisDeProducaoTecnicaOuCientifica,
    [DefaultValue(48)] int HorasTotaisDeVivenciasDeGestao,
    [DefaultValue(48)] int HorasTotaisDeOutrasAtividades
);