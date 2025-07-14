using System.ComponentModel.DataAnnotations;

namespace SistemaCadastroDeHorasApi.Models.DTO;

public class ReqTipo_AtividadeDTO
{
    [Required(ErrorMessage = "O nome é obrigatório")]
    public string nome { get; set; }
}