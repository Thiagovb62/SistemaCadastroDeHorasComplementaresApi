using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaCadastroDeHorasApi.Models;

public class Usuario
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Auto-incremento
    public int Id { get; set; }

    [Required]
    public string Nome { get; set; }

    [Required]
    public int Matricula { get; set; }

    [Required]
    public string Senha { get; set; }

    [Required]
    public int SemestreDeIngresso { get; set; }
    
    [DefaultValue(288)]
    public int HorasTotais { get; set; }
    
    [DefaultValue(96)]
    public int HorasTotaisDeIniciacaoADocenciaOuVivenciaOuExtensão { get; set; }
    
    [DefaultValue(32)]
    public int HorasTotaisDeParticipacaoOuOrganizacaoDeEventos { get; set; }
    
    
    [DefaultValue(80)]
    public int HorasTotaisDeAtividadesArtisticoCulturaisEEsportivas { get; set; }
    
        
    [DefaultValue(64)]
    public int HorasTotaisDeExperienciasLigadasAFormacaoProfissional { get; set; }
    

    [DefaultValue(96)]
    public int HorasTotaisDeProducaoTecnicaOuCientifica { get; set; }
    
    [DefaultValue(48)]
    public int HorasTotaisDeVivenciasDeGestao { get; set; }
        
    [DefaultValue(48)]
    public int HorasTotaisDeOutrasAtividades { get; set; }
    
    [DefaultValue(288)]
    public int horasRestantesTotais { get; set; }
    
    [DefaultValue(96)]
    public int horasRestantesDeIniciacaoADocenciaOuVivenciaOuExtensão { get; set; }
    
    [DefaultValue(32)]
    public int horasRestantesDeParticipacaoOuOrganizacaoDeEventos { get; set; }
    
    [DefaultValue(80)]
    public int horasRestantesDeAtividadesArtisticoCulturaisEEsportivas { get; set; }
    
    [DefaultValue(64)]
    public int horasRestantesDeExperienciasLigadasAFormacaoProfissional { get; set; }
    
    [DefaultValue(68)]
    public int horasRestantesDeProducaoTecnicaOuCientifica { get; set; }
    
    [DefaultValue(48)]
    public int horasRestantesDeVivenciasDeGestao { get; set; }
    
    [DefaultValue(48)]
    public int horasRestantesDeOutrasAtividades { get; set; }
   
}