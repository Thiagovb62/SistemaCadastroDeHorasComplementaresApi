using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace SistemaCadastroDeHorasApi.Models.DTO;

public record ReqUserDTO(
    [Required(ErrorMessage = "O nome é obrigatório")]
    string Nome,
    [Required(ErrorMessage = "A matrícula é obrigatória")]
    [Range(1, int.MaxValue, ErrorMessage = "A matrícula deve ser um número positivo")]
    int Matricula,
    [Required(ErrorMessage = "A senha é obrigatória")]
    string Senha,
    [Required(ErrorMessage = "O semestre de ingresso é obrigatório")]
    [Range(2000, 2026, ErrorMessage = "O semestre de ingresso deve estar entre os anos 2000 e 2026")]
    int SemestreDeIngresso
);